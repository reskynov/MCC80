﻿using API.Models;

namespace API.Contracts
{
    public interface IAccountRoleRepository : IGenericRepository<AccountRole>
    {
        IEnumerable<string>? GetRoleNamesByAccountGuid(Guid guid);
    }
}
