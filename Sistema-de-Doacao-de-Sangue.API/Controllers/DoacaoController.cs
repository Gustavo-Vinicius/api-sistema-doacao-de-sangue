using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Doacao_de_Sangue.Application.Commands.DoacoesCommands.CadastrarDoacao;
using Sistema_de_Doacao_de_Sangue.Application.Queries.DoacoesQueries.ObterDiacoesPorId;

namespace Sistema_de_Doacao_de_Sangue.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoacaoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DoacaoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("cadastrar-doacaoes")]
        public async Task<IActionResult> Post([FromBody] CadastrarDoacaoCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet("obter-doacoes-por-id")]
        public async Task<IActionResult> Get([FromQuery] ObterDoacoesPorIdQuery query)
        {
            var doacoes = await _mediator.Send(query);
            return Ok(doacoes);
        }
        
    }
}