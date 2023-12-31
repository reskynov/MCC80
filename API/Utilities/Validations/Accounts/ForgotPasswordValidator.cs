﻿using API.Contracts;
using API.DTOs.Accounts;
using FluentValidation;

namespace API.Utilities.Validations.Accounts
{
    public class ForgotPasswordValidator : AbstractValidator<ForgotPasswordDto>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public ForgotPasswordValidator(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;

            RuleFor(e => e.Email)
                .EmailAddress()
                .NotEmpty().WithMessage("Email is required");
        }
    }
}
