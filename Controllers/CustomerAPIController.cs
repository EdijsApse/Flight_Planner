using Microsoft.AspNetCore.Mvc;

namespace Flight_Planner.Controllers
{
    [Route("api")]
    [ApiController]
    public class CustomerAPIController : ControllerBase
    {
        private FlightStorage _flightStorage;

        public CustomerAPIController(FlightStorage storage)
        {
            _flightStorage = storage;
        }

        [HttpGet]
        [Route("airports")]
        public IActionResult GetAirports(string search)
        {
            return Ok(_flightStorage.SearchAirports(search));
        }

        [HttpPost]
        [Route("flights/search")]
        public IActionResult SearchFlights(FlightTicket ticket)
        {
            var ticketValidator = new TicketValidator(ticket);

            if (ticketValidator.HasErrors()) return BadRequest();

            return Ok(_flightStorage.GetFlights(ticket));
        }

        [HttpGet]
        [Route("flights/{id}")]
        public IActionResult GetSingleFlight(int id)
        {
            var flight = _flightStorage.GetFlight(id);

            if (flight != null) return Ok(flight);

            return NotFound();
        }
    }
}
