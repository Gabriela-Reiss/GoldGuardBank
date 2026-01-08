using BankSystem.Application.Services.Interfaces;
using BankSystem.Infraestructure.Integrations;

namespace BankSystem.Application.Services.Implementations;

public class MarketDataService : IMarketDataService
{
    private readonly AlphaVantageClient _client;

    public MarketDataService(AlphaVantageClient client)
    {
        _client = client;
    }

    public async Task<decimal> ObterPrecoAsync(string simbolo)
    {
        return await _client.ObterPrecoAsync(simbolo);
    }
}
