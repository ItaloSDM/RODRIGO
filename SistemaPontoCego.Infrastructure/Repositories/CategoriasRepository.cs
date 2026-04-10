using SistemaPontoCego.Domain.Entities;
using SistemaPontoCego.Domain.Interfaces;
using SistemaPontoCego.Infrastructure.Data;

public class CategoriasRepository : ICategoriasRepository // Implementa o contrato definido na interface de categorias
{
    private readonly AppDbContext _context; // Campo que armazena a conexão com o banco de dados

    public CategoriasRepository(AppDbContext context) // Construtor que recebe o contexto do banco de dados
    {
        _context = context; // Inicializa o contexto para realizar as operações de dados
    }

    public List<Categoria> Listar() // Método que busca todas as categorias cadastradas
    {
        return _context.Categoria.ToList(); // Converte a tabela de categorias do banco em uma lista do C#
    }

    public Categoria? ObterPorId(int id) // Busca uma categoria específica usando o seu código identificador
    {
        return _context.Categoria.FirstOrDefault(c => c.Id_Categoria == id); // Procura no banco o primeiro registro com o ID correspondente
    }

    public void Adicionar(Categoria categoria) // Método que insere uma nova categoria no sistema
    {
        _context.Categoria.Add(categoria); // Prepara o objeto para ser inserido na tabela
        _context.SaveChanges(); // Salva as alterações de fato no banco de dados (confirma a transação)
    }

    public void Atualizar(Categoria categoria) // Método que altera os dados de uma categoria já existente
    {
        _context.Categoria.Update(categoria); // Marca o objeto para atualização no banco de dados
        _context.SaveChanges(); // Efetiva a alteração no banco de dados
    }

    public void Remover(int id) // Método que deleta uma categoria do sistema
    {
        var categoria = ObterPorId(id); // Tenta localizar a categoria antes de tentar apagar
        if (categoria != null) // Verifica se a categoria realmente existe no banco
        {
            _context.Categoria.Remove(categoria); // Marca o registro para ser excluído
            _context.SaveChanges(); // Confirma a exclusão permanentemente no banco
        }
    }
}
    
