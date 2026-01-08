namespace BankSystem.Application.Services.Interfaces;

public interface IMarketDataService
{
    Task<decimal> ObterPrecoAsync(string simbolo);
}
