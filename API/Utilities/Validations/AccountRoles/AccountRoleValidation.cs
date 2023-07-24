using API.DTOs.AccountRoles;
using FluentValidation;

namespace API.Utilities.Validations.AccountRoles
{
    public class AccountRoleValidation : AbstractValidator<AccountRoleDto>
    {
        public AccountRoleValidation()
        {
            RuleFor(acc => acc.AccountGuid)
                .NotEmpty();

            RuleFor(acc => acc.RoleGuid)
                .NotEmpty();
        }
    }
}
