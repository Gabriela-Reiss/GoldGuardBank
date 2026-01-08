using BankSystem.Domain.Model;
using BankSystem.Domain.Model.Enums;

namespace BankSystem.Application.Services.Interfaces;

public interface IAtivoService
{
    Task<IEnumerable<Ativo>> ObterAtivosAsync();
    Task<Ativo?> ObterPorIdAsync(int id);
    Task AtualizarPrecoAsync(int ativoId);

    Task<IEnumerable<Ativo>> ObterPorPerfilAsync(PerfilInvestimento perfil);
}

