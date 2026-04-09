using SistemaPontoCego.Domain.Entities;
using SistemaPontoCego.Domain.Interfaces;

public class ClientesService // Classe responsável por aplicar as regras de negócio para os Clientes
{
    private readonly IClientesRepository _repo; // Campo que guarda a referência do repositório de clientes

    public ClientesService(IClientesRepository repo) // Construtor que recebe a ferramenta de acesso aos dados
    {
        _repo = repo; // Inicializa o repositório para que possa ser usado nos métodos abaixo
    }

    public void Adicionar(Cliente cliente) // Método que comanda a ação de cadastrar um novo cliente
    {
        _repo.Adicionar(cliente); // Repassa o objeto cliente para o repositório salvar no banco
    }

    public List<Cliente> Listar() // Método que solicita a busca de todos os clientes cadastrados
    {
        return _repo.Listar(); // Retorna a lista vinda do banco de dados para a interface de usuário
    }
}