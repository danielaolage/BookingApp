using BookingApp.Passenger.Dtos;
using BookingApp.Core.CQRS;

namespace BookingApp.Passenger.Application.GetPassengerById
{
    public record GetPassengerByIdQuery(long Id) : IQuery<PassengerResponseDto>;
    
}
