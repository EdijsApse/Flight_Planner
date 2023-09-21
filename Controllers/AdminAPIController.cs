using Flight_Planner.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Flight_Planner.Controllers
{
    [Authorize]
    [Route("admin-api")]
    [ApiController]
    public class AdminAPIController : ControllerBase
    {
        private FlightStorage _flightStorage;

        public AdminAPIController()
        {
            _flightStorage = new FlightStorage();
        }

        [HttpGet]
        [Route("flights/{id}")]
        public IActionResult GetFlight(int id)
        {
            return NotFound();
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
    }
}
