using SistemaPontoCego.Domain.Entities;
using SistemaPontoCego.Domain.Interfaces;

public class TamanhosService // Classe que gerencia a lógica de negócio para os tamanhos dos produtos (P, M, G, etc)
{
    private readonly ITamanhosRepository _repo; // Campo privado que guarda o contrato de acesso aos dados de tamanhos

    public TamanhosService(ITamanhosRepository repo) // Construtor que recebe o repositório necessário via injeção de dependência
    {
        _repo = repo; // Inicializa o repositório para que ele possa ser usado nos métodos da classe
    }

    public List<Tamanho> Listar() // Método que solicita a lista de todos os tamanhos cadastrados no sistema
    {
        return _repo.Listar(); // Pede ao repositório para buscar os tamanhos no banco e entrega o resultado para a tela (UI)
    }
}