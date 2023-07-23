﻿using API.DTOs.AccountRoles;
using API.Models;

namespace API.DTOs.Educations
{
    public class NewEducationDto
    {
        public Guid Guid { get; set; }
        public string Major { get; set; }
        public string Degree { get; set; }
        public float GPA { get; set; }
        public Guid UniversityGuid { get; set; }

        public static implicit operator Education(NewEducationDto newEducationDto)
        {
            return new Education
            {
                Guid = newEducationDto.Guid,
                Major = newEducationDto.Major,
                Degree = newEducationDto.Degree,
                GPA = newEducationDto. GPA,
                UniversityGuid = newEducationDto.UniversityGuid,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
        }
    }
}
