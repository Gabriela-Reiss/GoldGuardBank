using BankSystem.Application.DTOs;
using BankSystem.Application.Services.Interfaces;
using BankSystem.Domain.Repositories.Interfaces;

namespace BankSystem.Application.Services.Implementations;

public class ContaService : IContaService
{

    private readonly IUnityOfWork _uow;

    public ContaService(IUnityOfWork uow)
    {
        _uow = uow;
    }

    public async Task<HomeContaDto> ObterResumoAsync(int usuarioId)
    {
        var conta = await _uow.Contas.GetContaByUsuarioId(usuarioId);

        if (conta == null)
            throw new Exception("Conta não encontrada");

        return new HomeContaDto
        {
            NomeUsuario = conta.Usuario!.Nome,
            TipoConta = conta.Tipo.ToString(),
            Saldo = conta.SaldoTotal,
            DataCriacao = conta.DataCriacao,

            
            NumeroConta = conta.NumeroConta
        };
    }


    public async Task<IEnumerable<ExtratoDto>> ObterExtratoAsync(int usuarioId)
    {
        var conta = await _uow.Contas.ObterContaCompletaAsync(usuarioId);

        if (conta == null)
            throw new Exception("Conta não encontrada");

        return conta.Transacoes
            .OrderByDescending(t => t.Data)
            .Select(t => new ExtratoDto
            {
                Data = t.Data,
                Tipo = t.Tipo.ToString(),
                Valor = t.Valor,
                Descricao = t.Descricao
            });
    }

    
}
