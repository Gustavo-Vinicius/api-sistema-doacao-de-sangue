using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Sistema_de_Doacao_de_Sangue.Core.DTOs;

namespace Sistema_de_Doacao_de_Sangue.Application.Queries.EstoqueQueries.ObterListagemDeEstoqueSanguineo
{
    public class ObterListagemDeEstoqueSanguineoQuery : IRequest<IEnumerable<EstoqueSangueDTO>>
    {
                
    }
}