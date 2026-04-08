namespace SistemaPontoCego.Domain.Entities
{
    public class Pagamento
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public string Metodo { get; set; } // Ex: Cartão, Pix
        public DateTime Data { get; set; }
    }
}