using Flight_Planner.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Flight_Planner.Controllers
{
    [Route("testing-api")]
    [ApiController]
    public class TestingAPIController : ControllerBase
    {
        private ICleanupService _cleanupService;

        public TestingAPIController(ICleanupService cleanupService)
        {
            _cleanupService = cleanupService;
        }

        [HttpPost]
        [Route("clear")]
        public IActionResult Clear()
        {
            _cleanupService.CleanDatabase();
            return Ok();
        }
    }
}
