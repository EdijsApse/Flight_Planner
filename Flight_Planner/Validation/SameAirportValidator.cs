using Flight_Planner.Core.Interfaces;
using Flight_Planner.Core.Models;

namespace Flight_Planner.Validation
{
    public class SameAirportValidator : IValidate
    {
        public bool IsValid(Flight flight)
        {
            return flight?.To?.Code?.ToLower()?.Trim() != flight?.From?.Code?.ToLower()?.Trim();
        }
    }
}
