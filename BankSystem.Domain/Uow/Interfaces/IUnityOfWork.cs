using BankSystem.Domain.Repositories.Interfaces;

namespace BankSystem.Domain.Uow.Interfaces;

public interface IUnityOfWork : IDisposable
{
    IUsuarioRepository Usuarios { get; }
    IContaRepository Contas { get; }

    IAtivoRepository Ativos { get; }
    ITransacaoRepository Transacoes { get; }
    IInvestimentoRepository Investimentos { get; }

    Task CommitAsync();

}
