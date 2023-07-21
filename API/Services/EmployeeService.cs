using API.Contracts;
using API.DTOs.Employees;
using API.Models;
using API.Repositories;

namespace API.Services
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IEnumerable<EmployeeDto> GetAll()
        {
            var employees = _employeeRepository.GetAll();
            if (!employees.Any())
            {
                return Enumerable.Empty<EmployeeDto>();
            }

            var employeeDtos = new List<EmployeeDto>();
            foreach (var employee in employees)
            {
                employeeDtos.Add((EmployeeDto)employee);
            }

            return employeeDtos; // employee is found;
        }

        public EmployeeDto? GetByGuid(Guid guid)
        {
            var employeeDto = _employeeRepository.GetByGuid(guid);
            if (employeeDto is null)
            {
                return null;
            }

            return (EmployeeDto)employeeDto;
        }

        public EmployeeDto? Create(NewEmployeeDto newemployeeDto)
        {
            var employeeDto = _employeeRepository.Create(newemployeeDto);
            if (employeeDto is null)
            {
                return null;
            }

            return (EmployeeDto)employeeDto;
        }

        public int Update(EmployeeDto employeeDto)
        {
            var employee = _employeeRepository.GetByGuid(employeeDto.Guid);
            if (employee is null)
            {
                return -1; // employee is null or not found;
            }

            Employee toUpdate = employeeDto;
            toUpdate.CreatedDate = employee.CreatedDate;
            var result = _employeeRepository.Update(toUpdate);

            return result ? 1 // employee is updated;
                : 0; // employee failed to update;
        }

        public int Delete(Guid guid)
        {
            var employee = _employeeRepository.GetByGuid(guid);
            if (employee is null)
            {
                return -1; // employee is null or not found;
            }

            var result = _employeeRepository.Delete(employee);

            return result ? 1 // employee is deleted;
                : 0; // employee failed to delete;
        }
    }
}
