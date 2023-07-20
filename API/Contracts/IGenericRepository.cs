using API.Models;
using System.Collections.Generic;

namespace API.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T? GetByGuid(Guid guid);
        T? Create(T obj);
        bool Update(T obj);
        bool Delete(T obj);
    }
}
