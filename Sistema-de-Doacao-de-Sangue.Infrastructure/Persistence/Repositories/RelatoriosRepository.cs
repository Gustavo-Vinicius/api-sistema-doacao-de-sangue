using Sistema_de_Doacao_de_Sangue.Core.DTOs;
using Sistema_de_Doacao_de_Sangue.Core.Interfaces;
using Sistema_de_Doacao_de_Sangue.Core.Repositories;

namespace Sistema_de_Doacao_de_Sangue.Infrastructure.Persistence.Repositories
{
    public class RelatoriosRepository : IRelatoriosRepository
    {
        private readonly IUnityOfWork _unitOfWork;
        public RelatoriosRepository(IUnityOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<RelatorioEstoqueDTO>> ObterRelatorioEstoqueAsync()
        {
            var estoque = await _unitOfWork.EstoqueSangue.GetAllAsync();

            var relatorioEstoqueDTO = estoque
            .GroupBy(e => new { e.TipoSanguineo, e.FatorRh })
            .Select(g => new RelatorioEstoqueDTO
            {
                TipoSanguineo = g.Key.TipoSanguineo,
                FatorRh = g.Key.FatorRh,
                QuantidadeTotalML = g.Sum(e => e.QuantidadeML)
            })
            .ToList();

            return relatorioEstoqueDTO;

        }
        public async Task<IEnumerable<RelatorioDoacoesDTO>> ObterRelatorioDoacoesAsync()
        {
            var doacoesRecentes = (await _unitOfWork.Doacoes.GetAllAsync())
            .Where(d => d.DataDoacao >= DateTime.Now.AddDays(-30))
            .ToList();

            var doadores = await _unitOfWork.Doadores.GetAllAsync();

            var relatorioDoacoesDTO = doacoesRecentes.Select(d => new RelatorioDoacoesDTO
            {
                Id = d.Id,
                DoadorId = d.DoadorId,
                DataDoacao = d.DataDoacao,
                QuantidadeML = d.QuantidadeML,
                NomeDoador = doadores.FirstOrDefault(doa => doa.Id == d.DoadorId)?.NomeCompleto,
                EmailDoador = doadores.FirstOrDefault(doa => doa.Id == d.DoadorId)?.Email
            }).ToList();

            return relatorioDoacoesDTO;

        }

    }
}