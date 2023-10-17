using Flight_Planner.Core.Interfaces;
using Flight_Planner.Core.Models;

namespace Flight_Planner.Validation
{
    public class TicketValuesValidator : ITicketValidate
    {
        public bool IsValid(FlightTicket ticket)
        {
            return
                ticket != null &&
                !string.IsNullOrEmpty(ticket.From) &&
                !string.IsNullOrEmpty(ticket.To) &&
                !string.IsNullOrEmpty(ticket.DepartureDate);
        }
    }
}
