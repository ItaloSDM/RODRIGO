using SistemaPontoCego.Domain.Entities;

namespace SistemaPontoCego.Domain.Interfaces
{
    namespace SistemaPontoCego.Domain.Interfaces // Organiza o código dentro da pasta de Interfaces do Domínio
    {
        public interface IPagamentosRepository // Declaração da Interface (o "contrato" de métodos do sistema)
        {
            List<Pagamento> Listar(); // Método que busca e retorna uma lista com todos os registros de pagamentos

            void Adicionar(Pagamento pagamento); // Método que recebe um objeto 'pagamento' e o envia para ser salvo
        }
    }
}