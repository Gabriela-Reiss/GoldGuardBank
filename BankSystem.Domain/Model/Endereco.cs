using System.ComponentModel.DataAnnotations;

namespace BankSystem.Domain.Model;

public class Endereco
{
    [Required(ErrorMessage = "O logradouro é obrigatório")]
    [StringLength(150, MinimumLength = 3, ErrorMessage = "O logradouro deve ter entre 3 e 150 caracteres")]
    public string? Logradouro { get; set; }

    public string? Bairro { get; set; }

    [StringLength(100, ErrorMessage = "O complemento pode ter no máximo 100 caracteres")]
    public string? Complemento { get; set; }

    [Required(ErrorMessage = "O estado é obrigatório")]
    [RegularExpression(
       @"^(AC|AL|AP|AM|BA|CE|DF|ES|GO|MA|MT|MS|MG|PA|PB|PR|PE|PI|RJ|RN|RS|RO|RR|SC|SP|SE|TO)$",
       ErrorMessage = "Estado inválido"
   )]
    public string? Estado { get; set; }

    [Required(ErrorMessage = "A cidade é obrigatória")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "A cidade deve ter entre 2 e 100 caracteres")]
    public string? Cidade { get; set; }

    [Required(ErrorMessage = "O CEP é obrigatório")]
    [RegularExpression(
       @"^\d{5}-?\d{3}$",
       ErrorMessage = "CEP inválido"
   )]
    public string? CEP { get; set; }
}