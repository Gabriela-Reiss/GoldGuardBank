using BankSystem.Domain.Model;
using BankSystem.Domain.Repositories.Interfaces;
using BankSystem.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Infraestructure.Repositories.Implementations;

public class InvestimentoRepository : GenericRepository<Investimento>, IInvestimentoRepository
{
    public InvestimentoRepository(BankSystemDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Investimento>> ObterPorContaAsync(int contaId)
    {
        return await _context.Investimentos
            .Include(i => i.Ativo)
            .Where(i => i.ContaId == contaId)
            .ToListAsync();
    }
}
