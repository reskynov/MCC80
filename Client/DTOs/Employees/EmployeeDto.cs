using Client.Models;
using Client.Utilities.Enums;
using Client.Models;

namespace Client.DTOs.Employees
{
    public class EmployeeDto
    {
        public Guid Guid { get; set; }
        public string NIK { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public GenderLevel Gender { get; set; }
        public DateTime HiringDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        //konversi secara langsung
        public static implicit operator Employee(EmployeeDto EmployeeDto)
        {
            return new Employee
            {
                Guid = EmployeeDto.Guid,
                NIK = EmployeeDto.NIK,
                FirstName = EmployeeDto.FirstName,
                LastName = EmployeeDto.LastName,
                BirthDate = EmployeeDto.BirthDate,
                Gender = EmployeeDto.Gender,
                HiringDate = EmployeeDto.HiringDate,
                Email = EmployeeDto.Email,
                PhoneNumber = EmployeeDto.PhoneNumber,
                ModifiedDate = DateTime.Now
            };
        }

        //konversi dengan casting
        public static explicit operator EmployeeDto(Employee employee)
        {
            return new EmployeeDto
            {
                Guid = employee.Guid,
                NIK = employee.NIK,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                BirthDate = employee.BirthDate,
                Gender = employee.Gender,
                HiringDate = employee.HiringDate,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
            };
        }
    }
}