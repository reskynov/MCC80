using API.Models;
using System.Collections.Generic;

namespace API.Contracts
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity? GetByGuid(Guid guid);
        TEntity? Create(TEntity obj);
        bool Update(TEntity obj);
        bool Delete(TEntity obj);
        void Clear();
    }
}
