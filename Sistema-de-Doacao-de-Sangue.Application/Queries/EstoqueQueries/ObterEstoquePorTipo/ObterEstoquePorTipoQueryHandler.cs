using MediatR;
using Sistema_de_Doacao_de_Sangue.Core.DTOs;
using Sistema_de_Doacao_de_Sangue.Core.Repositories;

namespace Sistema_de_Doacao_de_Sangue.Application.Queries.EstoqueQueries.ObterEstoquePorTipo
{
    public class ObterEstoquePorTipoQueryHandler : IRequestHandler<ObterEstoquePorTipoQuery, EstoqueSangueDTO>
    {
        private readonly IEstoqueRepository _estoqueRepository;
        public ObterEstoquePorTipoQueryHandler(IEstoqueRepository estoqueRepository)
        {
            _estoqueRepository = estoqueRepository;
        }
        public async Task<EstoqueSangueDTO> Handle(ObterEstoquePorTipoQuery request, CancellationToken cancellationToken)
        {
            return await _estoqueRepository.ObterEstoquePorTipoAsync(request.TipoSanguineo, request.FatorRh);
        }
    }
}