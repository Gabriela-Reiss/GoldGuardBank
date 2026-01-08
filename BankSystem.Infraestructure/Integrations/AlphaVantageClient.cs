using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
namespace BankSystem.Infraestructure.Integrations;

public class AlphaVantageClient
{
    private readonly HttpClient _http;
    private readonly IConfiguration _config;

    public AlphaVantageClient(HttpClient http, IConfiguration config)
    {
        _http = http;
        _config = config;
    }

    public async Task<decimal> ObterPrecoAsync(string symbol)
    {
        var apiKey = _config["AlphaVantage:ApiKey"];
        var url = $"{_config["AlphaVantage:BaseUrl"]}?function=GLOBAL_QUOTE&symbol={symbol}&apikey={apiKey}";

        var response = await _http.GetFromJsonAsync<JsonElement>(url);

        if (!response.TryGetProperty("Global Quote", out var quote))
            throw new Exception($"Preço indisponível para {symbol}");

        if (!quote.TryGetProperty("05. price", out var price))
            throw new Exception($"Preço não encontrado para {symbol}");

        return decimal.Parse(price.GetString()!, CultureInfo.InvariantCulture);
    }


}
