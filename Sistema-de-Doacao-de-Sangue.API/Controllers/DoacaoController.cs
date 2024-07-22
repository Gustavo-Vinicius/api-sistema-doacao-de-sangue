using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Doacao_de_Sangue.Application.Commands.DoacoesCommands.CadastrarDoacao;
using Sistema_de_Doacao_de_Sangue.Application.Queries.DoacoesQueries.ObterDiacoesPorId;
using Sistema_de_Doacao_de_Sangue.Application.Validators;

namespace Sistema_de_Doacao_de_Sangue.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DoacaoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DoacaoController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Registers a new blood donation.
        /// </summary>
        /// <param name="command">The command containing the details of the donation to be registered.</param>
        /// <returns>Returns an Ok result if the donation is successfully registered, otherwise returns a BadRequest with validation errors.</returns>
        [HttpPost("cadastrar-doacaoes")]
        public async Task<IActionResult> Post([FromBody] CadastrarDoacaoCommand command)
        {

            var validator = new CadastrarDoacaoCommandValidator();
            var validationResult = await validator.ValidateAsync(command);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Retrieves blood donations by the specified ID.
        /// </summary>
        /// <param name="query">The query containing the ID of the donations to be retrieved.</param>
        /// <returns>Returns an Ok result with the list of donations if the query is valid, otherwise returns a BadRequest with validation errors.</returns>
        [HttpGet("obter-doacoes-por-id")]
        public async Task<IActionResult> Get([FromQuery] ObterDoacoesPorIdQuery query)
        {

            var validator = new ObterDoacoesPorIdQueryValidator();
            var validationResult = await validator.ValidateAsync(query);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var doacoes = await _mediator.Send(query);
            return Ok(doacoes);
        }

    }
}