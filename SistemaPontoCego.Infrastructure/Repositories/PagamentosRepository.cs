using SistemaPontoCego.Domain.Entities;
using SistemaPontoCego.Domain.Interfaces;
using SistemaPontoCego.Domain.Interfaces.SistemaPontoCego.Domain.Interfaces;
using SistemaPontoCego.Infrastructure.Data;

namespace EstiloUrbano.Infrastructure.Repositories
{
    public class PagamentosRepository : IPagamentosRepository // Implementa o contrato de persistência para as transações financeiras
    {
        private readonly AppDbContext _context; // Campo que armazena a conexão com o banco de dados via Entity Framework

        public PagamentosRepository(AppDbContext context) // Construtor que recebe a conexão (contexto) para poder operar no banco
        {
            _context = context; // Inicializa o contexto para uso em todos os métodos da classe
        }

        public List<Pagamento> Listar() // Método que busca o histórico completo de pagamentos realizados
        {
            return _context.Pagamento.ToList(); // Acessa a tabela Pagamento no SQL e transforma os dados em uma lista C#
        }

        public void Adicionar(Pagamento pagamento) // Método responsável por gravar uma nova entrada de valor no sistema
        {
            _context.Pagamento.Add(pagamento); // Adiciona as informações do pagamento (valor, tipo, data) ao contexto
            _context.SaveChanges(); // Confirma a gravação definitiva no banco de dados (o "Commit")
        }
    }
}
