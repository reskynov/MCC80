using API.DTOs.Educations;
using FluentValidation;

namespace API.Utilities.Validations.Educations
{
    public class EducationValidator : AbstractValidator<EducationDto>
    {
        public EducationValidator()
        {
            RuleFor(e => e.Guid)
                .NotEmpty();

            RuleFor(e => e.Major)
                .NotEmpty();

            RuleFor(e => e.Degree)
                .NotEmpty();

            RuleFor(e => e.GPA)
                .NotEmpty();

            RuleFor(e => e.UniversityGuid)
                .NotEmpty();
        }
    }
}
