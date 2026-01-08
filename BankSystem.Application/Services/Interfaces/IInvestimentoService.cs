using BankSystem.Domain.Model;

namespace BankSystem.Application.Services.Interfaces;

public interface IInvestimentoService
{
    Task ComprarAsync(
        int usuarioId,
        int ativoId,
        decimal quantidade
    );

    Task<IEnumerable<Investimento>> ObterCarteiraAsync(int usuarioId);

    Task VenderAsync(
        int usuarioId,
        int investimentoId,
        decimal quantidade
    );
}
