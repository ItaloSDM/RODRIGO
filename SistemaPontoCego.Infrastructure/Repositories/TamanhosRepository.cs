using SistemaPontoCego.Domain.Entities;
using SistemaPontoCego.Domain.Interfaces;
using SistemaPontoCego.Infrastructure.Data;

namespace SistemaPontoCego.Infrastructure.Repositories
{
    public class TamanhosRepository : ITamanhosRepository // Implementa o contrato de acesso a dados para a entidade Tamanho (P, M, G, etc.)
    {
        private readonly AppDbContext _context; // Campo que armazena a conexão com o banco de dados via Entity Framework

        public TamanhosRepository(AppDbContext context) // Construtor que recebe o contexto para realizar as operações de banco
        {
            _context = context; // Inicializa o contexto para uso em todos os métodos da classe
        }

        public List<Tamanho> Listar() // Método que busca todos os tamanhos cadastrados no sistema
        {
            return _context.Tamanho.ToList(); // Acessa a tabela Tamanho e transforma os registros em uma lista C#
        }

        public Tamanho? ObterPorId(int id) // Busca um tamanho específico através do seu ID único
        {
            return _context.Tamanho
                .FirstOrDefault(t => t.Id_Tamanho == id); // Procura o primeiro tamanho que coincida com o ID informado
        }

        public void Adicionar(Tamanho tamanho) // Método que insere um novo tamanho no banco de dados
        {
            _context.Tamanho.Add(tamanho); // Adiciona o objeto tamanho à fila de inserção do contexto
            _context.SaveChanges(); // Salva permanentemente o novo registro no banco de dados SQL
        }

        public void Atualizar(Tamanho tamanho) // Método que grava alterações em um tamanho já existente
        {
            _context.Tamanho.Update(tamanho); // Marca o registro como modificado no banco
            _context.SaveChanges(); // Envia as atualizações para o banco de dados
        }

        public void Remover(int id) // Método que exclui um tamanho do sistema com base no seu código (ID)
        {
            var tamanho = _context.Tamanho
                .FirstOrDefault(t => t.Id_Tamanho == id); // Localiza o tamanho no banco antes de tentar apagar

            if (tamanho != null) // Se o tamanho for encontrado (não for nulo)
            {
                _context.Tamanho.Remove(tamanho); // Solicita a remoção do registro da tabela
                _context.SaveChanges(); // Confirma a exclusão definitiva no banco de dados
            }
        }
    }
}