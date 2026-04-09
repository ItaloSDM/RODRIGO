using SistemaPontoCego.Domain.Entities;

namespace SistemaPontoCego.Domain.Interfaces;

    public interface ITamanhosRepository // Declara o contrato para gerenciar os diferentes tamanhos de produtos
    {
        List<Tamanho> Listar(); // Busca no banco e retorna uma lista com todas as variações de tamanhos (ex: P, M, G)
    }
