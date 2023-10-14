﻿using Flight_Planner.Core.Models;
using Flight_Planner.Core.Services;
using Flight_Planner.Data;
using Microsoft.EntityFrameworkCore;

namespace Flight_Planner.Services
{
    public class FlightService : EntityService<Flight>, IFlightService
    {
        private static readonly object _lock = new object();

        public FlightService(IFlightPlannerDBContext context) : base(context)
        {
        }

        public bool Exists(Flight flight)
        {
            lock (_lock)
            {
                return _context.Flight.Any(f =>
                    f.DepartureTime == flight.DepartureTime &&
                    f.ArrivalTime == flight.ArrivalTime &&
                    f.Carrier == flight.Carrier &&
                    f.To.Code == flight.To.Code &&
                    f.From.Code == flight.From.Code
                );
            }
        }

        public Flight GetFullFlightById(int id)
        {
            return _context.Flight
            .Include(f => f.From)
            .Include(f => f.To)
            .FirstOrDefault(f => f.Id == id);
        }

        public List<Flight> SearchFullFlights(FlightTicket ticket)
        {
            return _context.Flight
                    .Include(flight => flight.From)
                    .Include(flight => flight.To)
                    .Where(flight =>
                        flight.From.Code.Equals(ticket.From) &&
                        flight.To.Code.Equals(ticket.To) &&
                        flight.DepartureTime.Contains(ticket.DepartureDate)
                        ).ToList();
        }

        public new void Create(Flight flight)
        {
            lock (_lock)
            {
                base.Create(flight);
            }
        }

        public new void Delete(Flight flight)
        {
            lock (_lock)
            {
                base.Delete(flight);
            }
        }
    }
}
