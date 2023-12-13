using Microsoft.EntityFrameworkCore.Migrations;
using VendasSystem.Data;
using VendasSystem.Models;

#nullable disable

namespace VendasSystem.Migrations
{
    /// <inheritdoc />
    public partial class MockData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Marcas
            migrationBuilder.Sql(@"
            INSERT INTO ""Marcas"" (""Nome"", ""Descricao"")
            VALUES
                ('Apple', 'Marca de eletrônicos'),
                ('Samsung', 'Marca de eletrônicos'),
                ('LG', 'Marca de eletrônicos');

            INSERT INTO ""Transportadoras"" (""Nome"")
            VALUES
                ('Correios'),
                ('Sedex');

            INSERT INTO ""Vendedores"" (""Nome"")
            VALUES
                ('João da Silva'),
                ('Maria das Dores');

            INSERT INTO ""Produtos"" (""Nome"", ""Descricao"", ""Preco"", ""MarcaId"")
            VALUES
                ('iPhone 13', 'Smartphone da Apple', 5000.00, 1),
                ('Galaxy S23', 'Smartphone da Samsung', 4000.00, 2),
                ('TV OLED C1', 'Televisão da LG', 10000.00, 3),
                ('Notebook MacBook Air M2', 'Notebook da Apple', 15000.00, 1),
                ('Tablet Galaxy Tab S8', 'Tablet da Samsung', 3000.00, 2),
                ('Refrigerador LG InstaView', 'Refrigerador da LG', 5000.00, 3),
                ('Lavadora de Roupas Samsung EcoBubble', 'Lavadora de roupas da Samsung', 3000.00, 2);
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
