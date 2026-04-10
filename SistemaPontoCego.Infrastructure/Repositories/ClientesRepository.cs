using SistemaPontoCego.Domain.Entities;
using SistemaPontoCego.Domain.Interfaces;
using SistemaPontoCego.Infrastructure.Data;

namespace SistemaPontoCego.Infrastructure.Repositories
{
    public class ClientesRepository : IClientesRepository // Implementa o contrato de acesso a dados para a entidade Cliente
    {
        private readonly AppDbContext _context; // Variável que mantém a conexão aberta com o banco de dados

        public ClientesRepository(AppDbContext context) // Construtor que recebe a conexão (contexto) para poder operar
        {
            _context = context; // Atribui a conexão recebida ao campo interno da classe
        }

        public List<Cliente> Listar() // Método que busca todos os clientes registrados no sistema
        {
            return _context.Cliente.ToList(); // Acessa a tabela Cliente e converte todos os registros em uma Lista C#
        }

        public Cliente? ObterPorId(int id) // Método para encontrar um cliente específico através do seu ID único
        {
            return _context.Cliente.FirstOrDefault(c => c.Id_Cliente == id); // Procura no banco o primeiro cliente que tenha o ID informado
        }

        public void Adicionar(Cliente cliente) // Método que realiza o cadastro de um novo cliente no banco
        {
            _context.Cliente.Add(cliente); // Adiciona o objeto cliente na memória do contexto
            _context.SaveChanges(); // Persiste (salva) o novo cliente definitivamente no banco de dados
        }

        public void Atualizar(Cliente cliente) // Método que grava as alterações feitas em um cliente já existente
        {
            _context.Cliente.Update(cliente); // Marca o registro do cliente como "modificado" para o banco
            _context.SaveChanges(); // Envia as atualizações para o banco de dados e as torna permanentes
        }

        public void Remover(int id) // Método que exclui um cliente do sistema com base no ID
        {
            var cliente = ObterPorId(id); // Primeiro, tenta localizar o cliente no banco para garantir que ele existe
            if (cliente != null) // Se o cliente for encontrado (não for nulo)
            {
                _context.Cliente.Remove(cliente); // Solicita a remoção do registro da tabela
                _context.SaveChanges(); // Confirma a exclusão no banco de dados (deleta a linha no SQL)
            }
        }
    }

}