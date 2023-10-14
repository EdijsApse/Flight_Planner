using AutoMapper;
using Flight_Planner.Core.Interfaces;
using Flight_Planner.Core.Models;
using Flight_Planner.Core.Services;
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
        private IFlightService _flightService;

        private readonly IMapper _mapper;

        private readonly IEnumerable<IFlightValidate> _flightValidators;

        public AdminAPIController(IFlightService flightService, IMapper mapper, IEnumerable<IFlightValidate> flightValidators)
        {
            _flightService = flightService;
            _mapper = mapper;
            _flightValidators = flightValidators;
        }

        [HttpGet]
        [Route("flights/{id}")]
        public IActionResult GetFlight(int id)
        {
            var flight = _flightService.GetFullFlightById(id);

            if (flight == null) return NotFound();

            return Ok(_mapper.Map<FlightRequest>(flight));
        }

        [HttpPut]
        [Route("flights")]
        public IActionResult AddFlight(FlightRequest request)
        {
            var flight = _mapper.Map<Flight>(request);

            if (!_flightValidators.All(validator => validator.IsValid(flight))) return BadRequest();

            if (_flightService.Exists(flight)) return Conflict();

            _flightService.Create(flight);

            request = _mapper.Map<FlightRequest>(flight);

            return Created("", request);
        }

        [HttpDelete]
        [Route("flights/{id}")]
        public IActionResult DeleteFlight(int id)
        {
            var flight = _flightService.GetFullFlightById(id);

            if (flight != null) _flightService.Delete(flight);

            return Ok();
        }
    }
}
