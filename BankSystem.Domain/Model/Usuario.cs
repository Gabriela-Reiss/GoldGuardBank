using System.ComponentModel.DataAnnotations;

namespace BankSystem.Domain.Model;
public class Usuario
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório")]
    [RegularExpression(
       @"^[A-Za-zÀ-ÿ\s]{3,100}$",
       ErrorMessage = "O nome deve conter apenas letras e espaços (mínimo 3 caracteres)"
   )]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "O CPF é obrigatório")]
    [RegularExpression(
        @"^\d{3}\.?\d{3}\.?\d{3}-?\d{2}$",
        ErrorMessage = "CPF inválido"
    )]
    public string? CPF { get; set; }

    [Required(ErrorMessage = "O e-mail é obrigatório")]
    [EmailAddress(ErrorMessage = "E-mail inválido")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "O telefone é obrigatório")]
    [RegularExpression(
        @"^\(?\d{2}\)?\s?\d{4,5}-?\d{4}$",
        ErrorMessage = "Telefone inválido"
    )]
    public string? Telefone { get; set; }

    [Required(ErrorMessage = "O endereço é obrigatório")]
    public Endereco? Endereco { get; set; }

    public ICollection<Conta>? Contas { get; set; }

}

