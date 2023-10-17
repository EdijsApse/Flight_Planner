using Flight_Planner.Core.Models;

namespace Flight_Planner.Core.Interfaces
{
    public interface ITicketValidate
    {
        bool IsValid(FlightTicket ticket);
    }
}
