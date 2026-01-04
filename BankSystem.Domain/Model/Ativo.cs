
using System.ComponentModel.DataAnnotations;

namespace BankSystem.Domain.Model;

public class Ativo
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "O código do ativo é obrigatório")]
    [StringLength(10, MinimumLength = 2, ErrorMessage = "O código deve ter entre 2 e 10 caracteres")]
    [RegularExpression(
        @"^[A-Z0-9]+$",
        ErrorMessage = "O código do ativo deve conter apenas letras maiúsculas e números"
    )]
    public string? Codigo { get; set; }

    [Required(ErrorMessage = "O nome do ativo é obrigatório")]
    [StringLength(150, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 150 caracteres")]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "O tipo do ativo é obrigatório")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "O tipo deve ter entre 3 e 50 caracteres")]
    [RegularExpression(
        @"^[A-Za-zÀ-ÿ\s]+$",
        ErrorMessage = "O tipo do ativo deve conter apenas letras"
    )]
    public string? Tipo { get; set; }

    [Required(ErrorMessage = "O preço atual é obrigatório")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O preço atual deve ser maior que zero")]
    public decimal PrecoAtual { get; set; }

}
