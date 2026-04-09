using SistemaPontoCego.Domain.Entities;
using SistemaPontoCego.Domain.Interfaces;
using SistemaPontoCego.Domain.Interfaces.SistemaPontoCego.Domain.Interfaces;

namespace SistemaPontoCego.Application.Services
{
    public class PagamentosService // Classe que gerencia as regras de negócio para as formas de pagamento
    {
        private readonly IPagamentosRepository _repo; // Campo que guarda a referência do contrato de acesso aos dados

        public PagamentosService(IPagamentosRepository repo) // Construtor que recebe o repositório necessário para o serviço
        {
            _repo = repo; // Inicializa o repositório para permitir a comunicação com o banco de dados
        }

        public List<Pagamento> Listar() // Método que solicita a busca de todos os pagamentos realizados
        {
            return _repo.Listar(); // Pede a lista ao repositório e a envia de volta para a tela (UI)
        }

        public void Adicionar(Pagamento pagamento) // Método que comanda o registro de uma nova transação financeira
        {
            _repo.Adicionar(pagamento); // Envia os dados do novo pagamento para serem gravados no banco
        }
    }