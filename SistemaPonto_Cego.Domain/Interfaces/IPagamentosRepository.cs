using SistemaPontoCego.Domain.Entities;

namespace SistemaPontoCego.Domain.Interfaces
{
    public interface IPagamentosRepository
    {
        List<Pagamento> Listar();
        void Adicionar(Pagamento pagamento);
    }
}