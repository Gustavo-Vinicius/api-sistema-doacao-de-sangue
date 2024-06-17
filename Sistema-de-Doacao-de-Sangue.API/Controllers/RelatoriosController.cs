using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Doacao_de_Sangue.Application.Queries.Relatorios.RelatorioDoacoes.ObterRelatorioDoacoes;
using Sistema_de_Doacao_de_Sangue.Application.Queries.Relatorios.RelatorioEstoque.ObterRelatorioEstoque;
using Sistema_de_Doacao_de_Sangue.Core.Interfaces;

namespace Sistema_de_Doacao_de_Sangue.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RelatoriosController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IPdfGenerator _pdfGenerator;

        public RelatoriosController(IMediator mediator, IPdfGenerator pdfGenerator)
        {
            _mediator = mediator;
            _pdfGenerator = pdfGenerator;
        }

        [HttpGet("obter-relatorio-de-estoque")]
        public async Task<IActionResult> ObterRelatorioDeEstoqueAsync()
        {
            var query = new ObterRelatorioEstoqueQuery();
            var relatorio = await _mediator.Send(query);
            var pdfBytes = _pdfGenerator.GenerateRelatorioEstoquePdf(relatorio);
            return File(pdfBytes, "application/pdf", "Relatorio_Estoque.pdf");
        }

        
        [HttpGet("obter-relatorio-de-doacoes")]
        public async Task<IActionResult> ObterRelatorioDeDoacoesAsync()
        {
            var query = new ObterRelatorioDoacoesQuery();
            var relatorio = await _mediator.Send(query);
            var pdfBytes = _pdfGenerator.GenerateRelatorioDoacoesPdf(relatorio);
            return File(pdfBytes, "application/pdf", "Relatorio_Doacoes.pdf");
        }
    }
}