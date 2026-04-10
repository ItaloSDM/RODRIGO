using System.Runtime.ConstrainedExecution;
using Microsoft.EntityFrameworkCore;
using SistemaPontoCego.Domain.Entities;

namespace SistemaPontoCego.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
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
} // <--- FALTAVA ESSA CHAVE AQUI PARA FECHAR O NAMESPACE