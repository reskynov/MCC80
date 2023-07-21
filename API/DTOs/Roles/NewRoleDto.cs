using API.Models;

namespace API.DTOs.Roles
{
    public class NewRoleDto
    {
        public string Name { get; set; }

        public static implicit operator Role(NewRoleDto newRoleDto)
        {
            return new Role
            {
                Guid = Guid.NewGuid(),
                Name = newRoleDto.Name,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
        }
    }
}
