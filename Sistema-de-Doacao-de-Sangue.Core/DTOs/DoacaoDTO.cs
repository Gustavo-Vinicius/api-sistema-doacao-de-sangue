namespace Sistema_de_Doacao_de_Sangue.Core.DTOs
{
    public class DoacaoDTO
    {
        public int DoadorId { get; set; }
        public DateTime DataDoacao { get; set; }
        public int QuantidadeML { get; set; }
    }
}