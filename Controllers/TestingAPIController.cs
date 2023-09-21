using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Flight_Planner.Controllers
{
    [Route("testing-api")]
    [ApiController]
    public class TestingAPIController : ControllerBase
    {
        private FlightStorage _flightStorage;

        public TestingAPIController()
        {
            _flightStorage = new FlightStorage();
        }

        [HttpPost]
        [Route("clear")]
        public IActionResult Clear()
        {
            _flightStorage.ClearFlights();
            return Ok();
        }
    }
}
