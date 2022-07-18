using BookingApp.Passenger;
using BookingApp.Passenger.Data;
using BookingApp.Bus;
using BookingApp.Core.Generator;
using BookingApp.Core.Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;


builder.Services.AddControllers();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddDbContext<PassengerDbContext>(options =>
                    options.UseNpgsql(
                          configuration.GetConnectionString("DefaultConnection"),
                         x => x.MigrationsAssembly(typeof(PassengerDbContext).Assembly.GetName().Name)));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(typeof(PassengerRoot).Assembly);
builder.Services.AddCustomMapster(typeof(PassengerRoot).Assembly);
builder.Services.AddCustomMassTransit(configuration, typeof(PassengerRoot).Assembly);

SnowFlakeIdGenerator.Configure(2);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
