using BankSystem.Domain.Model;

namespace BankSystem.Domain.Repositories.Interfaces
{
    public interface IAtivoRepository : IGenericRepository<Ativo>
    {
        Task<Ativo?> ObterPorCodigoAsync(string codigo);
    }
}
