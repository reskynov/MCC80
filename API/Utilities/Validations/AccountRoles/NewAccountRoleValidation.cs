using API.DTOs.AccountRoles;
using FluentValidation;

namespace API.Utilities.Validations.AccountRoles
{
    public class NewAccountRoleValidation : AbstractValidator<NewAccountRoleDto>
    {
        public NewAccountRoleValidation() 
        {
            RuleFor(acc => acc.AccountGuid)
                .NotEmpty();

            RuleFor(acc => acc.RoleGuid)
                .NotEmpty();
        }
    }
}
