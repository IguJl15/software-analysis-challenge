namespace VendasSystem.Models;

public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public double Preco { get; set; }
    public int MarcaId { get; set; }
    public Marca Marca { get; set; }
}
