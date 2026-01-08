using BankSystem.Domain.Repositories.Interfaces;
using BankSystem.Infraestructure.Context;
using BankSystem.Infraestructure.Repositories.Implementations;

namespace BankSystem.Infraestructure.Persistence;

public class UnityOfWork : IUnityOfWork
{

    private readonly BankSystemDbContext _context;

    public IUsuarioRepository _usuarios;
    public IContaRepository _contas;
    public IInvestimentoRepository _investimentos;
    public IAtivoRepository _ativos;
    public ITransacaoRepository _transacoes;
    public ILoginRepository _logins;

    public UnityOfWork(BankSystemDbContext context)
    {
        _context = context;
    }


    public IUsuarioRepository Usuarios
    {
        get
        {
            return _usuarios ??= new UsuarioRepository(_context);
        }
    }

    public IContaRepository Contas
    {
        get
        {
            return _contas ??= new ContaRepository(_context);
        }
    }

    public IAtivoRepository Ativos => throw new NotImplementedException();

    public ITransacaoRepository Transacoes
    {
        get
        {
            return _transacoes ??= new TransacaoRepository(_context);
        }
    }

    public IInvestimentoRepository Investimentos {
        get
        {
            return _investimentos ??= new InvestimentoRepository(_context);
        }
    }

    public ILoginRepository Logins
    {
        get
        {
            return _logins ??= new LoginRepository(_context);
        }
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
