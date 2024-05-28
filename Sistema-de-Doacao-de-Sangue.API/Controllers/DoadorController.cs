using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Doacao_de_Sangue.Application.Command.DoadoresCommands.CadastrarDoador;
using Sistema_de_Doacao_de_Sangue.Application.Queries.DoadoresQueries.ObterDoadorPorId;

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

        [HttpPost("cadastrar-doador")]
        public async Task<ActionResult> PostDoador([FromBody] CadastrarDoadorCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }

        [HttpGet("obter-doador-por-id")]
        public async Task<ActionResult> ObterDoadorPorIdAsync([FromQuery] ObterDoadorPorIdQuery query)
        {
            var doador = await _mediator.Send(query);
            return Ok(doador);
        }
    }
}