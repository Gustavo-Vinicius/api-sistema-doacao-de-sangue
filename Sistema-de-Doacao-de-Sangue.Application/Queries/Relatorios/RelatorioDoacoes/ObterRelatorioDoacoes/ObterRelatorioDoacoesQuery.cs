using MediatR;
using Sistema_de_Doacao_de_Sangue.Core.DTOs;

namespace Sistema_de_Doacao_de_Sangue.Application.Queries.Relatorios.RelatorioDoacoes.ObterRelatorioDoacoes
{
    public class ObterRelatorioDoacoesQuery : IRequest<IEnumerable<RelatorioDoacoesDTO>>
    {
        
    }
}