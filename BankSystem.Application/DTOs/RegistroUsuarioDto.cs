using BankSystem.Domain.Model.Enums;

namespace BankSystem.Application.DTOs;

public class RegistroUsuarioDto
{
    public string Nome { get; set; }
    public string CPF { get; set; }

    public string Email { get; set; }
    public string Telefone { get; set; }

    public string Senha { get; set; }

    public EnderecoDto Endereco { get; set; }

    public TipoConta TipoConta { get; set; }

    
    public decimal? DepositoInicial { get; set; }
}
