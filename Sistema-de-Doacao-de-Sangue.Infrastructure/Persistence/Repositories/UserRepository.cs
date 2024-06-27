using Sistema_de_Doacao_de_Sangue.Core.Entities;
using Sistema_de_Doacao_de_Sangue.Core.Interfaces;
using Sistema_de_Doacao_de_Sangue.Core.Repositories;

namespace Sistema_de_Doacao_de_Sangue.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IUnityOfWork _unitOfWork;
        public UserRepository(IUnityOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddUserAsync(User user)
        {
            var addUser = new User()
            {
                Username = user.Username,
                Password = user.Password
            };

            await _unitOfWork.User.AddAsync(addUser);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<User> GetUserAsync(string userName, string password)
        {
            var user = (await _unitOfWork.User.GetAllAsync()).Where(x => x.Username == userName && x.Password == password).FirstOrDefault();
            return user;
        }
    }
}