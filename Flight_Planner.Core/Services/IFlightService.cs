﻿using Flight_Planner.Core.Models;

namespace Flight_Planner.Core.Services
{
    public interface IFlightService : IEntityService<Flight>
    {
        Flight GetFullFlightById(int id);

        bool Exists(Flight flight);

        FlightPage GetPage(FlightTicket ticket, int page);
    }
}
