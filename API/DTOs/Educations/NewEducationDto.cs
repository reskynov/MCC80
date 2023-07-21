﻿using API.DTOs.AccountRoles;
using API.Models;

namespace API.DTOs.Educations
{
    public class NewEducationDto
    {
        public string Major { get; set; }
        public string Degree { get; set; }
        public float GPA { get; set; }
        public Guid UniversityGuid { get; set; }

        public static implicit operator Education(NewEducationDto newEducationDto)
        {
            return new Education
            {
                Guid = Guid.NewGuid(),
                Major = newEducationDto.Major,
                Degree = newEducationDto.Degree,
                GPA = newEducationDto. GPA,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
        }
    }
}
