using atleticaGestor_parteDois.Models;
using atleticaGestor_parteDois.Services;
using Microsoft.AspNetCore.Mvc;

namespace atleticaGestor_parteDois.Controllers
{
    public class AtletaController : ControllerBase
    {
        private readonly IAtletaService _atletaService;

        public AtletaController(IAtletaService atletaService)
        {
            _atletaService = atletaService;
        }

        [HttpGet("Atleta")]
        public IActionResult Get()
        {
            return Ok(_atletaService.FindAll());
        }

        [HttpGet("Atleta/{matricula}")]
        public IActionResult Get(long id)
        {
            var atletaService = _atletaService.FindById(id);
            if (atletaService == null) return NotFound();
            return Ok(atletaService);
        }

        [HttpPost("Atleta")]
        public IActionResult Post([FromBody] Atleta atleta)
        {
            if (atleta == null) return BadRequest();
            return Ok(_atletaService.Create(atleta));
        }

        [HttpPut("Atleta/{matricula}")]
        public IActionResult Put(long matricula, [FromBody] Atleta atleta)
        {
            if (atleta == null) return BadRequest();
            return Ok(_atletaService.Update(atleta));
        }

        [HttpDelete("Atleta/{matricula}")]
        public IActionResult Delete(long matricula)
        {
            _atletaService.Delete(matricula);
            return NoContent();
        }
    }
}
