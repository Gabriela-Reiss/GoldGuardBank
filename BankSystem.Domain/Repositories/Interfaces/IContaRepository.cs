using BankSystem.Domain.Model;
using BankSystem.Domain.Model.Enums;

namespace BankSystem.Domain.Repositories.Interfaces;

public interface IContaRepository : IGenericRepository<Conta>
{
    Task<IEnumerable<Conta>> GetContasByUsuarioId(int usuarioId);

    Task<Conta?> ObterContaCompletaAsync(int contaId);
    Task<IEnumerable<Conta>> GetContasByUsuarioIdAndTipo(int usuarioId, TipoConta tipo);
    
}
