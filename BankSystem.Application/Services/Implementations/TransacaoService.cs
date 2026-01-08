using BankSystem.Application.Services.Interfaces;
using BankSystem.Domain.Model;
using BankSystem.Domain.Model.Enums;
using BankSystem.Domain.Repositories.Interfaces;

namespace BankSystem.Application.Services.Implementations;

public class TransacaoService : ITransacaoService
{
    private readonly IUnityOfWork _uow;

    public TransacaoService(IUnityOfWork uow)
    {
        _uow = uow;
    }

    public async Task DepositarAsync(int usuarioId, decimal valor)
    {
        var conta = await _uow.Contas.GetContaByUsuarioId(usuarioId);

        conta.Creditar(valor);

        await _uow.Transacoes.AddAsync(new Transacao
        {
            ContaId = conta.Id,
            Tipo = TipoTransacao.DEPOSITO,
            Valor = valor,
            Data = DateTime.Now
        });

        await _uow.CommitAsync();
    }

    public async Task SacarAsync(int usuarioId, decimal valor)
    {
        var conta = await _uow.Contas.GetContaByUsuarioId(usuarioId);

        conta.Debitar(valor);

        await _uow.Transacoes.AddAsync(new Transacao
        {
            ContaId = conta.Id,
            Tipo = TipoTransacao.SAQUE,
            Valor = valor,
            Data = DateTime.Now
        });

        await _uow.CommitAsync();
    }


    public async Task TransferirAsync(
    int usuarioOrigemId,
    string numeroContaDestino,
    decimal valor)
    {
        var origem = await _uow.Contas.ObterContaCompletaAsync(usuarioOrigemId);
        var destino = await _uow.Contas.GetByNumeroContaAsync(numeroContaDestino);

        if (destino == null)
            throw new Exception("Conta destino não encontrada");

        origem.Debitar(valor);
        destino.Creditar(valor);

        await _uow.CommitAsync();
    }

}
