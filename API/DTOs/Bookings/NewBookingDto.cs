using API.DTOs.Accounts;
using API.Models;
using API.Utilities.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.DTOs.Bookings
{
    public class NewBookingDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public StatusLevel Status { get; set; }
        public string Remark { get; set; }
        public Guid RoomGuid { get; set; }
        public Guid EmployeeGuid { get; set; }

        public static implicit operator Booking(NewBookingDto newBookingDto)
        {
            return new Booking
            {
                Guid = Guid.NewGuid(),
                StartDate = newBookingDto.StartDate,
                EndDate = newBookingDto.EndDate,
                Status = newBookingDto.Status,
                Remark = newBookingDto.Remark,
                RoomGuid = newBookingDto.RoomGuid,
                EmployeeGuid = newBookingDto.EmployeeGuid,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
        }
    }
}
