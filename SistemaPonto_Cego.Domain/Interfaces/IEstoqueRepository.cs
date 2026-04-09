namespace SistemaPontoCego.Domain.Interfaces // Localização organizada dentro da camada de Domínio
{
    public interface IEstoqueRepository // Define o contrato para operações que mexem na quantidade de produtos
    {
        void AtualizarEstoque(int produtoId, int quantidade); // Recebe o código do produto e o novo valor para atualizar o saldo no banco
    }
}