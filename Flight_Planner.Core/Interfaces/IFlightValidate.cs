using Flight_Planner.Core.Models;

namespace Flight_Planner.Core.Interfaces
{
    public interface IFlightValidate
    {
        bool IsValid(Flight flight);
    }
}
