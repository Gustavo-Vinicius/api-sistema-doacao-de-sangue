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

        public IBaseRepository<Doador> Doadores => _doadores ??= new BaseRepository<Doador>(_context);
        public IBaseRepository<Endereco> Enderecos => _enderecos ??= new BaseRepository<Endereco>(_context);
        public IBaseRepository<Doacao> Doacoes => _doacoes ??= new BaseRepository<Doacao>(_context);
        public IBaseRepository<EstoqueSangue> EstoqueSangue => _estoqueSangue ??= new BaseRepository<EstoqueSangue>(_context);

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