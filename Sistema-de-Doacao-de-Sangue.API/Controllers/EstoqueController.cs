using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Doacao_de_Sangue.Application.Queries.EstoqueQueries.ObterEstoquePorTipo;
using Sistema_de_Doacao_de_Sangue.Application.Queries.EstoqueQueries.ObterListagemDeEstoqueSanguineo;

namespace Sistema_de_Doacao_de_Sangue.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EstoqueController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EstoqueController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Retrieves a list of all blood stock.
        /// </summary>
        /// <returns>Returns an Ok result with the list of blood stock.</returns>
        [HttpGet("obter-listagem-de-estoque-sanguineo")]
        public async Task<IActionResult> ObterListagemDoEstoqueAsync()
        {
            var query = new ObterListagemDeEstoqueSanguineoQuery();
            var estoques = await _mediator.Send(query);
            return Ok(estoques);
        }

        /// <summary>
        /// Retrieves blood stock by specified blood type.
        /// </summary>
        /// <param name="query">The query containing the blood type to retrieve stock for.</param>
        /// <returns>Returns an Ok result with the blood stock details for the specified type.</returns>
        [HttpGet("obter-estoque-sanguineo-por-tipo")]
        public async Task<IActionResult> ObterEstoqueSanguineoPorTipoAsync([FromQuery] ObterEstoquePorTipoQuery query)
        {
            var estoque = await _mediator.Send(query);
            return Ok(estoque);
        }
    }
}