using BankSystem.Application.Services.Interfaces;
using BankSystem.Domain.Model;
using BankSystem.Domain.Model.Enums;
using BankSystem.Domain.Repositories.Interfaces;

namespace BankSystem.Application.Services.Implementations;

public class AtivoService : IAtivoService
{
    private readonly IAtivoRepository _repo;
    

    public AtivoService(
        IAtivoRepository repo
       )
    {
        _repo = repo;
       
    }


    public async Task<IEnumerable<Ativo>> ObterAtivosAsync()
    {
        var ativos = await _repo.GetAllAsync();

        return ativos;
    }



    public async Task<Ativo?> ObterPorIdAsync(int id)
    {
        return await _repo.GetByIdAsync(id);
    }

    
    



}
