using SistemaPontoCego.Domain.Entities;
using SistemaPontoCego.Domain.Interfaces;
using SistemaPontoCego.Infrastructure.Data;

public class PedidosRepository : IPedidosRepository
{
   
        private readonly AppDbContext _context; // Campo que armazena a conexão com o banco de dados

        public PedidosRepository(AppDbContext context) // Construtor que recebe o contexto para realizar as operações
        {
            _context = context; // Inicializa o contexto para uso em todos os métodos da classe
        }

        public List<Pedido> Listar() // Método que busca todo o histórico de pedidos realizados no sistema
        {
            return _context.Pedido.ToList(); // Acessa a tabela Pedido e transforma os registros em uma lista C#
        }

        public Pedido? ObterPorId(int id) // Busca um pedido específico através do seu número identificador (ID)
        {
            return _context.Pedido.FirstOrDefault(p => p.Id_Pedido == id); // Procura o primeiro pedido que tenha o ID correspondente
        }

        public void Adicionar(Pedido pedido) // Método para inserir um novo cabeçalho de pedido no banco
        {
            _context.Pedido.Add(pedido); // Prepara o objeto pedido para ser gravado na tabela
            _context.SaveChanges(); // Salva permanentemente o pedido no banco de dados SQL
        }

        public void Atualizar(Pedido pedido) // Método que grava alterações em um pedido já existente
        {
            _context.Pedido.Update(pedido); // Marca o registro do pedido como modificado
            _context.SaveChanges(); // Envia as atualizações para o banco de dados
        }

        public void Remover(int id) // Método que exclui um pedido do sistema através do ID
        {
            var pedido = ObterPorId(id); // Localiza o pedido no banco antes de tentar apagar
            if (pedido != null) // Se o pedido for encontrado (não for nulo)
            {
                _context.Pedido.Remove(pedido); // Solicita a remoção do registro da tabela
                _context.SaveChanges(); // Confirma a exclusão definitiva no banco de dados
            }
        }

        public void CriarPedido(Pedido pedido) // Método planejado para uma lógica de criação mais complexa
        {
            // Indica que a lógica específica de criação (talvez envolvendo itens) ainda será escrita
            throw new NotImplementedException();
        }
    }
