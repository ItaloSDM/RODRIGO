using SistemaPontoCego.Domain.Entities;
using SistemaPontoCego.Domain.Interfaces;
using SistemaPontoCego.Infrastructure.Data;

public class EstoqueRepository : IEstoqueRepository
{
  
        private readonly AppDbContext _context; // Campo que armazena a conexão com o banco de dados

        public EstoqueRepository(AppDbContext context) // Construtor que recebe a conexão (contexto) para operar no banco
        {
            _context = context; // Inicializa o contexto para uso em todos os métodos da classe
        }

        public List<Estoque> Listar() // Método que traz todos os registros de estoque do banco
        {
            return _context.Estoque.ToList(); // Acessa a tabela Estoque e converte os dados em uma lista C#
        }

        public Estoque? ObterPorId(int id) // Busca um registro de estoque específico através do ID
        {
            return _context.Estoque.FirstOrDefault(e => e.Id_Estoque == id); // Procura o primeiro registro que tenha o ID correspondente
        }

        public void Adicionar(Estoque estoque) // Método para inserir um novo registro de estoque no sistema
        {
            _context.Estoque.Add(estoque); // Adiciona o objeto estoque à fila de inserção do contexto
            _context.SaveChanges(); // Salva permanentemente a informação no banco de dados SQL
        }

        public void Atualizar(Estoque estoque) // Método que grava alterações em um registro de estoque existente
        {
            _context.Estoque.Update(estoque); // Marca o registro como modificado no banco
            _context.SaveChanges(); // Envia as atualizações para o banco de dados
        }

        public void Remover(int id) // Método que exclui um registro de estoque do sistema
        {
            var estoque = ObterPorId(id); // Localiza o registro no banco antes de tentar apagar
            if (estoque != null) // Se o registro for encontrado (não for nulo)
            {
                _context.Estoque.Remove(estoque); // Solicita a remoção do registro da tabela
                _context.SaveChanges(); // Confirma a exclusão definitiva no banco de dados
            }
        }

        public void AtualizarEstoque(int produtoId, int quantidade) // Método especial para alterar o saldo de um produto específico
        {
            // Este comando indica que a lógica de atualização ainda será desenvolvida
            throw new NotImplementedException();
        }
    }
}