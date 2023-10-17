using Flight_Planner.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Flight_Planner.Data
{
    public interface IFlightPlannerDBContext
    {
        public DbSet<Flight> Flight { get; set; }

        public DbSet<Airport> Airport { get; set; }

        int SaveChanges();

        DbSet<T> Set<T>() where T : class;

        EntityEntry<T> Entry<T>(T entity) where T: class;
    }
}
