using SistemaPontoCego.Domain.Entities;

namespace SistemaPontoCego.Domain.Interfaces;// Define o grupo (espaço de nomes) onde esta interface está guardada

    public interface IPedidosRepository // Declara o "contrato" que obriga a criação de métodos para Pedidos
    {
        void CriarPedido(Pedido pedido); // Método que recebe um objeto 'pedido' para registrar uma nova venda no banco

        List<Pedido> Listar(); // Método que busca no banco e devolve uma lista com todos os pedidos feitos
    }
