using MediatR;

namespace Sistema_de_Doacao_de_Sangue.Application.Commands.Users.AddUser
{
    public class AddUserCommand : IRequest<Unit>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}