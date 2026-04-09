using SistemaPontoCego.Domain.Interfaces;

public class EstoqueService // Classe responsável por gerenciar as regras de movimentação de produtos
{
    private readonly IEstoqueRepository _repo; // Campo que armazena o contrato de acesso aos dados de estoque

    public EstoqueService(IEstoqueRepository repo) // Construtor que recebe o repositório necessário para o serviço funcionar
    {
        _repo = repo; // Guarda a referência do repositório para ser usada nos métodos da classe
    }

    public void Atualizar(int produtoId, int quantidade) // Método que recebe as informações para alterar o saldo de um item
    {
        _repo.AtualizarEstoque(produtoId, quantidade); // Envia o código do produto e a nova quantidade para gravação no banco
    }
}