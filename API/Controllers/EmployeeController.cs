﻿using API.Contracts;
using API.DTOs.Educations;
using API.DTOs.Employees;
using API.Models;
using API.Services;
using API.Utilities.Handlers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeeController : Controller
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _employeeService.GetAll();
            if (!result.Any())
            {
                return NotFound(new ResponseHandler<EmployeeDto>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "data not found"
                });
            }

            return Ok(new ResponseHandler<EmployeeDto>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success retrieve data"
            });
        }

        [HttpGet("{guid}")]
        public IActionResult GetByGuid(Guid guid)
        {
            var result = _employeeService.GetByGuid(guid);
            if (result is null)
            {
                return NotFound(new ResponseHandler<EmployeeDto>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "guid not found"
                });
            }

            return Ok(new ResponseHandler<EmployeeDto>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success retrieve data"
            });
        }

        [HttpPost]
        public IActionResult Insert(NewEmployeeDto newEmployeeDto)
        {
            var result = _employeeService.Create(newEmployeeDto);
            if (result is null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseHandler<EmployeeDto>
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.InternalServerError.ToString(),
                    Message = "Internal server error"
                });
            }

            return Ok(new ResponseHandler<EmployeeDto>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success retrieve data"
            });
        }

        [HttpPut]
        public IActionResult Update(EmployeeDto employeeDto)
        {
            var result = _employeeService.Update(employeeDto);

            if (result is -1)
            {
                return NotFound(new ResponseHandler<EmployeeDto>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "data not found"
                });
            }

            if (result is 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseHandler<EmployeeDto>
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.InternalServerError.ToString(),
                    Message = "Internal server error"
                });
            }

            return Ok(new ResponseHandler<EmployeeDto>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success retrieve data"
            });
        }

        [HttpDelete]
        public IActionResult Delete(Guid guid)
        {
            var result = _employeeService.Delete(guid);

            if (result is -1)
            {
                return NotFound(new ResponseHandler<EmployeeDto>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "data not found"
                });
            }

            if (result is 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseHandler<EmployeeDto>
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.InternalServerError.ToString(),
                    Message = "Internal server error"
                });
            }

            return Ok(new ResponseHandler<EmployeeDto>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success retrieve data"
            });
        }
    }
}
