using SistemaPontoCego.Domain.Entities;

namespace SistemaPontoCego.Domain.Interfaces;


    public interface ILojaRepository // Define o contrato para gerenciar os dados da Loja (configurações ou perfil)
    {
        void Adicionar(Loja loja); // Recebe os dados da loja e os salva pela primeira vez no banco de dados

        void Atualizar(Loja loja); // Recebe os dados alterados da loja e atualiza o registro já existente

        Loja Obter(); // Busca e retorna as informações atuais da loja (como nome, CNPJ ou endereço)
    }