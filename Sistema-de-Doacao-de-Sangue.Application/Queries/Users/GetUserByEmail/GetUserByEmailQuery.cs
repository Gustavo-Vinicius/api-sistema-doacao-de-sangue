using MediatR;

namespace Sistema_de_Doacao_de_Sangue.Application.Queries.Users.GetUserByEmail
{
    public class GetUserByEmailQuery : IRequest<string>
    {
        public string Email { get; set; }
    }
}