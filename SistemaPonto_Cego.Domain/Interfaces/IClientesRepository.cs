using SistemaPontoCego.Domain.Entities;

namespace SistemaPontoCego.Domain.Interfaces;

public interface IClientesRepository
{
    void Adicionar(Cliente cliente); //tipo do objeto, nome dado a esse objeto dentro do método 
    List<Cliente> Listar();
}