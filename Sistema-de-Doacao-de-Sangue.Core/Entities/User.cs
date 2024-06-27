namespace Sistema_de_Doacao_de_Sangue.Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; } // Em um cenário real, use hash de senha
    }
}