using Flight_Planner.Core.Models;
using Flight_Planner.Core.Services;
using Flight_Planner.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight_Planner.Services
{
    public class AirportService : EntityService<Airport>, IAirportService
    {
        public AirportService(IFlightPlannerDBContext context) : base(context)
        {
        }

        public List<Airport> SearchAirports(string keyword)
        {
            var sanitizedKeyword = keyword.Trim().ToLower();
            return _context.Airport
                    .Where(airport =>
                        airport.Country.ToLower().Contains(sanitizedKeyword) ||
                        airport.City.ToLower().Contains(sanitizedKeyword) ||
                        airport.Code.ToLower().Contains(sanitizedKeyword))
                    .ToList();
        }
    }
}
