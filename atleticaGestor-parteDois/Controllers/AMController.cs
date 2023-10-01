using atleticaGestor_parteDois.Models;
using atleticaGestor_parteDois.Services;
using Microsoft.AspNetCore.Mvc;

namespace atleticaGestor_parteDois.Controllers
{
    [ApiController]
    public class AMController : ControllerBase
    {
        private readonly IAMService _amService;

        public AMController(IAMService amService)
        {
            _amService = amService;
        }

        [HttpGet("AtletasTime")]
        public IActionResult Get()
        {
            return Ok(_amService.FindAll());
        }

        [HttpPost("AtletasTime")]
        public IActionResult Post([FromBody] Associacaomembrotime associacaomembrotime)
        {
            if (associacaomembrotime == null) return BadRequest();
            return Ok(_amService.Create(associacaomembrotime));
        }

        [HttpPut("AtletasTime/{matricula}")]
        public IActionResult Put(long matricula, [FromBody] Associacaomembrotime associacaomembrotime)
        {
            if (associacaomembrotime == null) return BadRequest();
            return Ok(_amService.Update(associacaomembrotime));
        }

        [HttpDelete("AtletasTime/{matricula}")]
        public IActionResult Delete(long matricula)
        {
            _amService.Delete(matricula);
            return NoContent();
        }
    }
}
