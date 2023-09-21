using Flight_Planner.Models;

namespace Flight_Planner
{
    public class FlightStorage
    {
        private static List<Flight> _listOfFlights = new List<Flight>();
        private static int _flightId = 0;

        public void AddFlight(Flight flight)
        {
            flight.Id = _flightId++;
            _listOfFlights.Add(flight);
        }

        public void ClearFlights()
        {
            _listOfFlights.Clear();
        }

        public bool FlightExists(Flight flight)
        {
            return _listOfFlights.Any(existingFlight =>
            {
                return existingFlight.From.Equals(flight.From) && existingFlight.To.Equals(flight.To) && existingFlight.DepartureTime.Equals(flight.DepartureTime);
            });
        }

        public Flight GetFlight(int flightId)
        {
            return _listOfFlights.FirstOrDefault(flight => flight.Id == flightId);
        }

        public void DeleteFlight(int flightId)
        {
            var flight = GetFlight(flightId);

            _listOfFlights.Remove(flight);
        }
    }
}
