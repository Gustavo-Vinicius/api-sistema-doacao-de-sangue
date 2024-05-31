using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Doacao_de_Sangue.Application.Queries.Relatorios.RelatorioDoacoes.ObterRelatorioDoacoes;
using Sistema_de_Doacao_de_Sangue.Application.Queries.Relatorios.RelatorioEstoque.ObterRelatorioEstoque;

namespace Sistema_de_Doacao_de_Sangue.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RelatoriosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RelatoriosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("obter-relatorio-de-estoque")]
        public async Task<IActionResult> ObterRelatorioDeEstoqueAsync()
        {
            var query = new ObterRelatorioEstoqueQuery();
            var relatorio = await _mediator.Send(query);
            return Ok(relatorio);
        }

        [HttpGet("obter-relatorio-de-doacoes")]
        public async Task<IActionResult> ObterRelatorioDeDoacoesAsync()
        {
            var query = new ObterRelatorioDoacoesQuery();
            var relatorio = await _mediator.Send(query);
            return Ok(relatorio);
        }
    }
}