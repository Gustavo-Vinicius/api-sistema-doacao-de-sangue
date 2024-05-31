using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Sistema_de_Doacao_de_Sangue.Core.DTOs;
using Sistema_de_Doacao_de_Sangue.Core.Repositories;

namespace Sistema_de_Doacao_de_Sangue.Application.Queries.Relatorios.RelatorioDoacoes.ObterRelatorioDoacoes
{
    public class ObterRelatorioDoacoesQueryHandler : IRequestHandler<ObterRelatorioDoacoesQuery, IEnumerable<RelatorioDoacoesDTO>>
    {
        private readonly IRelatoriosRepository _relatoriosRepository;
        public ObterRelatorioDoacoesQueryHandler(IRelatoriosRepository relatoriosRepository)
        {
            _relatoriosRepository = relatoriosRepository;
        }
        public async Task<IEnumerable<RelatorioDoacoesDTO>> Handle(ObterRelatorioDoacoesQuery request, CancellationToken cancellationToken)
        {
            return await _relatoriosRepository.ObterRelatorioDoacoesAsync();
        }
    }
}