using API.Contracts;
using API.DTOs.Employees;
using API.DTOs.Rooms;
using API.Models;
using API.Repositories;
using API.Utilities.Handlers;
using System.Collections.Generic;

namespace API.Services
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEducationRepository _educationRepository;
        private readonly IUniversityRepository _universityRepository;

        public EmployeeService(IEmployeeRepository employeeRepository, IEducationRepository educationRepository, IUniversityRepository universityRepository)
        {
            _employeeRepository = employeeRepository;
            _educationRepository = educationRepository;
            _universityRepository = universityRepository;
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

        public EmployeeDto? Create(NewEmployeeDto newEmployeeDto)
        {
            Employee employeeToCreate = newEmployeeDto;
            employeeToCreate.NIK = GenerateHandler.Nik(_employeeRepository.GetLastNik());

            var employee = _employeeRepository.Create(employeeToCreate);
            if (employeeToCreate is null)
            {
                return null;
            }
            
            return (EmployeeDto) employeeToCreate;
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

        public IEnumerable<EmployeeDetailDto> GetAllEmployeeDetail()
        {
            var result = from employee in _employeeRepository.GetAll()
                         join education in _educationRepository.GetAll() on employee.Guid equals education.Guid
                         join university in _universityRepository.GetAll() on education.UniversityGuid equals
                             university.Guid
                         select new EmployeeDetailDto
                         {
                             EmployeeGuid = employee.Guid,
                             NIK = employee.NIK,
                             FullName = employee.FirstName + " " + employee.LastName,
                             BirthDate = employee.BirthDate,
                             Gender = employee.Gender,
                             HiringDate = employee.HiringDate,
                             Email = employee.Email,
                             PhoneNumber = employee.PhoneNumber,
                             Major = education.Major,
                             Degree = education.Degree,
                             GPA = education.GPA,
                             UniversityName = university.Name
                         };
            if (result is null)
            {
                return Enumerable.Empty<EmployeeDetailDto>();
            }
            return result; // employeeDetail is found;
        }

        public EmployeeDetailDto? GetEmployeeDetailByGuid(Guid guid)
        {
            var result = GetAllEmployeeDetail().SingleOrDefault(e => e.EmployeeGuid == guid);
            if (result is null)
            {
                return null;
            }

            return result;
        }
    }
}
