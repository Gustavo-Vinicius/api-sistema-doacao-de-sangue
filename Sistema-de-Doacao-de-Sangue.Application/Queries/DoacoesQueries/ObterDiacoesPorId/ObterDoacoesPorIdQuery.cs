using MediatR;
using Sistema_de_Doacao_de_Sangue.Core.Entities;

namespace Sistema_de_Doacao_de_Sangue.Application.Queries.DoacoesQueries.ObterDiacoesPorId
{
    public class ObterDoacoesPorIdQuery : IRequest<Doacao>
    {
        public int Id { get; set; }
    }
}