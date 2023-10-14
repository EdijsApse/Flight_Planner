using Flight_Planner.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Flight_Planner.Controllers
{
    [Authorize]
    [Route("admin-api")]
    [ApiController]
    public class AdminAPIController : ControllerBase
    {
        private FlightStorage _flightStorage;

        public AdminAPIController(FlightStorage storage)
        {
            _flightStorage = storage;
        }

        [HttpGet]
        [Route("flights/{id}")]
        public IActionResult GetFlight(int id)
        {
            var flight = _flightStorage.GetFlight(id);

            if (flight == null) return NotFound();

            return Ok(flight);
        }

        [HttpPut]
        [Route("flights")]
        public IActionResult AddFlight(Flight flight)
        {
            var flightValidator = new FlightValidator(flight);

            if (flightValidator.HasErrors()) return BadRequest();

            if (_flightStorage.FlightExists(flight)) return Conflict();

            _flightStorage.AddFlight(flight);

            return Created("", flight);
        }

        [HttpDelete]
        [Route("flights/{id}")]
        public IActionResult DeleteFlight(int id)
        {
            _flightStorage.DeleteFlight(id);

            return Ok();
        }
    }
}
