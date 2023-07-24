using API.DTOs.Bookings;
using FluentValidation;

namespace API.Utilities.Validations.Bookings
{
    public class BookingValidator : AbstractValidator<BookingDto>
    {
        public BookingValidator()
        {
            RuleFor(b => b.StartDate)
                .NotEmpty()
                .GreaterThanOrEqualTo(DateTime.Now);

            RuleFor(b => b.EndDate)
                .NotEmpty()
                .GreaterThanOrEqualTo(DateTime.Now.AddDays(+1));

            RuleFor(b => b.Status)
                .NotNull()
                .IsInEnum();

            RuleFor(b => b.Remark)
                .NotEmpty();

            RuleFor(b => b.RoomGuid)
                .NotEmpty();

            RuleFor(b => b.EmployeeGuid)
                .NotEmpty();
        }
    }
}
