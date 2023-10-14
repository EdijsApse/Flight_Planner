using Flight_Planner.Core.Models;

namespace Flight_Planner.Core.Interfaces
{
    public interface IValidate
    {
        bool IsValid(Flight flight);
    }
}
