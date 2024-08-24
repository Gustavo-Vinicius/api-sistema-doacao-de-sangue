using MediatR;

namespace Sistema_de_Doacao_de_Sangue.Application.Commands.Users.AddUser
{
    public class AddUserCommand : IRequest<Unit>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}