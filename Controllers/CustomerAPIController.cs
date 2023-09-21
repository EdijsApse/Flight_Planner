using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Flight_Planner.Controllers
{
    [Route("api")]
    [ApiController]
    public class CustomerAPIController : ControllerBase
    {
        private FlightStorage _flightStorage;

        public CustomerAPIController()
        {
            _flightStorage = new FlightStorage();
        }

        [HttpGet]
        [Route("airports")]
        public IActionResult GetAirports(string search)
        {
            return Ok(_flightStorage.SearchAirports(search));
        }
    }
}
