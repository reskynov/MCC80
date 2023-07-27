using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories;

public class UniversityRepository : GenericRepository<University>, IUniversityRepository
{
    public UniversityRepository(BookingDbContext context) : base(context) { }

    public Guid GetLastUniversityGuid()
    {
        return _context.Set<University>().ToList().LastOrDefault().Guid;
    }

    public University? GetUniversityByCode(string code)
    {
        return _context.Set<University>().SingleOrDefault(u => u.Code == code);
    }
}