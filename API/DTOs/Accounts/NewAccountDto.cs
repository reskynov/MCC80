﻿using API.DTOs.AccountRoles;
using API.Models;

namespace API.DTOs.Accounts
{
    public class NewAccountDto
    {
        public Guid Guid { get; set; }
        public int OTP { get; set; }
        public bool IsUsed { get; set; }
        public DateTime ExpiredTime { get; set; }

        public static implicit operator Account(NewAccountDto newAccountDto)
        {
            return new Account
            {
                Guid = newAccountDto.Guid,
                OTP = newAccountDto.OTP,
                IsUsed = newAccountDto.IsUsed,
                ExpiredDate = newAccountDto.ExpiredTime,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
        }
    }
}
