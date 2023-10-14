using Flight_Planner.Core.Interfaces;
using Flight_Planner.Core.Models;

namespace Flight_Planner.Validation
{
    public class TicketAirportsValidator : ITicketValidate
    {
        public bool IsValid(FlightTicket ticket)
        {
            return ticket?.From?.ToLower().Trim() != ticket?.To?.ToLower().Trim();
        }
    }
}
