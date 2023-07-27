using API.Utilities.Enums;

namespace API.DTOs.Bookings
{
    public class DetailBookingDto
    {
        //Booking
        public Guid BookingGuid { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public StatusLevel Status { get; set; }
        public string Remark { get; set; }

        //Room
        public string RoomName { get; set; }

        //Employee
        public string BookingNIK { get; set; }
        public string BookingBy { get; set;}


    }
}
