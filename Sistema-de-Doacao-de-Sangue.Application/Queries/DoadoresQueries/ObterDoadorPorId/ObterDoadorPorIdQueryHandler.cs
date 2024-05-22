using MediatR;
using Sistema_de_Doacao_de_Sangue.Core.DTOs;

namespace Sistema_de_Doacao_de_Sangue.Application.Queries.DoadoresQueries.ObterDoadorPorId
{
    public class ObterDoadorPorIdQueryHandler : IRequest<DoadorDTO>
    {
        public int Id { get; set; }
    }
}