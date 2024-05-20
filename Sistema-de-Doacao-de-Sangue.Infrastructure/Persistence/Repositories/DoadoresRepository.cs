using Sistema_de_Doacao_de_Sangue.Core.DTOs;
using Sistema_de_Doacao_de_Sangue.Core.Entities;
using Sistema_de_Doacao_de_Sangue.Core.Interfaces;
using Sistema_de_Doacao_de_Sangue.Core.Repositories;

namespace Sistema_de_Doacao_de_Sangue.Infrastructure.Persistence.Repositories
{
    public class DoadoresRepository : IDoadoresRepository
    {
        private readonly IUnityOfWork _unitOfWork;
        public DoadoresRepository(IUnityOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AdicionarUmDoadorAsync(string nomeCompleto, string email, DateTime dataNascimento, string genero, double peso, string tipoSanguineo, string fatorRh)
        {
            var doador = new Doador
            {
                NomeCompleto = nomeCompleto,
                Email = email,
                DataNascimento = dataNascimento,
                Genero = genero,
                Peso = peso,
                TipoSanguineo = tipoSanguineo,
                FatorRh = fatorRh
            };

            await _unitOfWork.Doadores.AddAsync(doador);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<DoadorDTO> ObterDoadorPorId(int id)
        {
            var doador = await _unitOfWork.Doadores.GetByIdAsync(id);

            if (doador == null)
            {
                throw new Exception("Nenhum doador na base de dados.");
            }

            var doadorDTO = new DoadorDTO
            {
                NomeCompleto = doador.NomeCompleto,
                Email = doador.Email,
                DataNascimento = doador.DataNascimento,
                Genero = doador.Genero,
                Peso = doador.Peso,
                TipoSanguineo = doador.TipoSanguineo,
                FatorRh = doador.FatorRh
            };

            return doadorDTO;
        }
    }
}