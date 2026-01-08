using BankSystem.Application.Services.Interfaces;
using BankSystem.Domain.Model;
using BankSystem.Domain.Model.Enums;
using BankSystem.Domain.Repositories.Interfaces;

namespace BankSystem.Application.Services.Implementations;

public class InvestimentoService : IInvestimentoService
{
    private readonly IUnityOfWork _uow;

    public InvestimentoService(IUnityOfWork uow)
    {
        _uow = uow;
    }

    public async Task ComprarAsync(
        int usuarioId,
        int ativoId,
        decimal quantidade)
    {
        if (quantidade <= 0)
            throw new Exception("Quantidade inválida");

        var conta = await _uow.Contas
            .GetContasByUsuarioIdAndTipo(
                usuarioId,
                TipoConta.INVESTIMENTO);

        if (conta == null)
            throw new Exception("Conta de investimento não encontrada");

        var ativo = await _uow.Ativos.GetByIdAsync(ativoId);

        if (ativo == null)
            throw new Exception("Ativo inválido");

        var precoAtual = ativo.PrecoAtual;

        var valorTotal = precoAtual * quantidade;

        conta.Debitar(valorTotal);

        var investimento = new Investimento
        {
            ContaId = conta.Id,
            AtivoId = ativo.Id,
            Quantidade = quantidade,
            PrecoCompra = precoAtual
        };

        await _uow.Investimentos.AddAsync(investimento);

        await _uow.Transacoes.AddAsync(new Transacao
        {
            ContaId = conta.Id,
            Tipo = TipoTransacao.COMPRA_INVESTIMENTO,
            Valor = valorTotal,
            Data = DateTime.Now,
            Descricao = $"Compra de {ativo.Nome}"
        });

        await _uow.CommitAsync();
    }

    public async Task<IEnumerable<Investimento>> ObterCarteiraAsync(int usuarioId)
    {
        var conta = await _uow.Contas
            .GetContasByUsuarioIdAndTipo(
                usuarioId,
                TipoConta.INVESTIMENTO);

        if (conta == null)
            throw new Exception("Conta de investimento não encontrada");

        return await _uow.Investimentos
            .ObterPorContaAsync(conta.Id);
    }

    public async Task VenderAsync(
        int usuarioId,
        int investimentoId,
        decimal quantidade)
    {
        if (quantidade <= 0)
            throw new Exception("Quantidade inválida");

        var investimento = await _uow.Investimentos
            .GetByIdAsync(investimentoId);

        if (investimento == null)
            throw new Exception("Investimento não encontrado");

        if (investimento.Quantidade < quantidade)
            throw new Exception("Quantidade superior à disponível");

        var conta = await _uow.Contas.GetByIdAsync(investimento.ContaId);

        if (conta == null || conta.UsuarioId != usuarioId)
            throw new Exception("Conta inválida");

        var ativo = await _uow.Ativos.GetByIdAsync(investimento.AtivoId);

        if (ativo == null)
            throw new Exception("Ativo não encontrado");

        var precoAtual = ativo.PrecoAtual;

        var valorVenda = precoAtual * quantidade;

        investimento.Quantidade -= quantidade;

        if (investimento.Quantidade == 0)
            _uow.Investimentos.Delete(investimento);
        else
            _uow.Investimentos.Update(investimento);

        conta.Creditar(valorVenda);

        await _uow.Transacoes.AddAsync(new Transacao
        {
            ContaId = conta.Id,
            Tipo = TipoTransacao.VENDA_INVESTIMENTO,
            Valor = valorVenda,
            Data = DateTime.Now,
            Descricao = $"Venda de {ativo.Nome}"
        });

        await _uow.CommitAsync();
    }
}
