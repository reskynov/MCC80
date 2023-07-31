using API.Services;
using API.Models;
using API.Repositories;
using Microsoft.AspNetCore.Mvc;
using API.DTOs.Bookings;
using API.DTOs.AccountRoles;
using API.Utilities.Handlers;
using System.Net;
using API.DTOs.Rooms;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [ApiController]
    [Route("api/bookings")]
    [Authorize]
    public class BookingController : Controller
    {
        private readonly BookingService _bookingService;

        public BookingController(BookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _bookingService.GetAll();
            if (!result.Any())
            {
                return NotFound(new ResponseHandler<BookingDto>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "data not found"
                });
            }

            return Ok(new ResponseHandler<IEnumerable<BookingDto>>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success retrieve data",
                Data = result
            });
        }

        [HttpGet("{guid}")]
        public IActionResult GetByGuid(Guid guid)
        {
            var result = _bookingService.GetByGuid(guid);
            if (result is null)
            {
                return NotFound(new ResponseHandler<BookingDto>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "guid not found"
                });
            }

            return Ok(new ResponseHandler<BookingDto>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success retrieve data",
                Data = result
            });
        }

        [HttpPost]
        public IActionResult Insert(NewBookingDto newBookingDto)
        {
            var result = _bookingService.Create(newBookingDto);
            if (result is null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseHandler<BookingDto>
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.InternalServerError.ToString(),
                    Message = "Internal server error"
                });
            }

            return Ok(new ResponseHandler<BookingDto>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success retrieve data",
                Data = result
            });
        }

        [HttpPut]
        public IActionResult Update(BookingDto bookingDto)
        {
            var result = _bookingService.Update(bookingDto);

            if (result is -1)
            {
                return NotFound(new ResponseHandler<BookingDto>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "data not found"
                });
            }

            if (result is 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseHandler<BookingDto>
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.InternalServerError.ToString(),
                    Message = "Internal server error"
                });
            }

            return Ok(new ResponseHandler<BookingDto>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success retrieve data"
            });
        }

        [HttpDelete]
        public IActionResult Delete(Guid guid)
        {
            var result = _bookingService.Delete(guid);

            if (result is -1)
            {
                return NotFound(new ResponseHandler<BookingDto>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "data not found"
                });
            }

            if (result is 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseHandler<BookingDto>
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.InternalServerError.ToString(),
                    Message = "Internal server error"
                });
            }

            return Ok(new ResponseHandler<BookingDto>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success delete data"
            });
        }

        [HttpGet("detail")]
        [AllowAnonymous]
        public IActionResult GetAllDetailBooking()
        {
            var result = _bookingService.GetAllDetailBooking();
            if (!result.Any())
            {
                return NotFound(new ResponseHandler<DetailBookingDto>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "data not found"
                });
            }

            return Ok(new ResponseHandler<IEnumerable<DetailBookingDto>>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success retrieve data",
                Data = result
            });
        }

        [HttpGet("detail/{guid}")]
        [AllowAnonymous]
        public IActionResult GetAllDetailBooking(Guid guid)
        {
            var result = _bookingService.GetDetailBookingByGuid(guid);
            if (result is null)
            {
                return NotFound(new ResponseHandler<DetailBookingDto>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "data not found"
                });
            }

            return Ok(new ResponseHandler<DetailBookingDto>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success retrieve data",
                Data = result
            });
        }

        [HttpGet("free-rooms-today")]
        [AllowAnonymous]
        public IActionResult FreeRoomsToday()
        {
            var result = _bookingService.GetFreeRoomsToday();
            if (result is null)
            {
                return NotFound(new ResponseHandler<RoomDto>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Room not found"
                });
            }
            return Ok(
            new ResponseHandler<IEnumerable<RoomDto>>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success retrieving data",
                Data = result
            });
        }

        [HttpGet("booked-time-length")]
        [AllowAnonymous]
        public IActionResult BookingLength()
        {
            var result = _bookingService.BookingLength();
            if (!result.Any())
            {
                return NotFound(new ResponseHandler<BookingLengthDto>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Room not found"
                });
            }
            return Ok(
            new ResponseHandler<IEnumerable<BookingLengthDto>>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success retrieving data",
                Data = result
            });
        }
    }
}
