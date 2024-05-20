using Microsoft.EntityFrameworkCore;
using Sistema_de_Doacao_de_Sangue.Core.Entities;

namespace Sistema_de_Doacao_de_Sangue.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Doacao> Doacaos { get; set; }
        public DbSet<Doador> Doadors { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<EstoqueSangue> EstoqueSangues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doador>()
                .HasIndex(d => d.Email)
                .IsUnique();
        }

    }
}