using Flight_Planner.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Flight_Planner.Data
{
    public class FlightPlannerDBContext : DbContext, IFlightPlannerDBContext
    {
        public FlightPlannerDBContext(DbContextOptions<FlightPlannerDBContext> options) : base(options) { }

        public DbSet<Flight> Flight { get; set; }

        public DbSet<Airport> Airport { get; set; }
    }
}
