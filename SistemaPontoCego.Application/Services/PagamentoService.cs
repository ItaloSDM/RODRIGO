using SistemaPontoCego.Domain.Entities;
using SistemaPontoCego.Domain.Interfaces;

namespace SistemaPontoCego.Application.Services
{
    public class PagamentosService
    {
        private readonly IPagamentosRepository _repo;

        public PagamentosService(IPagamentosRepository repo)
        {
            _repo = repo;
        }

        public List<Pagamento> Listar()
        {
            return _repo.Listar();
        }

        public void Adicionar(Pagamento pagamento)
        {
            _repo.Adicionar(pagamento);
        }
    }
}