using BankSystem.Domain.Model;
using BankSystem.Domain.Model.Enums;
using BankSystem.Domain.Repositories.Interfaces;
using BankSystem.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Infraestructure.Repositories.Implementations;

public class ContaRepository : GenericRepository<Conta>, IContaRepository
{
    public ContaRepository(BankSystemDbContext context) : base(context)
    {

    }
   
    public async Task<IEnumerable<Conta>> GetContasByUsuarioId(int usuarioId)
    {
        

        return _dbSet.Where(c => c.UsuarioId == usuarioId).ToList();
    }

    public async Task<IEnumerable<Conta>> GetContasByUsuarioIdAndTipo(int usuarioId, TipoConta tipo)
    {
        return _dbSet.Where(c => c.UsuarioId == usuarioId && c.Tipo == tipo).ToList();
    }

    public async Task<Conta?> ObterContaCompletaAsync(int contaId)
    {
        return await _context.Contas
            .Include(c => c.Transacoes)
            .Include(c => c.Investimentos)
                .ThenInclude(i => i.Ativo)
            .FirstOrDefaultAsync(c => c.Id == contaId);
    }
}
