using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_de_Doacao_de_Sangue.Core.Entities
{
    public class Doacao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int DoadorId { get; set; }
        public DateTime DataDoacao { get; set; }
        public int QuantidadeML { get; set; }
        public Doador Doador { get; set; }
    }

}