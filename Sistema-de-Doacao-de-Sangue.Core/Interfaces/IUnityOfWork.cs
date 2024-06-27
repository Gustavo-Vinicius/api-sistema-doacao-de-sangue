using Sistema_de_Doacao_de_Sangue.Core.Entities;
using Sistema_de_Doacao_de_Sangue.Core.Repositories;

namespace Sistema_de_Doacao_de_Sangue.Core.Interfaces
{
    public interface IUnityOfWork : IDisposable
    {
        IBaseRepository<Doador> Doadores { get; }
        IBaseRepository<Endereco> Enderecos { get; }
        IBaseRepository<Doacao> Doacoes { get; }
        IBaseRepository<EstoqueSangue> EstoqueSangue { get; }
        IBaseRepository<User> User { get; }
        Task<int> CompleteAsync();
    }
}