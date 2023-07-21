﻿using API.Contracts;
using API.DTOs.Bookings;
using API.Models;
using API.Repositories;

namespace API.Services
{
    public class BookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public IEnumerable<BookingDto> GetAll()
        {
            var bookings = _bookingRepository.GetAll();
            if (!bookings.Any())
            {
                return Enumerable.Empty<BookingDto>();
            }

            var bookingDtos = new List<BookingDto>();
            foreach (var booking in bookings)
            {
                bookingDtos.Add((BookingDto)booking);
            }

            return bookingDtos; // booking is found;
        }

        public BookingDto? GetByGuid(Guid guid)
        {
            var bookingDto = _bookingRepository.GetByGuid(guid);
            if (bookingDto is null)
            {
                return null;
            }

            return (BookingDto)bookingDto;
        }

        public BookingDto? Create(NewBookingDto newBookingDto)
        {
            var bookingDto = _bookingRepository.Create(newBookingDto);
            if (bookingDto is null)
            {
                return null;
            }

            return (BookingDto)bookingDto;
        }

        public int Update(BookingDto bookingDto)
        {
            var booking = _bookingRepository.GetByGuid(bookingDto.Guid);
            if (booking is null)
            {
                return -1; // booking is null or not found;
            }

            Booking toUpdate = bookingDto;
            toUpdate.CreatedDate = booking.CreatedDate;
            var result = _bookingRepository.Update(toUpdate);

            return result ? 1 // booking is updated;
                : 0; // booking failed to update;
        }

        public int Delete(Guid guid)
        {
            var booking = _bookingRepository.GetByGuid(guid);
            if (booking is null)
            {
                return -1; // booking is null or not found;
            }

            var result = _bookingRepository.Delete(booking);

            return result ? 1 // booking is deleted;
                : 0; // booking failed to delete;
        }
    }
}
