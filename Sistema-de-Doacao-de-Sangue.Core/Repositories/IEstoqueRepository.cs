using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sistema_de_Doacao_de_Sangue.Core.DTOs;

namespace Sistema_de_Doacao_de_Sangue.Core.Repositories
{
    public interface IEstoqueRepository
    {
        Task<IEnumerable<EstoqueSangueDTO>> ObterEstoqueDeSangueAsync();
        Task<EstoqueSangueDTO> ObterEstoquePorTipoAsync(string tipoSanguineo, string fatorRh);

    }
}