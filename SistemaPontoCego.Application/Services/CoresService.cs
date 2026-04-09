using SistemaPontoCego.Domain.Entities;
using SistemaPontoCego.Domain.Interfaces;

public class CoresService // Classe que organiza a lógica de negócio relacionada às cores dos produtos
{
    private readonly ICoresRepository _repo; // Campo que armazena a interface (contrato) para acessar os dados de cores

    public CoresService(ICoresRepository repo) // Construtor que recebe a ferramenta de acesso ao banco por injeção
    {
        _repo = repo; // Guarda a ferramenta no campo interno para ser usada em toda a classe
    }

    public List<Cor> Listar() // Método que solicita a lista completa de cores disponíveis no sistema
    {
        return _repo.Listar(); // Pede ao repositório as cores do banco e entrega o resultado para a tela (UI)
    }
}