namespace VendasSystem.Models;

public class NotaDeVenda
{
    public int Id { get; set; }
    public DateTime Data { get; set; }
    public Vendedor Vendedor { get; set; }
    public Transportadora Transportadora { get; set; }
    public List<Item> Itens { get; set; }
    public List<Pagamento> Pagamentos { get; set; }
}
