using MediatR;
using Sistema_de_Doacao_de_Sangue.Core.DTOs;

namespace Sistema_de_Doacao_de_Sangue.Application.Queries.DoadoresQueries.ObterListagemDeDoadores
{
    public class ObterListagemDeDoadoresQuery : IRequest<IEnumerable<DoadorDTO>>
    {
        
    }
}