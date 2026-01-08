namespace BankSystem.Application.DTOs;

public class HomeContaDto
{
    public string NomeUsuario { get; set; } = string.Empty;
    public string TipoConta { get; set; } = string.Empty;
    public decimal Saldo { get; set; }
    public DateTime DataCriacao { get; set; }

    public bool PodeInvestir => TipoConta == "INVESTIMENTO";

    public string NumeroConta { get; set; } = null!;
}
