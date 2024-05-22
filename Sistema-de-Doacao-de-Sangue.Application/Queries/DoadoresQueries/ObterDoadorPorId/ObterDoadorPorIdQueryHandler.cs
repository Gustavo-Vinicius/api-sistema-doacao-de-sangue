using MediatR;
using Sistema_de_Doacao_de_Sangue.Core.DTOs;
using Sistema_de_Doacao_de_Sangue.Core.Repositories;

namespace Sistema_de_Doacao_de_Sangue.Application.Queries.DoadoresQueries.ObterDoadorPorId
{
    public class ObterDoadorPorIdQueryHandler : IRequestHandler<ObterDoadorPorIdQuery, DoadorDTO>
    {
        private readonly IDoadoresRepository _doadoresRepository;
        public ObterDoadorPorIdQueryHandler(IDoadoresRepository doadoresRepository)
        {
            _doadoresRepository = doadoresRepository;
        }
        public async Task<DoadorDTO> Handle(ObterDoadorPorIdQuery request, CancellationToken cancellationToken)
        {
            return await _doadoresRepository.ObterDoadorPorId(request.Id);
        }
    }
}