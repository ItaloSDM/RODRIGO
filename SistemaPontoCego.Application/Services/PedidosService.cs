using SistemaPontoCego.Domain.Entities;
using SistemaPontoCego.Domain.Interfaces;

public class PedidosService // Classe responsável pelas regras de negócio relacionadas às vendas (pedidos)
{
    private readonly IPedidosRepository _repo; // Campo que armazena a interface para comunicação com o banco de dados

    public PedidosService(IPedidosRepository repo) // Construtor que recebe o repositório por Injeção de Dependência
    {
        _repo = repo; // Inicializa o repositório para ser usado nos métodos da classe
    }

    public void Criar(Pedido pedido) // Método que prepara e registra um novo pedido no sistema
    {
        pedido.Data_Pedido = DateTime.Now; // Regra de Negócio: Carimba o pedido com a data e hora exata do momento da venda
        _repo.CriarPedido(pedido); // Envia o pedido já com a data preenchida para o repositório salvar no banco
    }

    public List<Pedido> Listar() // Método que solicita a lista histórica de todos os pedidos realizados
    {
        return _repo.Listar(); // Retorna a coleção de pedidos vinda do banco para ser exibida na tela (UI)
    }
}