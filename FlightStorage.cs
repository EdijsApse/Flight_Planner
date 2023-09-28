using Flight_Planner.Models;
using Microsoft.EntityFrameworkCore;

namespace Flight_Planner
{
    public class FlightStorage
    {
        private readonly FlightPlannerDBContext _context;

        private static readonly object _balanceLock = new object();

        public FlightStorage(FlightPlannerDBContext context)
        {
            _context = context;
        }

        public void AddFlight(Flight flight)
        {
            lock(_balanceLock) {
                _context.Flight.Add(flight);
                _context.SaveChanges();
            }
        }

        public void ClearFlights()
        {
            lock (_balanceLock)
            {
                _context.Flight.RemoveRange(_context.Flight);
                _context.Airport.RemoveRange(_context.Airport);
                _context.SaveChanges();
            }
        }

        public bool FlightExists(Flight flight)
        {
            lock (_balanceLock)
            {
                return _context.Flight
                    .Include(f => f.From)
                    .Include(f => f.To)
                    .Any(f =>
                        f.DepartureTime == flight.DepartureTime &&
                        f.ArrivalTime == flight.ArrivalTime &&
                        f.From.Code == flight.From.Code &&
                        f.To.Code == flight.To.Code
                    );
            }
        }

        public Flight GetFlight(int flightId)
        {
            lock (_balanceLock)
            {
                return _context.Flight
                    .Include(flight => flight.From)
                    .Include(flight => flight.To)
                    .FirstOrDefault(flight => flight.Id == flightId);
            }
        }

        public void DeleteFlight(int flightId)
        {
            lock (_balanceLock)
            {
                var flight = GetFlight(flightId);
                if (flight != null)
                {
                    _context.Flight.Remove(flight);
                    _context.SaveChanges();
                }
            }
        }

        public List<Airport> SearchAirports(string keyword)
        {
            lock (_balanceLock)
            {
                var sanitizedKeyword = keyword.ToLower().Trim();

                return _context.Airport
                    .Where(airport => 
                        airport.Country.ToLower().Contains(sanitizedKeyword) ||
                        airport.City.ToLower().Contains(sanitizedKeyword) ||
                        airport.Code.ToLower().Contains(sanitizedKeyword)
                    ).ToList();
            }
        }

        public FlightPage GetFlights(FlightTicket ticket)
        {
            lock (_balanceLock)
            {
                var filteredFlights = _context.Flight
                    .Include(flight => flight.From)
                    .Include(flight => flight.To)
                    .Where(flight =>
                        flight.From.Code.Equals(ticket.From) &&
                        flight.To.Code.Equals(ticket.To) &&
                        flight.DepartureTime.Contains(ticket.DepartureDate)
                        ).ToList();

                var flightPagination = new FlightPagination(filteredFlights);

                return flightPagination.GetPage();
            }
        }
    }
}
