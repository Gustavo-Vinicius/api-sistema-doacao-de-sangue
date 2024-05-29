using Sistema_de_Doacao_de_Sangue.Core.DTOs;
using Sistema_de_Doacao_de_Sangue.Core.Entities;
using Sistema_de_Doacao_de_Sangue.Core.Interfaces;
using Sistema_de_Doacao_de_Sangue.Core.Repositories;

namespace Sistema_de_Doacao_de_Sangue.Infrastructure.Persistence.Repositories
{
    public class DoacaoRepository : IDoacaoRepository
    {
        private readonly IUnityOfWork _unityOfWork;
        public DoacaoRepository(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }
        public async Task AdicionarDoacaoAsync(int doadorId, DateTime dataDoacao, int quantidadeML)
        {

            var doador = await _unityOfWork.Doadores.GetByIdAsync(doadorId);

            if (doador == null)
            {
                throw new Exception("Doador não encontrado");
            }

            if (quantidadeML < 420 || quantidadeML > 470)
            {
                throw new Exception("Quantidade de sangue doada deve ser entre 420ml e 470ml");
            }

            var ultimaDoacao = (await _unityOfWork.Doacoes.GetAllAsync())
            .Where(d => d.DoadorId == doadorId)
            .OrderByDescending(d => d.DataDoacao)
            .FirstOrDefault();

            if (ultimaDoacao != null)
            {
                var diasDesdeUltimaDoacao = (DateTime.Now - ultimaDoacao.DataDoacao).TotalDays;
                if (doador.Genero == "F" && diasDesdeUltimaDoacao < 90)
                {
                    throw new Exception("Mulheres só podem doar de 90 em 90 dias");
                }
                if (doador.Genero == "M" && diasDesdeUltimaDoacao < 60)
                {
                    throw new Exception("Homens só podem doar de 60 em 60 dias");
                }
            }
            var doacao = new Doacao
            {
                DoadorId = doadorId,
                DataDoacao = dataDoacao,
                QuantidadeML = quantidadeML
            };

            await _unityOfWork.Doacoes.AddAsync(doacao);

            var estoque = (await _unityOfWork.EstoqueSangue.GetAllAsync())
            .FirstOrDefault(e => e.TipoSanguineo == doador.TipoSanguineo && e.FatorRh == doador.FatorRh);

            if (estoque == null)
            {
                estoque = new EstoqueSangue
                {
                    TipoSanguineo = doador.TipoSanguineo,
                    FatorRh = doador.FatorRh,
                    QuantidadeML = doacao.QuantidadeML
                };
                await _unityOfWork.EstoqueSangue.AddAsync(estoque);
            }
            else
            {
                estoque.QuantidadeML += doacao.QuantidadeML;
                _unityOfWork.EstoqueSangue.Update(estoque);
            }

            await _unityOfWork.CompleteAsync();
        }

        public async Task<Doacao> ObterDoacaoPorIdAsync(int id)
        {
            var doacao = await _unityOfWork.Doacoes.GetByIdAsync(id);

            if (doacao == null)
            {
                throw new Exception("Nenhuma doacao na base de dados.");
            }

           return doacao;
        }
    }
}