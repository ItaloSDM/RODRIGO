using Microsoft.EntityFrameworkCore;
using SistemaPontoCego.Domain.Entities;

namespace SistemaPontoCego.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Conexão oficial para o seu SQLEXPRESS
                optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=SistemaPontoCego;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        public DbSet<Produto> Produto { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Itens_Pedido> ItensPedido { get; set; }
        public DbSet<Estoque> Estoque { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Cor> Cor { get; set; }
        public DbSet<Tamanho> Tamanho { get; set; }
        public DbSet<Loja> Lojas { get; set; }
        public DbSet<Pagamento> Pagamento { get; set; }
    }
}