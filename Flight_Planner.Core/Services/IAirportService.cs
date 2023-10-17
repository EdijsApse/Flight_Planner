using Flight_Planner.Core.Models;

namespace Flight_Planner.Core.Services
{
    public interface IAirportService : IEntityService<Airport>
    {
        List<Airport> SearchAirports(string keyword);
    }
}
