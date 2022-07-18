using BookingApp.Booking_API.DTOs;
using BookingApp.Core.CQRS;

namespace BookingApp.Booking_API.Application.CreateBooking
{
    public record CreateBookingCommand(long PassengerId, long FlightId, string Description) : ICommand<CreateReservationResponseDto>
    {
        public Guid Id { get; init; } = Guid.NewGuid();
    }
}
