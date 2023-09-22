using Flight_Planner.Models;

namespace Flight_Planner
{
    public class FlightStorage
    {
        private static List<Flight> _listOfFlights = new List<Flight>();

        private static int _flightId = 0;

        private static readonly object _balanceLock = new object();

        public void AddFlight(Flight flight)
        {
            lock(_balanceLock) {
                flight.Id = _flightId++;
                _listOfFlights.Add(flight);
            }
        }

        public void ClearFlights()
        {
            lock (_balanceLock)
            {
                _listOfFlights.Clear();
            }
        }

        public bool FlightExists(Flight flight)
        {
            lock (_balanceLock)
            {
                return _listOfFlights.Any(existingFlight =>
                {
                    return existingFlight.From.Equals(flight.From) && existingFlight.To.Equals(flight.To) && existingFlight.DepartureTime.Equals(flight.DepartureTime);
                });
            }
        }

        public Flight GetFlight(int flightId)
        {
            lock (_balanceLock)
            {
                return _listOfFlights.FirstOrDefault(flight => flight.Id == flightId);
            }
        }

        public void DeleteFlight(int flightId)
        {
            lock (_balanceLock)
            {
                var flight = GetFlight(flightId);
                _listOfFlights.Remove(flight);
            }
        }

        public List<Airport> SearchAirports(string keyword)
        {
            lock (_balanceLock)
            {
                var listOfAirports = _listOfFlights.Aggregate(new List<Airport>(), (currentList, flight) => {

                    if (AirportMatchesSearchKeyword(flight.From, keyword) && !currentList.Any(airport => airport.Equals(flight.From))) currentList.Add(flight.From);

                    if (AirportMatchesSearchKeyword(flight.To, keyword) && !currentList.Any(airport => airport.Equals(flight.To))) currentList.Add(flight.To);

                    return currentList;
                });

                return listOfAirports;
            }
        }

        public FlightPage GetFlights(FlightTicket ticket)
        {
            lock (_balanceLock)
            {
                DateTime ticketDepartureTime;
                DateTime.TryParse(ticket.DepartureDate, out ticketDepartureTime);

                var filteredFlights = _listOfFlights.Where(flight =>
                {
                    var flightDateTime = DateTime.Parse(flight.DepartureTime);

                    var departureDatesMatch =
                        ticketDepartureTime.Day == flightDateTime.Day &&
                        ticketDepartureTime.Month == flightDateTime.Month &&
                        ticketDepartureTime.Year == flightDateTime.Year;

                    return flight.From.Code.Equals(ticket.From) && flight.To.Code.Equals(ticket.To) && departureDatesMatch;
                }).ToList();

                var flightPagination = new FlightPagination(filteredFlights);

                return flightPagination.GetPage();
            }
        }

        private bool AirportMatchesSearchKeyword(Airport airport, string keyword)
        {
            var santizedkeyword = keyword.ToLower().Trim();

            return airport.Code.ToLower().Contains(santizedkeyword) || airport.Country.ToLower().Contains(santizedkeyword) || airport.City.ToLower().Contains(santizedkeyword);
        }
    }
}
