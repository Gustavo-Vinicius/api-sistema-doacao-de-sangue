using MediatR;
using Sistema_de_Doacao_de_Sangue.Core.DTOs;

namespace Sistema_de_Doacao_de_Sangue.Application.Queries.DoadoresQueries.ObterDoacoesPorDoador
{
    public class ObterDoacoesPorDoadorQuery : IRequest<IEnumerable<DoacaoDTO>>
    {
        public int Id { get; set; }
    }
}