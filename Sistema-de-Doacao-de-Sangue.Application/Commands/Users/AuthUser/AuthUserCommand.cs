using MediatR;
using Sistema_de_Doacao_de_Sangue.Core.DTOs;

namespace Sistema_de_Doacao_de_Sangue.Application.Commands.Users.AuthUser
{
    public class AuthUserCommand: IRequest<UserTokenReturnDTO>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}