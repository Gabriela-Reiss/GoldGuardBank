using BankSystem.Application.Services.Interfaces;
using BankSystem.Domain.Model;
using BankSystem.Domain.Model.Enums;
using BankSystem.Domain.Repositories.Interfaces;

namespace BankSystem.Application.Services.Implementations;

public class AtivoService : IAtivoService
{
    private readonly IAtivoRepository _repo;
    private readonly IMarketDataService _market;

    public AtivoService(
        IAtivoRepository repo,
        IMarketDataService market)
    {
        _repo = repo;
        _market = market;
    }


    public async Task<IEnumerable<Ativo>> ObterAtivosAsync()
    {
        var ativos = await _repo.GetAllAsync();

        foreach (var ativo in ativos)
        {
            try
            {
                var precoAtual = await _market.ObterPrecoAsync(ativo.Simbolo);
                ativo.AtualizarPreco(precoAtual);
            }
            catch
            {
                
            }
        }

        return ativos;
    }



    public async Task<Ativo?> ObterPorIdAsync(int id)
    {
        return await _repo.GetByIdAsync(id);
    }

    
    public async Task AtualizarPrecoAsync(int ativoId)
    {
        var ativo = await _repo.GetByIdAsync(ativoId);

        if (ativo == null)
            throw new Exception("Ativo não encontrado");

        var precoAtual = await _market.ObterPrecoAsync(ativo.Simbolo);

        ativo.AtualizarPreco(precoAtual);

        _repo.Update(ativo);
    }

    public async Task<IEnumerable<Ativo>> ObterPorPerfilAsync(PerfilInvestimento perfil)
    {
        var ativos = await _repo.ObterPorPerfilAsync(perfil);

        foreach (var ativo in ativos)
        {
            try
            {
                var preco = await _market.ObterPrecoAsync(ativo.Simbolo);
                ativo.AtualizarPreco(preco);
            }
            catch
            {
                ativo.AtualizarPreco(0);
            }
        }

        return ativos;
    }



}
