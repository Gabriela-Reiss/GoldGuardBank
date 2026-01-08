using BankSystem.Domain.Model;
using BankSystem.Domain.Model.Enums;
using BankSystem.Domain.Repositories.Interfaces;
using BankSystem.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Infraestructure.Repositories.Implementations;

public class AtivoRepository : GenericRepository<Ativo>, IAtivoRepository
{
    public AtivoRepository(BankSystemDbContext context) : base(context) { }

    public async Task<Ativo?> GetBySimboloAsync(string simbolo)
    {
        return await _dbSet.FirstOrDefaultAsync(a => a.Simbolo == simbolo);
    }

    
}
