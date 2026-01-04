using BankSystem.Domain.Model;

namespace BankSystem.Domain.Repositories.Interfaces;

public interface IInvestimentoRepository : IGenericRepository<Investimento>
{
    Task<IEnumerable<Investimento>> ObterPorContaAsync(int contaId);
}
