namespace VendasSystem.Models;

public class NotaDeVenda
{
    public int Id { get; set; }
    public DateTime Data { get; set; }

    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; }

    public int VendedorId { get; set; }
    public Vendedor Vendedor { get; set; }

    public int TransportadoraId { get; set; }
    public Transportadora Transportadora { get; set; }

    public List<Item> Itens = [];
    public List<Pagamento> Pagamentos = [];
}
