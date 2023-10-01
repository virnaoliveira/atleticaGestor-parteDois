using atleticaGestor_parteDois.Models;
using atleticaGestor_parteDois.Services;
using Microsoft.AspNetCore.Mvc;

namespace atleticaGestor_parteDois.Controllers
{
    public class xPontoExtraController : Controller
    {
        private readonly ITimeService _timeService;

        public xPontoExtraController(ITimeService timeService)
        {
            _timeService = timeService;
        }
        [HttpPost("cadastrarEsporteEspecifico")]
        public async Task<IActionResult> CadastrarTime([FromBody] Time time)
        {
            if (time == null)
            {
                return BadRequest("Dados do time inválidos.");
            }

            try
            {
                var resultado = await _timeService.CadastrarEsporte(time);

                if (resultado == null)
                {
                    return BadRequest("Já existe um time para este esporte.");
                }

                return Ok("Time cadastrado com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao cadastrar o time: {ex.Message}");
            }
        }
    }
}
