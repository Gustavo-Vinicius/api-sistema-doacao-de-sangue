using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sistema_de_Doacao_de_Sangue.Core.DTOs;
using Sistema_de_Doacao_de_Sangue.Core.Interfaces;
using Sistema_de_Doacao_de_Sangue.Core.Repositories;

namespace Sistema_de_Doacao_de_Sangue.Infrastructure.Persistence.Repositories
{
    public class EstoqueRepository : IEstoqueRepository
    {
        private readonly IUnityOfWork _unitOfWork;
        //public IMapper _mapper;
        public EstoqueRepository(IUnityOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<EstoqueSangueDTO>> ObterEstoqueDeSangueAsync()
        {
            var estoque = await _unitOfWork.EstoqueSangue.GetAllAsync();

            var estoqueDTO = estoque.Select(d => new EstoqueSangueDTO
            {
                TipoSanguineo = d.TipoSanguineo,
                FatorRh = d.FatorRh,
                QuantidadeML = d.QuantidadeML

            }).ToList();

            return estoqueDTO;
        }

        public async Task<EstoqueSangueDTO> ObterEstoquePorTipoAsync(string tipoSanguineo, string fatorRh)
        {
            var estoque = (await _unitOfWork.EstoqueSangue.GetAllAsync())
                .FirstOrDefault(e => e.TipoSanguineo == tipoSanguineo && e.FatorRh == fatorRh);

            var estoqueDTO = new EstoqueSangueDTO
            {
                TipoSanguineo = estoque.TipoSanguineo,
                FatorRh = estoque.FatorRh,
                QuantidadeML = estoque.QuantidadeML

            };

            return estoqueDTO;
        }
    }
}