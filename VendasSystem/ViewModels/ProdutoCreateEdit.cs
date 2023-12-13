
using Microsoft.AspNetCore.Mvc.Rendering;
using VendasSystem.Models;

namespace VendasSystem.ViewModels;

public class ProdutoCreateEdit : Produto
{
    public List<Marca> MarcasDisponiveis = [];

    public List<SelectListItem> MarcasItems
    {
        get
        {
            return MarcasDisponiveis.Select(
            (m) => new SelectListItem
            {
                Text = m.Nome,
                Value = m.Id.ToString()
            }
        ).ToList();
        }
    }
}