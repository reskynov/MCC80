using API.Contracts;
using API.DTOs.Rooms;
using API.Models;

namespace API.Services
{
    public class RoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public RoomService(IRoomRepository roomRepository, IBookingRepository bookingRepository, IEmployeeRepository employeeRepository)
        {
            _roomRepository = roomRepository;
            _bookingRepository = bookingRepository;
            _employeeRepository = employeeRepository;
        }

        public IEnumerable<RoomDto> GetAll()
        {
            var rooms = _roomRepository.GetAll();
            if (!rooms.Any())
            {
                return Enumerable.Empty<RoomDto>();
            }

            var roomDtos = new List<RoomDto>();
            foreach (var room in rooms)
            {
                roomDtos.Add((RoomDto)room);
            }

            return roomDtos; // room is found;
        }

        public RoomDto? GetByGuid(Guid guid)
        {
            var roomDto = _roomRepository.GetByGuid(guid);
            if (roomDto is null)
            {
                return null;
            }

            return (RoomDto)roomDto;
        }

        public RoomDto? Create(NewRoomDto newRoomDto)
        {
            var roomDto = _roomRepository.Create(newRoomDto);
            if (roomDto is null)
            {
                return null;
            }

            return (RoomDto)roomDto;
        }

        public int Update(RoomDto roomDto)
        {
            var room = _roomRepository.GetByGuid(roomDto.Guid);
            if (room is null)
            {
                return -1; // room is null or not found;
            }

            Room toUpdate = roomDto;
            toUpdate.CreatedDate = room.CreatedDate;
            var result = _roomRepository.Update(toUpdate);

            return result ? 1 // room is updated;
                : 0; // room failed to update;
        }

        public int Delete(Guid guid)
        {
            var room = _roomRepository.GetByGuid(guid);
            if (room is null)
            {
                return -1; // room is null or not found;
            }

            var result = _roomRepository.Delete(room);

            return result ? 1 // room is deleted;
                : 0; // room failed to delete;
        }

        public IEnumerable<BookedRoomTodayDto> GetAllBookedRoomToday()
        {
            var today = DateTime.Today.ToString("dd-MM-yyyy");
            var bookedRoomsToday = (from booking in _bookingRepository.GetAll()
                            join employee in _employeeRepository.GetAll() on booking.EmployeeGuid equals employee.Guid
                            join room in _roomRepository.GetAll() on booking.RoomGuid equals room.Guid
                            where booking.StartDate.ToString("dd-MM-yyyy") == today
                            select new BookedRoomTodayDto
                            {
                                BookingGuid = booking.Guid,
                                RoomName = room.Name,
                                Status = booking.Status,
                                Floor = room.Floor,
                                BookedBy = employee.FirstName + " " + employee.LastName
                            });


            if (!bookedRoomsToday.Any() || bookedRoomsToday is null)
            {
                return Enumerable.Empty<BookedRoomTodayDto>();
            }

            return bookedRoomsToday; // room is found;
        }
    }
}

