namespace VendasSystem.Models;

using System.ComponentModel.DataAnnotations;

public class Cliente
{
    public int Id { get; set; }
    
    [Required]
    public required string Nome { get; set; }
    
    [Required]
    [Display(Name = "Informações Adicionais")]
    public required string InformacoesAdicionais { get; set; }
}