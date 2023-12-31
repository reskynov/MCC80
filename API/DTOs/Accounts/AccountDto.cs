﻿using API.Models;

namespace API.DTOs.Accounts
{
    public class AccountDto
    {
        public Guid Guid { get; set; }
        public string Password { get; set; }
        public int OTP { get; set; }
        public bool IsUsed { get; set; }
        public DateTime ExpiredTime { get; set; }

        public static implicit operator Account(AccountDto accountDto)
        {
            return new Account
            {
                Guid = accountDto.Guid,
                Password = accountDto.Password,
                OTP = accountDto.OTP,
                IsUsed = accountDto.IsUsed,
                ExpiredDate = accountDto.ExpiredTime,
                ModifiedDate = DateTime.Now
            };
        }

        public static explicit operator AccountDto(Account account)
        {
            return new AccountDto
            {
                Guid = account.Guid,
                Password = account.Password,
                OTP = account.OTP,
                IsUsed = account.IsUsed,
                ExpiredTime = account.ExpiredDate
            };
        }
    }
}
