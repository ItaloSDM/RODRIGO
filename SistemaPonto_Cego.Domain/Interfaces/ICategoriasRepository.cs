using SistemaPontoCego.Domain.Entities; //dependencia

namespace SistemaPontoCego.Domain.Interfaces; //Define a "pasta lógica" deste arquivo. 

public interface ICategoriasRepository //Ela é um contrato, define o que uma classe deve fazer, mas não como ela deve fazer, o que recebe e devolve
{
    //tipo de retorno
    List<Categoria> Listar();
}