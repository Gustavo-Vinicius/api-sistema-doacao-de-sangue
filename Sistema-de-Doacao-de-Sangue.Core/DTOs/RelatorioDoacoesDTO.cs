using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Doacao_de_Sangue.Core.DTOs
{
    public class RelatorioDoacoesDTO
    {
        public int Id { get; set; }
        public int DoadorId { get; set; }
        public DateTime DataDoacao { get; set; }
        public int QuantidadeML { get; set; }
        public string NomeDoador { get; set; }
        public string EmailDoador { get; set; }
    }
}