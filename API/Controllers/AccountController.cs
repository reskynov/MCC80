﻿using API.Services;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using API.DTOs.Accounts;
using API.DTOs.Universities;
using API.Utilities.Handlers;
using System.Net;

namespace API.Controllers
{
    [ApiController]
    [Route("api/accounts")]
    public class AccountController : Controller
    {
        private readonly AccountService _accountService;

        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _accountService.GetAll();
            if (!result.Any())
            {
                return NotFound(new ResponseHandler<AccountDto>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "data not found"
                });
            }

            return Ok(new ResponseHandler<IEnumerable<AccountDto>>
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
            var result = _accountService.GetByGuid(guid);
            if (result is null)
            {
                return NotFound(new ResponseHandler<AccountDto>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "data not found"
                });
            }

            return Ok(new ResponseHandler<AccountDto>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success retrieve data",
                Data = result
            });
        }

        [HttpPost]
        public IActionResult Insert(NewAccountDto newAccountDto)
        {
            var result = _accountService.Create(newAccountDto);
            if (result is null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseHandler<AccountDto>
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.InternalServerError.ToString(),
                    Message = "Internal server error"
                });
            }

            return Ok(new ResponseHandler<AccountDto>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success retrieve data",
                Data = result
            });
        }

        [HttpPut]
        public IActionResult Update(AccountDto accountDto)
        {
            var result = _accountService.Update(accountDto);

            if (result is -1)
            {
                return NotFound(new ResponseHandler<AccountDto>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "data not found"
                });
            }

            if (result is 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseHandler<AccountDto>
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.InternalServerError.ToString(),
                    Message = "Internal server error"
                });
            }

            return Ok(new ResponseHandler<AccountDto>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success retrieve data"
            });
        }

        [HttpDelete]
        public IActionResult Delete(Guid guid)
        {
            var result = _accountService.Delete(guid);

            if (result is -1)
            {
                return NotFound(new ResponseHandler<AccountDto>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "data not found"
                });
            }

            if (result is 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseHandler<AccountDto>
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.InternalServerError.ToString(),
                    Message = "Internal server error"
                });
            }

            return Ok(new ResponseHandler<AccountDto>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success retrieve data"
            });
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto loginDto)
        {
            var result = _accountService.Login(loginDto);

            if (result is 0)
            {
                return NotFound(new ResponseHandler<LoginDto>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Email or Password is incorrect"
                });
            }

            return Ok(new ResponseHandler<LoginDto>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Login Success"
            });
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDto registerDto)
        {
            var result = _accountService.Register(registerDto);

            if (result is null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseHandler<AccountDto>
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.InternalServerError.ToString(),
                    Message = "Error occurred when registering"
                });
            }

            return Ok(new ResponseHandler<RegisterDto>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Register Success",
                Data = result
            });
        }
    }
}
