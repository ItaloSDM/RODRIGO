using SistemaPontoCego.Domain.Entities;
using SistemaPontoCego.Domain.Interfaces;

public class CategoriasService // Classe que gerencia as regras de negócio das categorias
{
    private readonly ICategoriasRepository _repo; // Campo privado que armazena a interface (contrato) de dados

    public CategoriasService(ICategoriasRepository repo) // Construtor: Recebe o repositório por Injeção de Dependência
    {
        _repo = repo; // Atribui o repositório recebido ao campo interno para uso na classe
    }

    public List<Categoria> Listar() // Método que solicita a lista de categorias para a camada de dados
    {
        return _repo.Listar(); // Chama o repositório e retorna o resultado final para quem solicitou
    }
}