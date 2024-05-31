using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Sistema_de_Doacao_de_Sangue.Core.DTOs;
using Sistema_de_Doacao_de_Sangue.Core.Repositories;

namespace Sistema_de_Doacao_de_Sangue.Application.Queries.EstoqueQueries.ObterListagemDeEstoqueSanguineo
{
    public class ObterListagemDeEstoqueSanguineoQueryHandler : IRequestHandler<ObterListagemDeEstoqueSanguineoQuery, IEnumerable<EstoqueSangueDTO>>
    {
        private readonly IEstoqueRepository _estoqueRepository;
        public ObterListagemDeEstoqueSanguineoQueryHandler(IEstoqueRepository estoqueRepository)
        {
            _estoqueRepository = estoqueRepository;
        }
        public async Task<IEnumerable<EstoqueSangueDTO>> Handle(ObterListagemDeEstoqueSanguineoQuery request, CancellationToken cancellationToken)
        {
            return await _estoqueRepository.ObterEstoqueDeSangueAsync();
        }
    }
}