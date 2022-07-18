﻿using BookingApp.Flight.Domain.Seats;

namespace BookingApp.Flight.API.Dtos
{
    public class SeatResponseDto
    {
        public long Id { get; set; }
        public string SeatNumber { get; init; }
        public SeatType Type { get; init; }
        public SeatClass Class { get; init; }
        public long FlightId { get; init; }
    }
}
