using Flight_Planner.Core.Interfaces;
using Flight_Planner.Core.Models;
using Flight_Planner.Core.Services;
using Flight_Planner.Data;
using Flight_Planner.Handlers;
using Flight_Planner.Services;
using Flight_Planner.Validation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

namespace Flight_Planner
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var mapper = AutoMapperConfig.CreateMapper();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            builder.Services.AddDbContext<FlightPlannerDBContext>(options => {
                options.UseSqlServer(builder.Configuration.GetConnectionString("FlightPlanner"));
            });

            builder.Services.AddTransient<IFlightPlannerDBContext, FlightPlannerDBContext>();

            builder.Services.AddTransient<IDbService, DbService>();

            builder.Services.AddTransient<IEntityService<Airport>, EntityService<Airport>>();
            builder.Services.AddTransient<IEntityService<Flight>, EntityService<Flight>>();

            builder.Services.AddTransient<IFlightService, FlightService>();
            builder.Services.AddTransient<IAirportService, AirportService>();

            builder.Services.AddTransient<ICleanupService, CleanupService>();

            builder.Services.AddTransient<IFlightValidate, AirportValuesValidator>();
            builder.Services.AddTransient<IFlightValidate, FlightDateValidator>();
            builder.Services.AddTransient<IFlightValidate, FlightValuesValidator>();
            builder.Services.AddTransient<IFlightValidate, SameAirportValidator>();

            builder.Services.AddTransient<ITicketValidate, TicketAirportsValidator>();
            builder.Services.AddTransient<ITicketValidate, TicketValuesValidator>();

            builder.Services.AddSingleton(mapper);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}