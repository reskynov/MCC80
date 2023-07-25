using API.Contracts;
using API.DTOs.Employees;
using API.Models;
using FluentValidation;

namespace API.Utilities.Validations.Employees
{
    public class EmployeeValidator : AbstractValidator<EmployeeDto>
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeValidator(IEmployeeRepository employeeRepository)
        {
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
                .Must((e, email) => CheckValidity(e.Guid, email) is true).WithMessage("Phone Number already exists");     

            RuleFor(e => e.PhoneNumber)
                .NotEmpty()
                .MaximumLength(20)
                .Matches("^(^\\+62|62|^08)(\\d{3,4}-?){2}\\d{3,4}$")
                .Must((e, phone) => CheckValidity(e.Guid, phone) is true).WithMessage("Phone Number already exists");
        }

        private bool IsDuplicateValue(string value)
        {
            return _employeeRepository.isNotExist(value);
        }

        private bool CheckValidity(Guid guid, string value)
        {
            bool valid = false;
            (string email, string phone) = GetDataByGuid(guid);
            if(email == value || phone == value)
            {
                valid = true;
            }
            return IsDuplicateValue(value) || valid;
        }

        private (string?, string? ) GetDataByGuid(Guid guid)
        {
            Employee employee = _employeeRepository.GetByGuid(guid);
            return (employee.Email, employee.PhoneNumber);
        }
    }
}
