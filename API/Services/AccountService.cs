using API.Contracts;
using API.Data;
using API.DTOs.Accounts;
using API.DTOs.Educations;
using API.DTOs.Employees;
using API.DTOs.Universities;
using API.Models;
using API.Utilities.Handlers;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Xml.Linq;

namespace API.Services
{
    public class AccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEducationRepository _educationRepository;
        private readonly IUniversityRepository _universityRepository;
        private readonly BookingDbContext _dbContext;
        private readonly IEmailHandler _emailHandler;
        private readonly ITokenHandler _tokenHandler;

        public AccountService(IAccountRepository accountRepository, 
            IEmployeeRepository employeeRepository, 
            IUniversityRepository universityRepository, 
            IEducationRepository educationRepository, 
            BookingDbContext bookingDbContext,
            IEmailHandler emailHandler,
            ITokenHandler tokenHandler)
        {
            _accountRepository = accountRepository;
            _employeeRepository = employeeRepository;
            _universityRepository = universityRepository;
            _educationRepository = educationRepository;
            _dbContext = bookingDbContext;
            _emailHandler = emailHandler;
            _tokenHandler = tokenHandler;
        }

        public IEnumerable<AccountDto> GetAll()
        {
            var accounts = _accountRepository.GetAll();
            if (!accounts.Any())
            {
                return Enumerable.Empty<AccountDto>();
            }

            var accountDtos = new List<AccountDto>();
            foreach (var account in accounts)
            {
                accountDtos.Add((AccountDto)account);
            }

            return accountDtos; // account is found;
        }

        public AccountDto? GetByGuid(Guid guid)
        {
            var accountDto = _accountRepository.GetByGuid(guid);
            if (accountDto is null)
            {
                return null;
            }

            return (AccountDto)accountDto;
        }

        public AccountDto? Create(NewAccountDto newAccountDto)
        {
            var accountToCreate = newAccountDto;
            accountToCreate.Password = HashingHandler.GenerateHash(newAccountDto.Password);
            var accountDto = _accountRepository.Create(accountToCreate);
            if (accountDto is null)
            {
                return null;
            }

            return (AccountDto)accountDto;
        }

        public int Update(AccountDto accountDto)
        {
            var account = _accountRepository.GetByGuid(accountDto.Guid);
            if (account is null)
            {
                return -1; // account is null or not found;
            }

            Account toUpdate = accountDto;
            toUpdate.CreatedDate = account.CreatedDate;
            toUpdate.Password = HashingHandler.GenerateHash(accountDto.Password);
            var result = _accountRepository.Update(toUpdate);

            return result ? 1 // account is updated;
                : 0; // account failed to update;
        }

        public int Delete(Guid guid)
        {
            var account = _accountRepository.GetByGuid(guid);
            if (account is null)
            {
                return -1; // account is null or not found;
            }

            var result = _accountRepository.Delete(account);

            return result ? 1 // account is deleted;
                : 0; // account failed to delete;
        }

        public RegisterDto? Register(RegisterDto registerDto)
        {
            //anticipation If error do rollback
            using var transaction = _dbContext.Database.BeginTransaction();

            try
            {
                //Check University Code from Database
                var existingUniversity = _universityRepository.GetUniversityByCode(registerDto.UniversityCode);
                var universityToCreate = new University();

                if (existingUniversity is null)
                {
                    universityToCreate.Guid = Guid.NewGuid();
                    universityToCreate.Code = registerDto.UniversityCode;
                    universityToCreate.Name = registerDto.UniversityName;
                    universityToCreate.CreatedDate = DateTime.Now;
                    universityToCreate.ModifiedDate = DateTime.Now;
                    //University Create
                    var universityResult = _universityRepository.Create(universityToCreate);
                }
                else
                {
                    universityToCreate = existingUniversity;
                }
                //Employee Create
                Employee employeeToCreate = new NewEmployeeDto
                {
                    FirstName = registerDto.FirstName,
                    LastName = registerDto.LastName,
                    BirthDate = registerDto.BirthDate,
                    Gender = registerDto.Gender,
                    HiringDate = registerDto.HiringDate,
                    Email = registerDto.Email,
                    PhoneNumber = registerDto.PhoneNumber
                };
                employeeToCreate.NIK = GenerateHandler.Nik(_employeeRepository.GetLastNik());
                var employeeResult = _employeeRepository.Create(employeeToCreate);

                //Education Create
                var educationResult = _educationRepository.Create(new NewEducationDto
                {
                    Guid = employeeToCreate.Guid,
                    Degree = registerDto.Degree,
                    Major = registerDto.Major,
                    GPA = registerDto.GPA,
                    UniversityGuid = universityToCreate.Guid
                });

                //Account Create
                var accountResult = _accountRepository.Create(new NewAccountDto
                {
                    Guid = employeeToCreate.Guid,
                    IsUsed = true,
                    ExpiredTime = DateTime.Now.AddMinutes(5),
                    OTP = 111,
                    Password = HashingHandler.GenerateHash(registerDto.Password)
                });

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                return null;
            }

            return (RegisterDto)registerDto;
        }

        public string Login(LoginDto loginDto)
        {
            try
            {
                var getEmployee = _employeeRepository.GetByEmail(loginDto.Email);

                if (getEmployee is null)
                {
                    return "0"; // Employee not found
                }

                var getAccount = _accountRepository.GetByGuid(getEmployee.Guid);

                if (!HashingHandler.ValidateHash(loginDto.Password, getAccount.Password))
                {
                    return "0"; // Login not success
                }

                var claims = new List<Claim>
                {
                    new Claim("Guid", getAccount.Guid.ToString()),
                    new Claim("FullName", $"{getEmployee.FirstName} {getEmployee.LastName}"),
                    new Claim("Email", getEmployee.Email)
                };

                var generatedToken = _tokenHandler.GenerateToken(claims);
                if(generatedToken is null)
                {
                    return "-2";
                }

                return generatedToken;
            }
            
            catch
            {
                return "0";
            }
        }

        public int ForgotPassword(ForgotPasswordDto forgotPasswordDto)
        {
            var otp = new Random().Next(111111, 999999);
            var getAccountDetail = (from e in _employeeRepository.GetAll()
                                    join a in _accountRepository.GetAll() on e.Guid equals a.Guid
                                    where e.Email == forgotPasswordDto.Email
                                    select a).FirstOrDefault();

            if (getAccountDetail is null)
            {
                return 0; // no email found
            }

            _accountRepository.Clear();

            var isUpdated = _accountRepository.Update(new Account
            {
                Guid = getAccountDetail.Guid,
                Password = getAccountDetail.Password,
                ExpiredDate = DateTime.Now.AddMinutes(5),
                OTP = otp,
                IsUsed = false,
                CreatedDate = getAccountDetail.CreatedDate,
                ModifiedDate = getAccountDetail.ModifiedDate
            });

            if (!isUpdated)
            {
                return -1; // error update
            }

            //sending email to user mail
            _emailHandler.SendEmail(new EmailMessageDto
            {
                ToEmail = forgotPasswordDto.Email,
                Subject = "Forgot Password",
                Message = $"Your OTP is {otp}"
            });

            return 1;
        }

        public int ChangePassword(ChangePasswordDto changePasswordDto)
        {
            var getAccount = (from e in _employeeRepository.GetAll()
                              join a in _accountRepository.GetAll() on e.Guid equals a.Guid
                              where e.Email == changePasswordDto.Email
                              select a).FirstOrDefault();

            if (getAccount is null)
            {
                return 0;
            }

            var account = new Account
            {
                Guid = getAccount.Guid,
                IsUsed = true,
                ModifiedDate = DateTime.Now,
                CreatedDate = getAccount.CreatedDate,
                OTP = getAccount.OTP,
                ExpiredDate = getAccount.ExpiredDate,
                Password = HashingHandler.GenerateHash(changePasswordDto.Password),
            };

            if (getAccount.OTP != changePasswordDto.OTP)
            {
                return -1;
            }

            if (getAccount.IsUsed == true)
            {
                return -2;
            }

            if (getAccount.ExpiredDate < DateTime.Now)
            {
                return -3; // OTP expired
            }

            _accountRepository.Clear();

            var isUpdated = _accountRepository.Update(account);
            if (!isUpdated)
            {
                return -4; //Account not Update
            }

            return 3;
        }

        //public int HashAllPassword()
        //{
        //    using var transaction = _dbContext.Database.BeginTransaction();
        //    try
        //    {
        //        var accounts = _accountRepository.GetAll();
        //        foreach (var account in accounts)
        //        {
        //            var accountToChange = account;
        //            accountToChange.Password = HashingHandler.GenerateHash(account.Password);
        //            var update = _accountRepository.Update(accountToChange);
        //        }
        //        transaction.Commit();
        //    }
        //    catch
        //    {
        //        transaction.Rollback();
        //        return -1;
        //    }
        //    return 1;
        //}
    }
}
