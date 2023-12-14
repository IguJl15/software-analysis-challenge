
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Protocol.Plugins;
using VendasSystem.Models;

namespace VendasSystem.ViewModels;

public class ProdutoCreateEdit : Produto
{
    public List<SelectListItem> MarcasDisponiveis = [];
}