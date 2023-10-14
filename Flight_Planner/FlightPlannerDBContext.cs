using Flight_Planner.Models;
using Microsoft.EntityFrameworkCore;

namespace Flight_Planner
{
    public class FlightPlannerDBContext : DbContext
    {
        public FlightPlannerDBContext(DbContextOptions<FlightPlannerDBContext> options) : base(options) { }

        public DbSet<Flight> Flight { get; set; }

        public DbSet<Airport> Airport { get; set; }

    }
}
