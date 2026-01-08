namespace BankSystem.Application.DTOs;

public class MarketAtivoDto
{
    public string Symbol { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
}

