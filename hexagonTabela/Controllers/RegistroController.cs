using hexagonTabela.Models;
using hexagonTabela.Serveces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using System.Runtime.InteropServices;

namespace hexagonTabela.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroController (IRegistroServices _registro) : Controller
    {
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
        public async Task<IActionResult> Deletar( Guid id)
        {
            await _registro.Remover(id);

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<ObterRegistroModel>>> ObterRegistro(int pagina = 1, int pageSize = 10)
        {
            var resultado = await _registro.ObterTodos(pagina,pageSize);

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
