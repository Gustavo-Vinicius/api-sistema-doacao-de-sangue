using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Doacao_de_Sangue.Core.DTOs
{
    public class RelatorioEstoqueDTO
    {
        public string TipoSanguineo { get; set; }
        public string FatorRh { get; set; }
        public int QuantidadeTotalML { get; set; }
    }
}