﻿using API.Contracts;
using API.DTOs.Educations;
using API.Models;
using API.Repositories;

namespace API.Services
{
    public class EducationService
    {
        private readonly IEducationRepository _educationRepository;

        public EducationService(IEducationRepository educationRepository)
        {
            _educationRepository = educationRepository;
        }

        public IEnumerable<EducationDto> GetAll()
        {
            var educations = _educationRepository.GetAll();
            if (!educations.Any())
            {
                return Enumerable.Empty<EducationDto>();
            }

            var educationDtos = new List<EducationDto>();
            foreach (var education in educations)
            {
                educationDtos.Add((EducationDto)education);
            }

            return educationDtos; // education is found;
        }

        public EducationDto? GetByGuid(Guid guid)
        {
            var educationDto = _educationRepository.GetByGuid(guid);
            if (educationDto is null)
            {
                return null;
            }

            return (EducationDto)educationDto;
        }

        public EducationDto? Create(NewEducationDto newEducationDto)
        {
            var educationDto = _educationRepository.Create(newEducationDto);
            if (educationDto is null)
            {
                return null;
            }

            return (EducationDto)educationDto;
        }

        public int Update(EducationDto educationDto)
        {
            var education = _educationRepository.GetByGuid(educationDto.Guid);
            if (education is null)
            {
                return -1; // education is null or not found;
            }

            Education toUpdate = educationDto;
            toUpdate.CreatedDate = education.CreatedDate;
            var result = _educationRepository.Update(toUpdate);

            return result ? 1 // education is updated;
                : 0; // education failed to update;
        }

        public int Delete(Guid guid)
        {
            var education = _educationRepository.GetByGuid(guid);
            if (education is null)
            {
                return -1; // education is null or not found;
            }

            var result = _educationRepository.Delete(education);

            return result ? 1 // education is deleted;
                : 0; // education failed to delete;
        }
    }
}
