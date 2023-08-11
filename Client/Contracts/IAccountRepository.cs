using Client.DTOs.Accounts;
using Client.Models;
using Client.Utilities.Handlers;
using CLient.DTOs.Accounts;

namespace Client.Contracts
{
    public interface IAccountRepository : IRepository<Account, Guid>
    {
        Task<ResponseHandler<TokenDto>> Login(LoginDto login);
    }
}
