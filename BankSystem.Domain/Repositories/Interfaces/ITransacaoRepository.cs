using BankSystem.Domain.Model;

namespace BankSystem.Domain.Repositories.Interfaces;

public interface ITransacaoRepository : IGenericRepository<Transacao>
{
    Task<IEnumerable<Transacao>> ObterExtratoAsync(
        int contaId,
        DateTime inicio,
        DateTime fim);

}
