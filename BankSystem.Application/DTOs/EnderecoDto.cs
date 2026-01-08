using System.ComponentModel.DataAnnotations;

namespace BankSystem.Application.DTOs;

public class EnderecoDto
{
    [Required]
    public string Logradouro { get; set; }

    public string Bairro { get; set; }

    public string Complemento { get; set; }

    [Required]
    public string Cidade { get; set; }

    [Required]
    public string Estado { get; set; }

    [Required]
    public string CEP { get; set; }
}
