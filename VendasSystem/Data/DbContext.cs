using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VendasSystem.Models;

namespace VendasSystem.Data;

public class DbContext : IdentityDbContext
{
    public DbContext(DbContextOptions<DbContext> options)
        : base(options)
    {
    }

    public DbSet<Marca> Marcas { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Item> Itens { get; set; }
    public DbSet<Pagamento> Pagamentos { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<NotaDeVenda> NotasDeVenda { get; set; }
    public DbSet<Vendedor> Vendedores { get; set; }
    public DbSet<Transportadora> Transportadoras { get; set; }
}
