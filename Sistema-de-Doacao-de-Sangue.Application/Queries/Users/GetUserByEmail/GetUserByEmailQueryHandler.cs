using MediatR;
using Sistema_de_Doacao_de_Sangue.Core.Repositories;

namespace Sistema_de_Doacao_de_Sangue.Application.Queries.Users.GetUserByEmail
{
    public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, string>
    {
        private readonly IUserRepository _userRepository;
        public GetUserByEmailQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<string> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetUserByEmailAsync(request.Email);
        }
    }
}