using BookingApp.Core.CQRS;
using BookingApp.Flight.API.Dtos;

namespace BookingApp.Flight.API.Application.GetAvailableSeats
{
    public record GetAvailableSeatsQuery(long FlightId) : IQuery<IEnumerable<SeatResponseDto>>;
}
