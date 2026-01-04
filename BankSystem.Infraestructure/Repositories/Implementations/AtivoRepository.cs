using BankSystem.Domain.Model;
using BankSystem.Domain.Repositories.Interfaces;
using BankSystem.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Infraestructure.Repositories.Implementations;

public class AtivoRepository : GenericRepository<Ativo>, IAtivoRepository
{
    public AtivoRepository(BankSystemDbContext context) : base(context)
    {
    }

    public async Task<Ativo?> ObterPorCodigoAsync(string codigo)
    {
        return await _context.Ativos
            .FirstOrDefaultAsync(a => a.Codigo == codigo);
    }
}
