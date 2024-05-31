using MediatR;
using Sistema_de_Doacao_de_Sangue.Core.DTOs;

namespace Sistema_de_Doacao_de_Sangue.Application.Queries.EstoqueQueries.ObterEstoquePorTipo
{
    public class ObterEstoquePorTipoQuery : IRequest<EstoqueSangueDTO>
    {
        public string TipoSanguineo { get; set; }
        public string FatorRh { get; set; }
    }
}