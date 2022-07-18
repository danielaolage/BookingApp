using BookingApp.Bus;
using BookingApp.Core.Data;
using BookingApp.Core.Mapster;
using BookingApp.Flight.API;
using BookingApp.Flight.API.Extension;
using BookingApp.Flight.Infra.Context;
using BookingApp.Flight.Infra.Seed;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();


AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddDbContext<FlightDbContext>(options =>
                    options.UseNpgsql(
                          configuration.GetConnectionString("DefaultConnection"),
                         x => x.MigrationsAssembly(typeof(FlightDbContext).Assembly.GetName().Name)));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IDataSeeder, FlightDataSeeder>();
builder.Services.AddHttpContextAccessor();

builder.Services.AddCustomMassTransit(configuration, typeof(FlightRoot).Assembly);
//SnowFlakIdGenerator.Configure(1);

builder.Services.AddMediatR(typeof(FlightRoot).Assembly);
builder.Services.AddCustomMapster(typeof(FlightRoot).Assembly);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseMigrations();

app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
