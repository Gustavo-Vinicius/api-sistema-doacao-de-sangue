using MediatR;
using Sistema_de_Doacao_de_Sangue.Core.DTOs;
using Sistema_de_Doacao_de_Sangue.Core.Repositories;

namespace Sistema_de_Doacao_de_Sangue.Application.Queries.DoadoresQueries.ObterListagemDeDoadores
{
    public class ObterListagemDeDoadoresQueryHandler : IRequestHandler<ObterListagemDeDoadoresQuery, IEnumerable<DoadorDTO>>
    {
        private readonly IDoadoresRepository _doadoresRepository;
        public ObterListagemDeDoadoresQueryHandler(IDoadoresRepository doadoresRepository)
        {
            _doadoresRepository = doadoresRepository;
        }
        public async Task<IEnumerable<DoadorDTO>> Handle(ObterListagemDeDoadoresQuery request, CancellationToken cancellationToken)
        {
            return await _doadoresRepository.ObterDoadoresAsync();
        }
    }
}