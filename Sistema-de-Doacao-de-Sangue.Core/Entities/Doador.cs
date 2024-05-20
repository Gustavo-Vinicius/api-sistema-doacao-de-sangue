using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_de_Doacao_de_Sangue.Core.Entities
{
    public class Doador
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Genero { get; set; }
        public double Peso { get; set; }
        public string TipoSanguineo { get; set; }
        public string FatorRh { get; set; }
        public List<Doacao> Doacoes { get; set; }
        public Endereco Endereco { get; set; }
    }

}