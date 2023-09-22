using Flight_Planner.Models;

namespace Flight_Planner
{
    public class FlightPage
    {
        private List<Flight> _listOfFlights;
        public int Page { get; set; }

        public int TotalItems { get; set; }

        public Flight[] Items => _listOfFlights.ToArray();

        public FlightPage()
        {
            _listOfFlights = new List<Flight>();
        }

        public void AddFlight(Flight item)
        {
            _listOfFlights.Add(item);
        }
    }
}
