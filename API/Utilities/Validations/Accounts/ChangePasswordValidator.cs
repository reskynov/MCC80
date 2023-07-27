using API.Contracts;
using API.DTOs.Accounts;
using FluentValidation;

namespace API.Utilities.Validations.Accounts
{
    public class ChangePasswordValidator : AbstractValidator<ChangePasswordDto>
    {
        private readonly IEmployeeRepository _employeeRepository;
        
        public ChangePasswordValidator(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;

            RuleFor(register => register.Email)
                .EmailAddress()
                .NotEmpty().WithMessage("Email is required");

            RuleFor(account => account.OTP)
                .NotEmpty().WithMessage("OTP is required");

            RuleFor(account => account.Password)
                .NotEmpty()
                .Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$");

            RuleFor(account => account.ConfirmPassword)
                .Equal(register => register.Password).WithMessage("Password correct")
                .WithMessage("Password does not match");
        }
    }
}
