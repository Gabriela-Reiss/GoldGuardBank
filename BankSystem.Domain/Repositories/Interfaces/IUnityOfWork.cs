namespace BankSystem.Domain.Repositories.Interfaces;

public interface IUnityOfWork : IDisposable
{
    IUsuarioRepository Usuarios { get; }
    IContaRepository Contas { get; }

    IAtivoRepository Ativos { get; }
    ITransacaoRepository Transacoes { get; }
    IInvestimentoRepository Investimentos { get; }
    ILoginRepository Logins { get; }

    Task CommitAsync();

}
