using BankSystem.Domain.Model;
using BankSystem.Domain.Model.Enums;

namespace BankSystem.Domain.Repositories.Interfaces;

public interface IContaRepository : IGenericRepository<Conta>
{
    Task<Conta> GetContaByUsuarioId(int usuarioId);

    Task<Conta?> ObterContaCompletaAsync(int usuarioId);

    
    Task<Conta?> GetContasByUsuarioIdAndTipo(int usuarioId, TipoConta tipo);
    Task<Conta?> GetByNumeroContaAsync(string numeroConta);


}
