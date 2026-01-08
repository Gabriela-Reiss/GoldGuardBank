using BankSystem.Domain.Model;
using BankSystem.Domain.Model.Enums;

namespace BankSystem.Domain.Repositories.Interfaces;

public interface IAtivoRepository : IGenericRepository<Ativo>
{
    Task<Ativo?> GetBySimboloAsync(string simbolo);
    Task<IEnumerable<Ativo>> ObterPorPerfilAsync(PerfilInvestimento perfil);
}
