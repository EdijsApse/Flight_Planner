using Flight_Planner.Core.Interfaces;
using Flight_Planner.Core.Models;

namespace Flight_Planner.Validation
{
    public class FlightDateValidator : IValidate
    {
        public bool IsValid(Flight flight)
        {
            if (
                DateTime.TryParse(flight?.ArrivalTime, out var flightArrivalTime) &&
                DateTime.TryParse(flight?.DepartureTime, out var flightDepartureTime)
            )
            {
                return flightArrivalTime > flightDepartureTime;
            }

            return false;
        }
    }
}
