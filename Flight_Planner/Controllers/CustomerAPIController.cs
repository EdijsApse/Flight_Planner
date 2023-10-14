using AutoMapper;
using Flight_Planner.Core.Interfaces;
using Flight_Planner.Core.Models;
using Flight_Planner.Core.Services;
using Flight_Planner.Models;
using Microsoft.AspNetCore.Mvc;

namespace Flight_Planner.Controllers
{
    [Route("api")]
    [ApiController]
    public class CustomerAPIController : ControllerBase
    {

        private readonly IFlightService _flightService;

        private readonly IAirportService _airportService;

        private readonly IMapper _mapper;

        private readonly IEnumerable<ITicketValidate> _validators;

        public CustomerAPIController(IAirportService airportService, IMapper mapper, IFlightService flightService, IEnumerable<ITicketValidate> validators)
        {
            _airportService = airportService;
            _flightService = flightService;
            _mapper = mapper;
            _validators = validators;
        }

        [HttpGet]
        [Route("airports")]
        public IActionResult GetAirports(string search)
        {
            var listOfMappedAirports = _airportService
                .SearchAirports(search)
                .Select(airport => _mapper.Map<AirportRequest>(airport));

            return Ok(listOfMappedAirports);
        }

        [HttpPost]
        [Route("flights/search")]
        public IActionResult SearchFlights(FlightTicket ticket)
        {
            if (!_validators.All(validator => validator.IsValid(ticket))) return BadRequest();

            var filteredFlights = _flightService.GetPage(ticket, 0);

            return Ok(filteredFlights);
        }

        [HttpGet]
        [Route("flights/{id}")]
        public IActionResult GetSingleFlight(int id)
        {
            var flight = _flightService.GetFullFlightById(id);

            if (flight != null) return Ok(_mapper.Map<FlightRequest>(flight));

            return NotFound();
        }
    }
}
