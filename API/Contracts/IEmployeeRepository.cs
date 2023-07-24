using API.Models;

namespace API.Contracts
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        bool isNotExist(string value);
        string GetLastNik();
    }
}
