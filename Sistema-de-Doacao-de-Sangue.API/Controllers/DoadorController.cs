using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Doacao_de_Sangue.Application.Command.DoadoresCommands.CadastrarDoador;
using Sistema_de_Doacao_de_Sangue.Application.Commands.DoadoresCommands.DeletarDoador;
using Sistema_de_Doacao_de_Sangue.Application.Commands.DoadoresCommands.EditarDoador;
using Sistema_de_Doacao_de_Sangue.Application.Queries.DoadoresQueries.ObterDoacoesPorDoador;
using Sistema_de_Doacao_de_Sangue.Application.Queries.DoadoresQueries.ObterDoadorPorId;
using Sistema_de_Doacao_de_Sangue.Application.Queries.DoadoresQueries.ObterListagemDeDoadores;

namespace Sistema_de_Doacao_de_Sangue.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoadorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DoadorController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("obter-doador-por-id")]
        public async Task<ActionResult> ObterDoadorPorIdAsync([FromQuery] ObterDoadorPorIdQuery query)
        {
            var doador = await _mediator.Send(query);
            return Ok(doador);
        }

        [HttpGet("obter-listagem-de-doadores")]
        public async Task<ActionResult> ObterTodosDoadoresAsync()
        {
            var query = new ObterListagemDeDoadoresQuery();
            var doadores = await _mediator.Send(query);
            return Ok(doadores);
        } 

        [HttpGet("obter-doacoes-por-doador")]
        public async Task<ActionResult> ObterDoacoesPorDoadorAsync([FromQuery] ObterDoacoesPorDoadorQuery query)
        {
            var doacoes = await _mediator.Send(query);
            return Ok(doacoes);
        } 

        [HttpPost("cadastrar-doador")]
        public async Task<ActionResult> PostDoador([FromBody] CadastrarDoadorCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut("editar-doador")]
        public async Task<IActionResult> EditarDoadorAsync ([FromBody]EditarDoadorCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("deletar-doador")]
        public async Task<IActionResult> DeleteDoadorAsync([FromQuery]DeletarDoadorCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}