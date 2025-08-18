using hexagonTabela.Serveces;
using Microsoft.AspNetCore.Mvc;

namespace hexagonTabela.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DicionariosController : Controller
    {
        private readonly IDicionarioServices _services;

        public DicionariosController(IDicionarioServices services)
        {
            _services = services;
        }

        [HttpGet("estado-civil")]
        public async Task<IActionResult> ObterDiconarioEstadoCivil()
        {
            var resultado = await _services.ObterEstadoCivilDicionairo();
            return Ok(resultado);
        }

        [HttpGet("estados")]
        public async Task<ActionResult> ObterDiconairoEstados()
        {
            var resultado = await _services.ObterEstadosComoDicionario();
            return Ok(resultado);
        }
    }
}
