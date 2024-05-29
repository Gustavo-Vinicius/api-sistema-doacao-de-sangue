using AutoMapper;
using Sistema_de_Doacao_de_Sangue.Core.DTOs;
using Sistema_de_Doacao_de_Sangue.Core.Entities;
using Sistema_de_Doacao_de_Sangue.Core.Interfaces;
using Sistema_de_Doacao_de_Sangue.Core.Repositories;

namespace Sistema_de_Doacao_de_Sangue.Infrastructure.Persistence.Repositories
{
    public class DoadoresRepository : IDoadoresRepository
    {
        private readonly IUnityOfWork _unitOfWork;
        //public IMapper _mapper;
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


        public async Task<IEnumerable<DoadorDTO>> ObterDoadoresAsync()
        {
            IEnumerable<Doador> doador = await _unitOfWork.Doadores.GetAllAsync();

            IEnumerable<DoadorDTO> doadorDTOs = doador.Select(doador => new DoadorDTO
            {
                NomeCompleto = doador.NomeCompleto,
                Email = doador.Email,
                DataNascimento = doador.DataNascimento,
                Genero = doador.Genero,
                Peso = doador.Peso,
                TipoSanguineo = doador.TipoSanguineo,
                FatorRh = doador.FatorRh
            });

            return doadorDTOs;
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
        public async Task EditarDoadorAsync(int id, DoadorDTO doadorDTO)
        {
            var doadorExistente = await _unitOfWork.Doadores.GetByIdAsync(id);
            if (doadorExistente == null)
            {
                throw new Exception("Doador não encontrado");
            }

            // Atualizar as propriedades do doador existente com os valores do DTO
            doadorExistente.NomeCompleto = doadorDTO.NomeCompleto;
            doadorExistente.Email = doadorDTO.Email;
            doadorExistente.DataNascimento = doadorDTO.DataNascimento;
            doadorExistente.Genero = doadorDTO.Genero;
            doadorExistente.Peso = doadorDTO.Peso;
            doadorExistente.TipoSanguineo = doadorDTO.TipoSanguineo;
            doadorExistente.FatorRh = doadorDTO.FatorRh;

            // Atualizar a entidade no repositório
            _unitOfWork.Doadores.Update(doadorExistente);

            // Salvar as mudanças no banco de dados
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeletarDoadorAsync(int Id)
        {
            var doador = await _unitOfWork.Doadores.GetByIdAsync(Id);

            _unitOfWork.Doadores.Delete(doador);

            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<DoacaoDTO>> ObterDoacoesPorDoadorAsync(int Id)
        {
            var doacoes = (await _unitOfWork.Doacoes.GetAllAsync()).Where(x => x.DoadorId == Id);

            var doacoesDTO = doacoes.Select(d => new DoacaoDTO
            {
                DoadorId = d.DoadorId,
                DataDoacao = d.DataDoacao,
                QuantidadeML = d.QuantidadeML
            }).ToList();

            return doacoesDTO;
        }
    }
}