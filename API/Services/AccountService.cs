﻿using API.Contracts;
using API.DTOs.Accounts;
using API.DTOs.Educations;
using API.DTOs.Employees;
using API.DTOs.Universities;
using API.Models;
using API.Utilities.Handlers;
using System.Xml.Linq;

namespace API.Services
{
    public class AccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEducationRepository _educationRepository;
        private readonly IUniversityRepository _universityRepository;

        public AccountService(IAccountRepository accountRepository, IEmployeeRepository employeeRepository, IUniversityRepository universityRepository, IEducationRepository educationRepository)
        {
            _accountRepository = accountRepository;
            _employeeRepository = employeeRepository;
            _universityRepository = universityRepository;
            _educationRepository = educationRepository;
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
            var accountDto = _accountRepository.Create(newAccountDto);
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

            var existingUniversity = _universityRepository.GetUniversityByCode(registerDto.UniversityCode);

            var universityToCreate = new NewUniversityDto();

            if (existingUniversity is null)
            {
                universityToCreate.Code = registerDto.UniversityCode;
                universityToCreate.Name = registerDto.UniversityName;
            }
            else
            {
                universityToCreate.Code = existingUniversity.Code;
                universityToCreate.Name = existingUniversity.Name;
            }

            var universityResult = _universityRepository.Create(universityToCreate);

            var educationResult = _educationRepository.Create(new NewEducationDto
            {
                Guid = employeeToCreate.Guid,
                Degree = registerDto.Degree,
                Major = registerDto.Major,
                GPA = registerDto.GPA,
                UniversityGuid = universityResult.Guid
            });

            var accountResult = _accountRepository.Create(new NewAccountDto
            {
                Guid = employeeToCreate.Guid,
                IsUsed = true,
                ExpiredTime = DateTime.Now.AddYears(3),
                OTP = 111,
                Password = registerDto.Password,
            });

            if (employeeResult is null || universityResult is null || educationResult is null || accountResult is null)
            {
                return null;
            }

            return (RegisterDto)registerDto;
        }

        public int Login(LoginDto loginDto)
        {
            var getEmployee = _employeeRepository.GetByEmail(loginDto.Email);

            if (getEmployee is null)
            {
                return 0; // Employee not found
            }

            var getAccount = _accountRepository.GetByGuid(getEmployee.Guid);

            if (getAccount.Password == loginDto.Password)
            {
                return 1; // Login success
            }

            return 0;
        }

        public int ForgotPassword(ForgotPasswordDto forgotPasswordDto)
        {
            var employee = _employeeRepository.GetByEmail(forgotPasswordDto.Email);
            if (employee is null)
            {
                return 0; //Email not found
            }

            var account = _accountRepository.GetByGuid(employee.Guid);
            if (account is null)
            {
                return -1;
            }

            var otp = new Random().Next(111111, 999999);
            var isUpdated = _accountRepository.Update(new Account
            {
                Guid = account.Guid,
                Password = account.Password,
                ExpiredDate = DateTime.Now.AddMinutes(5),
                OTP = otp,
                IsUsed = false,
                CreatedDate = account.CreatedDate,
                ModifiedDate = account.ModifiedDate
            });

            if(!isUpdated)
            {
                return -1;
            }

            forgotPasswordDto.Email = $"{otp}";
            return 1;
        }

        public int ChangePassword(ChangePasswordDto changePasswordDto)
        {
            var isExist = _employeeRepository.CheckEmail(changePasswordDto.Email);
            if (isExist is null)
            {
                return -1;
            }

            var getAccount = _accountRepository.GetByGuid(isExist.Guid);
            var account = new Account
            {
                Guid = getAccount.Guid,
                IsUsed = true,
                ModifiedDate = DateTime.Now,
                CreatedDate = getAccount.CreatedDate,
                OTP = getAccount.OTP,
                ExpiredDate = getAccount.ExpiredDate,
                Password = changePasswordDto.Password,
            };

            if(getAccount.OTP != changePasswordDto.OTP)
            {
                return 0;
            }

            if (getAccount.IsUsed == true)
            {
                return 1;
            }

            if (getAccount.ExpiredDate < DateTime.Now)
            {
                return 2; // OTP expired
            }

            var isUpdated = _accountRepository.Update(account);
            if (!isUpdated)
            {
                return 0; //Account not Update
            }

            return 3;

        }
    }
}
