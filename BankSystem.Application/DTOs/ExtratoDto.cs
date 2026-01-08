namespace BankSystem.Application.DTOs;

public class ExtratoDto
{
    public DateTime Data { get; set; }
    public string Tipo { get; set; }
    public decimal Valor { get; set; }
    public string? Descricao { get; set; }
}
