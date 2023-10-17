using Flight_Planner.Core.Services;
using Flight_Planner.Data;

namespace Flight_Planner.Services
{
    public class CleanupService : DbService, ICleanupService
    {
        public CleanupService(IFlightPlannerDBContext context) : base(context)
        {
        }

        public void CleanDatabase()
        {
            _context.Flight.RemoveRange(_context.Flight);
            _context.Airport.RemoveRange(_context.Airport);
            _context.SaveChanges();
        }
    }
}
