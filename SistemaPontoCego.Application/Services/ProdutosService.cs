using SistemaPontoCego.Domain.Entities;
using SistemaPontoCego.Domain.Interfaces;

public class ProdutosService // Classe responsável por aplicar as regras de negócio no gerenciamento de produtos
{
    private readonly IProdutosRepository _repo; // Campo que armazena a referência do contrato de dados (repositório)

    public ProdutosService(IProdutosRepository repo) // Construtor que recebe a ferramenta de acesso ao banco por injeção
    {
        _repo = repo; // Inicializa o repositório para que possa ser utilizado em todos os métodos abaixo
    }

    public void Adicionar(Produto produto) // Método para cadastrar produtos que inclui uma trava de segurança (validação)
    {
        if (string.IsNullOrEmpty(produto.Nome_Produto)) // Verifica se o usuário esqueceu de preencher o nome do produto
            throw new Exception("Nome do produto é obrigatório"); // Se estiver vazio, gera um erro e impede a gravação no banco

        _repo.Adicionar(produto); // Se o nome estiver preenchido, envia os dados para o repositório salvar
    }

    public List<Produto> Listar() // Método que busca a lista de todos os itens cadastrados no sistema
    {
        return _repo.Listar(); // Retorna os produtos para que a tela (UI) possa exibi-los em uma lista ou grid
    }

    public void Remover(int id) // Método que comanda a exclusão de um item específico através do seu código (ID)
    {
        _repo.Remover(id); // Solicita ao repositório que apague o registro correspondente no banco de dados
    }
}