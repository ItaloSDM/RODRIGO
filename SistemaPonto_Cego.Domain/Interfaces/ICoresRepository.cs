using SistemaPontoCego.Domain.Entities;

namespace SistemaPontoCego.Domain.Interfaces;

public interface ICoresRepository
{
    List<Cor> Listar(); // Listar todas as cores
}