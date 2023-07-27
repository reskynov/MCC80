using API.DTOs.Employees;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Contracts
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        bool isNotExist(string value);
        string GetLastNik();
        Employee? GetByEmail(string email);
        Employee? CheckEmail(string email);
        Guid GetLastEmployeeGuid();
        
    }
}
