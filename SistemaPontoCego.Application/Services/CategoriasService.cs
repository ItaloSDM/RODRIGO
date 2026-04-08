using SistemaPontoCego.Domain.Entities;
using SistemaPontoCego.Domain.Interfaces;

public class CategoriasService
{
    private readonly ICategoriasRepository _repo; //contrato

    public CategoriasService(ICategoriasRepository repo) //É o Intermediário que organiza as regras antes de entregar o resultado.
    {
        _repo = repo; //ferramenta que o servico usa pra falar com os dados
    }

    public List<Categoria> Listar()
    {
        return _repo.Listar();
    }
}