using Flight_Planner.Models;

namespace Flight_Planner
{
    public class FlightValidator
    {
        private Flight _flight;

        public List<string> Errors = new List<string>();

        public FlightValidator(Flight flight)
        {
            _flight = flight;

            ValidateFlight();
        }

        public bool HasErrors()
        {
            return Errors.Count > 0;
        }

        private void ValidateFlight()
        {
            ValidateAirport(_flight.From, "From");
            ValidateAirport(_flight.To, "To");
            ValidateUniqueAirports();
            ValidateCarrier();
            ValidateDepartureTime();
            ValidateArrivalTime();
            ValidateTravelingTime();
        }

        private void ValidateAirport(Airport airport, string type)
        {
            if (IsValidString(airport.Country)) Errors.Add($"Airport {type} Country is not valid!");

            if (IsValidString(airport.City)) Errors.Add($"Airport {type} City is not valid!");

            if (IsValidString(airport.Code)) Errors.Add($"Airport {type} Code is not valid!");
        }

        private void ValidateUniqueAirports()
        {
            var airportFrom = new Airport
            {
                Country = _flight.From.Country.ToLower().Trim(),
                City = _flight.From.City.ToLower().Trim(),
                Code = _flight.From.Code.ToLower().Trim(),
            };

            var airportTo = new Airport
            {
                Country = _flight.To.Country.ToLower().Trim(),
                City = _flight.To.City.ToLower().Trim(),
                Code = _flight.To.Code.ToLower().Trim(),
            };

            if (airportTo.Equals(airportFrom)) Errors.Add("Airport From and Airport To are the same!");
        }

        private void ValidateCarrier()
        {
            if (IsValidString(_flight.Carrier)) Errors.Add("Carrier value is not valid!");
        }

        private void ValidateDepartureTime()
        {
            if (IsValidString(_flight.DepartureTime)) Errors.Add("Departure time is not valid!");
        }

        private void ValidateArrivalTime()
        {
            if (IsValidString(_flight.ArrivalTime)) Errors.Add("Arrival time is not valid!");
        }

        private void ValidateTravelingTime()
        {
            DateTime departure;
            DateTime arrival;

            DateTime.TryParse(_flight.DepartureTime, out departure);
            DateTime.TryParse(_flight.ArrivalTime, out arrival);

            if (departure == default) Errors.Add("Departure Time is not in correct format!");

            if (departure >= arrival) Errors.Add("Invalid time interval between Departure and Arrival time!");

        }

        private bool IsValidString(string value)
        {
            return string.IsNullOrEmpty(value);
        }
    }
}
