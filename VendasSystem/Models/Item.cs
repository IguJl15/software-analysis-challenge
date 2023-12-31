namespace VendasSystem.Models;

public class Item
{
    public int Id { get; set; }
    public int Quantidade { get; set; }
    public double PrecoUnitario { get; set; }
    
    public int ProdutoId { get; set; }
    public int NotaDeVendaId { get; set; }

    public Produto Produto { get; set; }
    public NotaDeVenda NotaDeVenda { get; set; }
}
