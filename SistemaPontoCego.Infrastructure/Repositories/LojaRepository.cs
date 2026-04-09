using SistemaPontoCego.Domain.Entities;
using SistemaPontoCego.Domain.Interfaces;
using SistemaPontoCego.Infrastructure.Data;

public class LojaRepository : ILojaRepository
{
 
        private readonly AppDbContext _context; // Campo que armazena a conexão com o banco de dados via Entity Framework

        public LojaRepository(AppDbContext context) // Construtor que recebe o contexto para realizar as operações
        {
            _context = context; // Inicializa o contexto para uso em todos os métodos da classe
        }

        public List<Loja> Listar() // Método que busca todas as lojas cadastradas (caso o sistema aceite várias)
        {
            return _context.Lojas.ToList(); // Acessa a tabela Lojas e transforma os registros em uma lista C#
        }

        public Loja? ObterPorId(int id) // Busca uma loja específica através do seu ID único
        {
            return _context.Lojas.FirstOrDefault(l => l.Id_Loja == id); // Procura a primeira loja que coincida com o ID informado
        }

        public void Adicionar(Loja loja) // Método que insere as informações da loja no banco de dados
        {
            _context.Lojas.Add(loja); // Adiciona o objeto loja à fila de inserção do contexto
            _context.SaveChanges(); // Salva permanentemente os dados da loja no banco SQL
        }

        public void Atualizar(Loja loja) // Método que grava alterações nos dados da loja (ex: mudou o telefone ou endereço)
        {
            _context.Lojas.Update(loja); // Marca o registro da loja como modificado
            _context.SaveChanges(); // Envia as atualizações para o banco de dados
        }

        public void Remover(int id) // Método que exclui o registro de uma loja do sistema
        {
            var loja = ObterPorId(id); // Localiza a loja no banco antes de tentar apagar
            if (loja != null) // Se a loja for encontrada (não for nula)
            {
                _context.Lojas.Remove(loja); // Solicita a remoção do registro da tabela
                _context.SaveChanges(); // Confirma a exclusão definitiva no banco de dados
            }
        }

        public Loja Obter() // Método planejado para retornar a loja principal do sistema
        {
            // Indica que a lógica para buscar "a única loja" ou "a loja padrão" ainda será escrita
            throw new NotImplementedException();
        }
    }
}