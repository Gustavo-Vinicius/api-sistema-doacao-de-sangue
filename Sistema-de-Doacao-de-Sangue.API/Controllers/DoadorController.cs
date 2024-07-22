using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Doacao_de_Sangue.Application.Command.DoadoresCommands.CadastrarDoador;
using Sistema_de_Doacao_de_Sangue.Application.Commands.DoadoresCommands.DeletarDoador;
using Sistema_de_Doacao_de_Sangue.Application.Commands.DoadoresCommands.EditarDoador;
using Sistema_de_Doacao_de_Sangue.Application.Queries.DoadoresQueries.ObterDoacoesPorDoador;
using Sistema_de_Doacao_de_Sangue.Application.Queries.DoadoresQueries.ObterDoadorPorId;
using Sistema_de_Doacao_de_Sangue.Application.Queries.DoadoresQueries.ObterListagemDeDoadores;
using Sistema_de_Doacao_de_Sangue.Application.Validators;

namespace Sistema_de_Doacao_de_Sangue.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DoadorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DoadorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Retrieves a donor by the specified ID.
        /// </summary>
        /// <param name="query">The query containing the ID of the donor to be retrieved.</param>
        /// <returns>Returns an Ok result with the donor details if the query is valid, otherwise returns a BadRequest with validation errors.</returns>
        [HttpGet("obter-doador-por-id")]
        public async Task<ActionResult> ObterDoadorPorIdAsync([FromQuery] ObterDoadorPorIdQuery query)
        {
            var validator = new ObterDoadorPorIdQueryValidator();
            var validationResult = await validator.ValidateAsync(query);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var doador = await _mediator.Send(query);
            return Ok(doador);
        }

        /// <summary>
        /// Retrieves a list of all donors.
        /// </summary>
        /// <returns>Returns an Ok result with the list of donors.</returns>
        [HttpGet("obter-listagem-de-doadores")]
        public async Task<ActionResult> ObterTodosDoadoresAsync()
        {
            var query = new ObterListagemDeDoadoresQuery();
            var doadores = await _mediator.Send(query);
            return Ok(doadores);
        }

        /// <summary>
        /// Retrieves donations by the specified donor.
        /// </summary>
        /// <param name="query">The query containing the donor details whose donations are to be retrieved.</param>
        /// <returns>Returns an Ok result with the list of donations if the query is valid, otherwise returns a BadRequest with validation errors.</returns>
        [HttpGet("obter-doacoes-por-doador")]
        public async Task<ActionResult> ObterDoacoesPorDoadorAsync([FromQuery] ObterDoacoesPorDoadorQuery query)
        {
            var validator = new ObterDoacoesPorDoadorQueryValidator();
            var validationResult = await validator.ValidateAsync(query);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var doacoes = await _mediator.Send(query);
            return Ok(doacoes);
        }

        /// <summary>
        /// Registers a new donor.
        /// </summary>
        /// <param name="command">The command containing the details of the donor to be registered.</param>
        /// <returns>Returns an Ok result if the donor is successfully registered, otherwise returns a BadRequest with validation errors.</returns>
        [HttpPost("cadastrar-doador")]
        public async Task<ActionResult> PostDoador([FromBody] CadastrarDoadorCommand command)
        {
            var validator = new CadastrarDoadorCommandValidator();
            var validationResult = await validator.ValidateAsync(command);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Updates an existing donor.
        /// </summary>
        /// <param name="command">The command containing the updated details of the donor.</param>
        /// <returns>Returns a NoContent result if the donor is successfully updated, otherwise returns a BadRequest with validation errors.</returns>
        [HttpPut("editar-doador")]
        public async Task<IActionResult> EditarDoadorAsync([FromBody] EditarDoadorCommand command)
        {
            var validator = new EditarDoadorCommandValidator();
            var validationResult = await validator.ValidateAsync(command);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            await _mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Deletes an existing donor.
        /// </summary>
        /// <param name="command">The command containing the details of the donor to be deleted.</param>
        /// <returns>Returns a NoContent result if the donor is successfully deleted.</returns>
        [HttpDelete("deletar-doador")]
        public async Task<IActionResult> DeleteDoadorAsync([FromQuery] DeletarDoadorCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}