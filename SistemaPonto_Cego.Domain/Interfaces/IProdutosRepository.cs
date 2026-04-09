using SistemaPontoCego.Domain.Entities;

namespace SistemaPontoCego.Domain.Interfaces;

    public interface IProdutosRepository // Define o contrato de regras para o repositório de produtos
    {
        void Adicionar(Produto produto); // Recebe os dados de um novo produto e salva no banco de dados

        List<Produto> Listar(); // Busca no banco de dados e retorna uma lista com todos os produtos

        void Remover(int id); // Recebe o ID de um produto específico para deletá-lo do sistema
    }
