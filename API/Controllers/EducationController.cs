using API.Contracts;
using API.DTOs.Bookings;
using API.DTOs.Educations;
using API.Models;
using API.Services;
using API.Utilities.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    [ApiController]
    [Route("api/educations")]
    [Authorize(Roles = "Employee")]
    public class EducationController : Controller
    {
        private readonly EducationService _educationService;

        public EducationController(EducationService educationService)
        {
            _educationService = educationService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _educationService.GetAll();
            if (!result.Any())
            {
                return NotFound(new ResponseHandler<EducationDto>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "data not found"
                });
            }

            return Ok(new ResponseHandler<IEnumerable<EducationDto>>
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
            var result = _educationService.GetByGuid(guid);
            if (result is null)
            {
                return NotFound(new ResponseHandler<EducationDto>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "guid not found"
                });
            }

            return Ok(new ResponseHandler<EducationDto>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success retrieve data",
                Data = result
            });
        }

        [HttpPost]
        public IActionResult Insert(NewEducationDto newEducationDto)
        {
            var result = _educationService.Create(newEducationDto);
            if (result is null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseHandler<EducationDto>
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.InternalServerError.ToString(),
                    Message = "Internal server error"
                });
            }

            return Ok(new ResponseHandler<EducationDto>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success retrieve data",
                Data = result
            });
        }

        [HttpPut]
        public IActionResult Update(EducationDto educationDto)
        {
            var result = _educationService.Update(educationDto);
            if (result is -1)
            {
                return NotFound(new ResponseHandler<EducationDto>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "data not found"
                });
            }

            if (result is 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseHandler<EducationDto>
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.InternalServerError.ToString(),
                    Message = "Internal server error"
                });
            }

            return Ok(new ResponseHandler<EducationDto>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success retrieve data"
            });
        }

        [HttpDelete]
        public IActionResult Delete(Guid guid)
        {
            var result = _educationService.Delete(guid);

            if (result is -1)
            {
                return NotFound(new ResponseHandler<EducationDto>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "data not found"
                });
            }

            if (result is 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseHandler<EducationDto>
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.InternalServerError.ToString(),
                    Message = "Internal server error"
                });
            }

            return Ok(new ResponseHandler<EducationDto>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success delete data"
            });
        }
    }
}
