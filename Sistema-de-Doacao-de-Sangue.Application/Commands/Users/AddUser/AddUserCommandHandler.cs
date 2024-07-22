using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Sistema_de_Doacao_de_Sangue.Core.Entities;
using Sistema_de_Doacao_de_Sangue.Core.Repositories;

namespace Sistema_de_Doacao_de_Sangue.Application.Commands.Users.AddUser
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        public AddUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Unit> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var addUser = new User()
            {
                Username = request.Username,
                Password = request.Password
            };

            await _userRepository.AddUserAsync(addUser);

            return Unit.Value;
        }
    }
}