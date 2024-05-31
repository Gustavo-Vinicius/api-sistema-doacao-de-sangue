using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Sistema_de_Doacao_de_Sangue.Core.DTOs;
using Sistema_de_Doacao_de_Sangue.Core.Repositories;

namespace Sistema_de_Doacao_de_Sangue.Application.Queries.Relatorios.RelatorioEstoque.ObterRelatorioEstoque
{
    public class ObterRelatorioEstoqueQueryHandler : IRequestHandler<ObterRelatorioEstoqueQuery, IEnumerable<RelatorioEstoqueDTO>>
    {
        private readonly IRelatoriosRepository _relatoriosRepository;
        public ObterRelatorioEstoqueQueryHandler(IRelatoriosRepository relatoriosRepository)
        {
            _relatoriosRepository = relatoriosRepository;
        }
        public async Task<IEnumerable<RelatorioEstoqueDTO>> Handle(ObterRelatorioEstoqueQuery request, CancellationToken cancellationToken)
        {
            return await _relatoriosRepository.ObterRelatorioEstoqueAsync();
        }
    }
}