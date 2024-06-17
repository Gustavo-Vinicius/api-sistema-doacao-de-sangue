using Sistema_de_Doacao_de_Sangue.Core.DTOs;

namespace Sistema_de_Doacao_de_Sangue.Core.Interfaces
{
    public interface IPdfGenerator
    {
        byte[] GenerateRelatorioEstoquePdf(IEnumerable<RelatorioEstoqueDTO> relatorio);
        byte[] GenerateRelatorioDoacoesPdf(IEnumerable<RelatorioDoacoesDTO> relatorio);
    }
}