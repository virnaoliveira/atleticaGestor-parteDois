using atleticaGestor_parteDois.Models;
using atleticaGestor_parteDois.Services;
using Microsoft.AspNetCore.Mvc;

namespace atleticaGestor_parteDois.Controllers
{
    public class TimeController : ControllerBase
    {
        private readonly ITimeService _timeService;

        public TimeController(ITimeService timeService)
        {
            _timeService = timeService;
        }

        [HttpGet("Time")]
        public IActionResult Get()
        {
            return Ok(_timeService.FindAll());
        }

        [HttpPost("Time")]
        public IActionResult Post([FromBody] Time time)
        {
            if (time == null) return BadRequest();
            return Ok(_timeService.Create(time));
        }

        [HttpPut("Time")]
        public IActionResult Put([FromBody] Time time)
        {
            if (time == null) return BadRequest();
            return Ok(_timeService.Update(time));
        }

        [HttpDelete("Time/{id}")]
        public IActionResult Delete(long id)
        {
            _timeService.Delete(id);
            return NoContent();
        }
    }
}
