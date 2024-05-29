using MediatR;
using Sistema_de_Doacao_de_Sangue.Core.Entities;
using Sistema_de_Doacao_de_Sangue.Core.Repositories;

namespace Sistema_de_Doacao_de_Sangue.Application.Queries.DoacoesQueries.ObterDiacoesPorId
{
    public class ObterDoacoesPorIdQueryHandler : IRequestHandler<ObterDoacoesPorIdQuery, Doacao>
    {
        private readonly IDoacaoRepository _doacaoRepository;
        public ObterDoacoesPorIdQueryHandler(IDoacaoRepository doacaoRepository)
        {
            _doacaoRepository = doacaoRepository;
        }
        public async Task<Doacao> Handle(ObterDoacoesPorIdQuery request, CancellationToken cancellationToken)
        {
            return await _doacaoRepository.ObterDoacaoPorIdAsync(request.Id);
        }
    }
}