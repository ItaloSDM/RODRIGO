using SistemaPontoCego.Domain.Entities;
using SistemaPontoCego.Domain.Interfaces;
using SistemaPontoCego.Infrastructure.Data;

public class ProdutosRepository : IProdutosRepository
{

        private readonly AppDbContext _context; // Campo que armazena a conexão (contexto) com o banco de dados

        public ProdutosRepository(AppDbContext context) // Construtor que recebe o banco de dados por injeção de dependência
        {
            _context = context; // Inicializa o contexto para realizar as operações de leitura e gravação
        }

        public List<Produto> Listar() // Método que busca todos os produtos cadastrados no banco
        {
            return _context.Produto.ToList(); // Acessa a tabela Produto e converte os registros em uma lista C#
        }

        public Produto? ObterPorId(int id) // Método para localizar um produto específico usando o seu ID
        {
            return _context.Produto.FirstOrDefault(p => p.Id_Produto == id); // Procura no banco o primeiro produto que tenha o ID informado
        }

        public void Adicionar(Produto produto) // Método que realiza o cadastro de um novo produto
        {
            _context.Produto.Add(produto); // Adiciona o objeto produto à memória do contexto do banco
            _context.SaveChanges(); // Salva permanentemente o novo produto no banco de dados SQL
        }

        public void Atualizar(Produto produto) // Método que grava as alterações feitas em um produto existente
        {
            _context.Produto.Update(produto); // Marca o registro do produto como "modificado"
            _context.SaveChanges(); // Envia as atualizações para o banco de dados
        }

        public void Remover(int id) // Método que exclui um produto do sistema com base no seu código
        {
            var produto = ObterPorId(id); // Tenta localizar o produto no banco para garantir que ele existe
            if (produto != null) // Se o produto for encontrado (não for nulo)
            {
                _context.Produto.Remove(produto); // Solicita a remoção do registro da tabela
                _context.SaveChanges(); // Confirma a exclusão definitiva no banco de dados
            }
        }
    }
