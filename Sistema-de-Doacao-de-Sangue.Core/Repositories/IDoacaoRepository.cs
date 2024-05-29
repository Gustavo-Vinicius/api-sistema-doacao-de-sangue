using Sistema_de_Doacao_de_Sangue.Core.DTOs;
using Sistema_de_Doacao_de_Sangue.Core.Entities;

namespace Sistema_de_Doacao_de_Sangue.Core.Repositories
{
    public interface IDoacaoRepository
    {
        Task AdicionarDoacaoAsync(int DoadorId, DateTime DataDoacao, int QuantidadeML);
        Task<Doacao> ObterDoacaoPorIdAsync(int id);
    }
}