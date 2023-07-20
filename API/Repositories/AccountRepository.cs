using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        public AccountRepository(BookingDbContext context) : base(context)
        {
        }
    }
}
