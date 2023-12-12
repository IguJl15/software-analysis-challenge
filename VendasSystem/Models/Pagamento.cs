namespace VendasSystem.Models;

public class Pagamento
{
    public int Id { get; set; }
    public double Valor { get; set; }
    public bool Pago { get; set; }
    public DateTime DataLimite { get; set; }
    public Cliente Cliente { get; set; }
    public NotaDeVenda NotaDeVenda { get; set; }
}
