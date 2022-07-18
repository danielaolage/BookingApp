using BookingApp.Core.CQRS;
using BookingApp.Flight.API.Dtos;

namespace BookingApp.Flight.API.Application.GetFlightById
{
    public record GetFlightByIdQuery(long Id) : IQuery<FlightResponseDto>;
}
