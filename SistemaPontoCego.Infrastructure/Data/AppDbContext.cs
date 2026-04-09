using System.Runtime.ConstrainedExecution;
using Microsoft.EntityFrameworkCore;
using SistemaPontoCego.Domain.Entities;

namespace SistemaPontoCego.Infrastructure.Data
{
    public class AppDbContext : DbContext // Classe principal que gerencia a conexão e o mapeamento com o Banco de Dados (Entity Framework)
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) // Construtor que recebe as configurações de conexão (como a String de Conexão)
        {
        }

        // Cada DbSet abaixo representa uma tabela que será criada ou lida no seu banco de dados:

        public DbSet<Produto> Produto { get; set; } // Mapeia a classe Produto para a tabela de Produtos
        public DbSet<Cliente> Cliente { get; set; } // Mapeia a classe Cliente para a tabela de Clientes
        public DbSet<Pedido> Pedido { get; set; } // Mapeia a classe Pedido para a tabela de Pedidos (Vendas)
        public DbSet<Itens_Pedido> ItensPedido { get; set; } // Mapeia os detalhes de cada produto dentro de um pedido
        public DbSet<Estoque> Estoque { get; set; } // Mapeia a tabela que controla as quantidades em estoque
        public DbSet<Categoria> Categoria { get; set; } // Mapeia as categorias (ex: Roupas, Acessórios)
        public DbSet<Cor> Cor { get; set; } // Mapeia as opções de cores para os produtos
        public DbSet<Tamanho> Tamanho { get; set; } // Mapeia as opções de tamanhos (P, M, G)
        public DbSet<Loja> Lojas { get; set; } // Mapeia as informações cadastrais da sua loja
        public DbSet<Pagamento> Pagamento { get; set; } // Mapeia os registros de pagamentos financeiros
    }