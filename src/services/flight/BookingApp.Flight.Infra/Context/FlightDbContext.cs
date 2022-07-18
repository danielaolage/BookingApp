using BookingApp.Flight.Domain.Aircrafts.Models;
using BookingApp.Flight.Domain.Airports;
using BookingApp.Flight.Domain.Seats;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BookingApp.Flight.Infra.Context
{
    public class FlightDbContext : DbContext
    {
        public FlightDbContext(DbContextOptions<FlightDbContext> options) : base(
             options)
        {
        }

        public DbSet<Domain.Flights.Flight> Flights => Set<Domain.Flights.Flight>();
        public DbSet<Airport> Airports => Set<Airport>();
        public DbSet<Aircraft> Aircraft => Set<Aircraft>();
        public DbSet<Seat> Seats => Set<Seat>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }

    }
}
