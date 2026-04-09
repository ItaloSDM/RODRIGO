using SistemaPontoCego.Domain.Entities;

namespace SistemaPontoCego.Domain.Interfaces // Organiza o arquivo dentro da camada de Interfaces do Domínio
{
    public interface IItens_PedidoRepository // Declara o contrato para gerenciar os produtos de cada venda
    {
        void Adicionar(Itens_Pedido item); // Recebe um item específico (produto e quantidade) e o salva no banco de dados

        List<Itens_Pedido> ListarPorPedido(int pedidoId); // Busca e devolve a lista de todos os itens que pertencem a um pedido específico
    }
}