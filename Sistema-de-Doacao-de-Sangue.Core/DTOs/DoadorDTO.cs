namespace Sistema_de_Doacao_de_Sangue.Core.DTOs
{
    public class DoadorDTO
    {
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Genero { get; set; }
        public double Peso { get; set; }
        public string TipoSanguineo { get; set; }
        public string FatorRh { get; set; }
    }
}