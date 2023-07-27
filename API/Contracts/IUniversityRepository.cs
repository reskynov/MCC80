using API.Models;

namespace API.Contracts
{
    public interface IUniversityRepository : IGenericRepository<University>
    {
        Guid GetLastUniversityGuid();
        University? GetUniversityByCode(string code);
    }
}
