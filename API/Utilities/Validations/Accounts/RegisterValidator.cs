using API.Contracts;
using API.DTOs.Accounts;
using API.Repositories;
using FluentValidation;

namespace API.Utilities.Validations.Accounts
{
    public class RegisterValidator : AbstractValidator<RegisterDto>
    {
        private readonly IEmployeeRepository _employeeRepository;
        public RegisterValidator(IEmployeeRepository employeeRepository) 
        {
            //Employee Data
            _employeeRepository = employeeRepository;

            RuleFor(e => e.FirstName)
                .NotEmpty();

            RuleFor(e => e.BirthDate)
                .NotEmpty()
                .LessThanOrEqualTo(DateTime.Now.AddYears(-20));

            RuleFor(e => e.Gender)
                .NotNull()
                .IsInEnum();

            RuleFor(e => e.HiringDate)
                .NotEmpty();

            RuleFor(e => e.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Email is not valid")
                .Must(IsDuplicateValue).WithMessage("Email already exists");

            RuleFor(e => e.PhoneNumber)
                .NotEmpty()
                .MaximumLength(20)
                .Matches("^(^\\+62|62|^08)(\\d{3,4}-?){2}\\d{3,4}$")
                .Must(IsDuplicateValue).WithMessage("Phone Number already exists");

            //University Data
            RuleFor(u => u.UniversityName)
                .NotEmpty();

            RuleFor(u => u.UniversityCode)
                .NotEmpty();

            //Education Data
            RuleFor(e => e.Major)
                .NotEmpty();

            RuleFor(e => e.Degree)
                .NotEmpty();

            RuleFor(e => e.GPA)
                .LessThanOrEqualTo(0)
                .GreaterThanOrEqualTo(4)
                .NotEmpty();

            //Account Data
            RuleFor(pass => pass.Password)
                .NotEmpty()
                .Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$");

            RuleFor(pass => pass.ConfirmPassword)
                .Equal(pass => pass.Password)
                .WithMessage("Passwords do not match");
        }

        private bool IsDuplicateValue(string value)
        {
            return _employeeRepository.isNotExist(value);
        }
    
    }
}
