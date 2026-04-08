using SistemaPontoCego.Domain.Entities;
using SistemaPontoCego.Domain.Interfaces;
using SistemaPontoCego.Infrastructure.Data;

namespace EstiloUrbano.Infrastructure.Repositories
{
    public class PagamentosRepository : IPagamentosRepository
    {
        private readonly AppDbContext _context;

        public PagamentosRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Pagamento> Listar()
        {
            return _context.Pagamento.ToList();
        }

        public void Adicionar(Pagamento pagamento)
        {
            _context.Pagamento.Add(pagamento);
            _context.SaveChanges();
        }
    }
}