using Microsoft.AspNetCore.Mvc;

namespace Flight_Planner.Controllers
{
    [Route("testing-api")]
    [ApiController]
    public class TestingAPIController : ControllerBase
    {
        private FlightStorage _flightStorage;

        public TestingAPIController(FlightStorage storage)
        {
            _flightStorage = storage;
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
