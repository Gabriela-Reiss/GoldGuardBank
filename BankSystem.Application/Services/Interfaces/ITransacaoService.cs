namespace BankSystem.Application.Services.Interfaces;

public interface ITransacaoService
{
    Task DepositarAsync(int usuarioId, decimal valor);
    Task SacarAsync(int usuarioId, decimal valor);
    
    Task TransferirAsync(int userId, string numeroContaDestino, decimal valor);
}
