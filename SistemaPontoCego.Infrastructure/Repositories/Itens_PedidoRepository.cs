using SistemaPontoCego.Domain.Entities;
using SistemaPontoCego.Domain.Interfaces;
using SistemaPontoCego.Infrastructure.Data;
using static ItensPedidoRepository;

public class ItensPedidoRepository : IItens_PedidoRepository
{
    
        private readonly AppDbContext _context; // Campo que armazena a conexão com o banco de dados

        public ItensPedidoRepository(AppDbContext context) // Construtor que recebe o contexto do banco de dados
        {
            _context = context; // Inicializa a conexão para realizar as operações na tabela ItensPedido
        }

        public List<Itens_Pedido> Listar() // Busca todos os itens de pedidos registrados no sistema (geral)
        {
            return _context.ItensPedido.ToList(); // Retorna a lista completa de linhas da tabela ItensPedido no SQL
        }

        public Itens_Pedido? ObterPorId(int id) // Busca um item de pedido específico pelo seu identificador único
        {
            return _context.ItensPedido.FirstOrDefault(i => i.Id_ItemPedido == id); // Procura o primeiro registro com o ID correspondente
        }

        public void Adicionar(Itens_Pedido item) // Registra um novo produto dentro de um pedido no banco
        {
            _context.ItensPedido.Add(item); // Prepara a inserção do item (produto, quantidade, preço unitário)
            _context.SaveChanges(); // Salva permanentemente o item no banco de dados
        }

        public void Atualizar(Itens_Pedido item) // Altera as informações de um item que já foi registrado
        {
            _context.ItensPedido.Update(item); // Marca o item para atualização (ex: mudou a quantidade)
            _context.SaveChanges(); // Grava as alterações no banco de dados
        }

        public void Remover(int id) // Exclui um item de um pedido específico
        {
            var item = ObterPorId(id); // Localiza o item no banco antes de tentar apagar
            if (item != null) // Se o registro for encontrado
            {
                _context.ItensPedido.Remove(item); // Remove a linha da tabela
                _context.SaveChanges(); // Confirma a exclusão no banco de dados
            }
        }

        public List<Itens_Pedido> ListarPorPedido(int pedidoId) // Método planejado para buscar todos os produtos de uma única venda
        {
            // Indica que a lógica para filtrar itens por um Pedido específico ainda será escrita
            throw new NotImplementedException();
        }
    }
