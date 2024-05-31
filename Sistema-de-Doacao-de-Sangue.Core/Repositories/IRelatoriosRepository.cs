using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sistema_de_Doacao_de_Sangue.Core.DTOs;

namespace Sistema_de_Doacao_de_Sangue.Core.Repositories
{
    public interface IRelatoriosRepository
    {
        Task<IEnumerable<RelatorioEstoqueDTO>> ObterRelatorioEstoqueAsync();
        Task<IEnumerable<RelatorioDoacoesDTO>> ObterRelatorioDoacoesAsync();
    }
}