using MediatR;
using Sistema_de_Doacao_de_Sangue.Core.DTOs;
using Sistema_de_Doacao_de_Sangue.Core.Interfaces.Services;
using Sistema_de_Doacao_de_Sangue.Core.Repositories;
using Sistema_de_Doacao_de_Sangue.Core.Services;

namespace Sistema_de_Doacao_de_Sangue.Application.Commands.Users.AuthUser
{
    public class AuthUserCommandHandler : IRequestHandler<AuthUserCommand, UserTokenReturnDTO>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        public AuthUserCommandHandler(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }
        public async Task<UserTokenReturnDTO> Handle(AuthUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserAsync(request.Username, request.Password);

            if (user == null)
            {
                throw new Exception("Usuario ou senha invalidos");
            }

            var token = _tokenService.GenerateToken(user);

            user.Password = " ";

            return new UserTokenReturnDTO
            {
                Id = user.Id,
                UserName = request.Username,
                Token = token
            };
        }
    }
}