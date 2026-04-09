using SistemaPontoCego.Domain.Entities;
using SistemaPontoCego.Domain.Interfaces;

ppublic class LojaService // Classe que gerencia as informações e configurações da Loja
{
    private readonly ILojaRepository _repo; // Campo que guarda o contrato de acesso aos dados da loja

    public LojaService(ILojaRepository repo) // Construtor que recebe o repositório por injeção de dependência
    {
        _repo = repo; // Inicializa o repositório para uso nos métodos de salvar e obter
    }

    public void Salvar(Loja loja) // Método inteligente que decide se deve criar ou apenas editar os dados
    {
        var existente = _repo.Obter(); // Tenta buscar se já existe algum cadastro da loja no banco

        if (existente == null) // Se não encontrar nenhum registro (retornar nulo)
            _repo.Adicionar(loja); // Comando para criar o primeiro cadastro da loja no sistema
        else // Caso o sistema já tenha os dados da loja cadastrados
            _repo.Atualizar(loja); // Comando para apenas atualizar as informações existentes
    }

    public Loja Obter() // Método que busca os dados atuais da loja (nome, endereço, etc)
    {
        return _repo.Obter(); // Retorna os dados encontrados para serem exibidos na tela (UI)
    }
}