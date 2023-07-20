using API.Contracts;
using API.Data;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly BookingDbContext _context;

        public GenericRepository(BookingDbContext context)
        {
            _context = context;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>()
                           .ToList();
        }

        public T? GetByGuid(Guid guid)
        {
            var data = _context.Set<T>()
                               .Find(guid);
            _context.ChangeTracker.Clear();
            return data;
        }

        public T? Create(T entity)
        {
            try
            {
                _context.Set<T>()
                        .Add(entity);
                _context.SaveChanges();
                return entity;
            }
            catch
            {
                return null;
            }
        }

        public bool Update(T entity)
        {
            try
            {
                _context.Entry(entity)
                        .State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(T entity)
        {
            try
            {
                _context.Set<T>()
                        .Remove(entity);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
