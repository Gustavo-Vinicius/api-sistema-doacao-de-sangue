using Sistema_de_Doacao_de_Sangue.Core.DTOs;

namespace Sistema_de_Doacao_de_Sangue.Core.Repositories
{
    public interface IDoadoresRepository
    {
        Task AdicionarUmDoadorAsync(string nomeCompleto, string email, DateTime dataNascimento, string genero, double peso, string tipoSanguineo, string fatorRh);
        Task<DoadorDTO> ObterDoadorPorId(int id);
        Task <IEnumerable<DoadorDTO>> ObterDoadoresAsync();
        Task EditarDoadorAsync(int id, DoadorDTO doadorDTO);
        Task DeletarDoadorAsync(int Id);
        Task<IEnumerable<DoacaoDTO>> ObterDoacoesPorDoadorAsync(int Id);
    }
}