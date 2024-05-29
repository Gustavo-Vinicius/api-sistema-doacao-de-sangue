using MediatR;
using Sistema_de_Doacao_de_Sangue.Core.DTOs;
using Sistema_de_Doacao_de_Sangue.Core.Repositories;

namespace Sistema_de_Doacao_de_Sangue.Application.Queries.DoadoresQueries.ObterDoacoesPorDoador
{
    public class ObterDoacoesPorDoadorQueryHandler : IRequestHandler<ObterDoacoesPorDoadorQuery, IEnumerable<DoacaoDTO>>
    {
        private readonly IDoadoresRepository _doadoresRepository;
        public ObterDoacoesPorDoadorQueryHandler(IDoadoresRepository doadoresRepository)
        {
            _doadoresRepository = doadoresRepository;
        }
        public async Task<IEnumerable<DoacaoDTO>> Handle(ObterDoacoesPorDoadorQuery request, CancellationToken cancellationToken)
        {
           return await _doadoresRepository.ObterDoacoesPorDoadorAsync(request.Id);
        }
    }
}