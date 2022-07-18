using BookingApp.Passenger.Dtos;
using BookingApp.Passenger.Passengers.Models;
using BookingApp.Core.CQRS;
using BookingApp.Core.Generator;

namespace BookingApp.Passenger.Application.CompleteRegisterPassenger
{
    public record CompleteRegisterPassengerCommand(string PassportNumber, PassengerType PassengerType, int Age) : ICommand<PassengerResponseDto>
    {
        public long Id { get; set; } = SnowFlakeIdGenerator.NewId();
    }
}
