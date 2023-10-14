using Flight_Planner.Core.Interfaces;
using Flight_Planner.Core.Models;

namespace Flight_Planner.Validation
{
    public class FlightValuesValidator : IValidate
    {
        public bool IsValid(Flight flight)
        {
            return
                flight != null &&
                !string.IsNullOrEmpty(flight.DepartureTime) &&
                !string.IsNullOrEmpty(flight.ArrivalTime) &&
                !string.IsNullOrEmpty(flight.Carrier);
        }
    }
}
