using Sistema_de_Doacao_de_Sangue.Core.Entities;
using Sistema_de_Doacao_de_Sangue.Core.Interfaces;
using Sistema_de_Doacao_de_Sangue.Core.Repositories;

namespace Sistema_de_Doacao_de_Sangue.Infrastructure.Persistence.Repositories
{
    public class UnityOfWork : IUnityOfWork
    {

        private readonly AppDbContext _context;
        private IBaseRepository<Doador> _doadores;
        private IBaseRepository<Endereco> _enderecos;
        private IBaseRepository<Doacao> _doacoes;
        private IBaseRepository<EstoqueSangue> _estoqueSangue;

        public UnityOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IBaseRepository<Doador> Doadores => throw new NotImplementedException();
        public IBaseRepository<Endereco> Enderecos => throw new NotImplementedException();
        public IBaseRepository<Doacao> Doacoes => throw new NotImplementedException();
        public IBaseRepository<EstoqueSangue> EstoqueSangue => throw new NotImplementedException();

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}