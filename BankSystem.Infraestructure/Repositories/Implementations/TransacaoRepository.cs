using BankSystem.Domain.Model;
using BankSystem.Domain.Repositories.Interfaces;
using BankSystem.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Infraestructure.Repositories.Implementations;

public class TransacaoRepository : GenericRepository<Transacao>, ITransacaoRepository
{
    public TransacaoRepository(BankSystemDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Transacao>> ObterExtratoAsync(
       int contaId,
       DateTime inicio,
       DateTime fim)
    {
        return await _context.Transacoes
            .Where(t =>
                t.ContaId == contaId &&
                t.Data >= inicio &&
                t.Data <= fim)
            .OrderByDescending(t => t.Data)
            .ToListAsync();
    }
}
