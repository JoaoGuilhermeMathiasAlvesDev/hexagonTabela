using hexagonTabela.Models;
using hexagonTabela.Serveces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

namespace hexagonTabela.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroController : Controller
    {
        private readonly IRegistroServices _registro;

        public RegistroController(IRegistroServices services)
        {
            _registro = services;
        }

        [HttpPost]
        public async Task <IActionResult> Adicionar([FromBody] AdicionarResgistroModel model)
        {
           await _registro.Adicionar(model);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar([FromBody]RegistroModel model)
        {
            await _registro.Atualizar(model);

            return Ok(model);
        }

        [HttpDelete]
        public async Task<IActionResult> Deletar([FromBody]RegistroModel model)
        {
            await _registro.Remover(model);

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<ObterRegistroModel>>> ObterRegistro()
        {
            var resultado = await _registro.ObterTodos();

            return Ok(resultado);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ObterRegistroModel>> ObterUmRegistro(Guid id)
        {
            var resultado  = await _registro.ObterPorId(id);

            return Ok(resultado);
        }
    }
}
