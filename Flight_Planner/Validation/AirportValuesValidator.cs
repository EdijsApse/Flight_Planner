using Flight_Planner.Core.Interfaces;
using Flight_Planner.Core.Models;

namespace Flight_Planner.Validation
{
    public class AirportValuesValidator : IValidate
    {
        public bool IsValid(Flight flight)
        {
            return
                flight?.From != null &&
                !string.IsNullOrEmpty(flight.From.Country) &&
                !string.IsNullOrEmpty(flight.From.City) &&
                !string.IsNullOrEmpty(flight.From.Code) &&
                flight?.To != null &&
                !string.IsNullOrEmpty(flight.To.Country) &&
                !string.IsNullOrEmpty(flight.To.City) &&
                !string.IsNullOrEmpty(flight.To.Code);
        }
    }
}
