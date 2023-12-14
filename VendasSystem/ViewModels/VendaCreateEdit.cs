
namespace VendasSystem.ViewModels;

using Microsoft.AspNetCore.Mvc.Rendering;
using VendasSystem.Models;


public class VendaCreateEdit
{
    public NotaDeVenda Venda { get; set; }

    public List<SelectListItem> ProdutosDisponiveis = [];
    public List<SelectListItem> TransportadorasDisponiveis = [];
    public List<SelectListItem> VendedoresDisponiveis = [];
    public List<SelectListItem> ClientesDisponiveis = [];

}