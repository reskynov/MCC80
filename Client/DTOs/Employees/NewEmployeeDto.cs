using Client.Models;
using Client.Utilities.Enums;
using Client.Models;

namespace Client.DTOs.Employees
{
    public class NewEmployeeDto
    {
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public GenderLevel Gender { get; set; }
        public DateTime HiringDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public static implicit operator Employee(NewEmployeeDto newEmployeeDto)
        {


            return new Employee
            {
                Guid = Guid.NewGuid(),
                FirstName = newEmployeeDto.FirstName,
                LastName = newEmployeeDto.LastName,
                BirthDate = newEmployeeDto.BirthDate,
                Gender = newEmployeeDto.Gender,
                HiringDate = newEmployeeDto.HiringDate,
                Email = newEmployeeDto.Email,
                PhoneNumber = newEmployeeDto.PhoneNumber,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
        }
    }
}
