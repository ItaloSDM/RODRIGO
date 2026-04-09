using SistemaPontoCego.Domain.Entities;
using SistemaPontoCego.Domain.Interfaces;
using SistemaPontoCego.Infrastructure.Data;

public class CoresRepository : ICoresRepository
{
  
        private readonly AppDbContext _context; // Campo que armazena a conexão com o banco de dados via Entity Framework

        public CoresRepository(AppDbContext context) // Construtor que recebe o contexto para realizar as operações
        {
            _context = context; // Inicializa o contexto para uso em todos os métodos da classe
        }

        public List<Cor> Listar() // Método que busca todas as cores cadastradas no sistema
        {
            return _context.Cor.ToList(); // Acessa a tabela Cor e transforma os registros em uma lista de objetos C#
        }

        public Cor? ObterPorId(int id) // Busca uma cor específica usando o seu identificador único (ID)
        {
            return _context.Cor.FirstOrDefault(c => c.Id_Cor == id); // Procura a primeira cor que tenha o ID correspondente
        }

        public void Adicionar(Cor cor) // Método que insere uma nova cor no banco de dados
        {
            _context.Cor.Add(cor); // Adiciona o objeto cor à fila de inserção do contexto
            _context.SaveChanges(); // Salva permanentemente a nova cor no banco de dados SQL
        }

        public void Atualizar(Cor cor) // Método que grava alterações em uma cor já cadastrada
        {
            _context.Cor.Update(cor); // Marca o registro da cor como modificado para o banco
            _context.SaveChanges(); // Envia as atualizações para o banco de dados
        }

        public void Remover(int id) // Método que exclui uma cor do sistema através do seu ID
        {
            var cor = ObterPorId(id); // Tenta localizar a cor no banco antes de deletar
            if (cor != null) // Se a cor for encontrada (não for nula)
            {
                _context.Cor.Remove(cor); // Solicita a remoção do registro da tabela
                _context.SaveChanges(); // Confirma a exclusão definitiva no banco de dados
            }
        }
}
