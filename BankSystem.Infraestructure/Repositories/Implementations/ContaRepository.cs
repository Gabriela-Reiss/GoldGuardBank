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

    public async Task<Conta?> GetByNumeroContaAsync(string numeroConta)
    {
        return await _context.Contas
            .Include(c => c.Transacoes)
            .FirstOrDefaultAsync(c => c.NumeroConta == numeroConta);
    }


    public async Task<Conta?> GetContaByUsuarioId(int usuarioId)
    {
        return await _context.Contas
            .Include(c => c.Usuario)
            .FirstOrDefaultAsync(c => c.UsuarioId == usuarioId);
    }



    public async Task<Conta?> GetContasByUsuarioIdAndTipo(
    int usuarioId,
    TipoConta tipo)
    {
        return await _context.Contas
            .FirstOrDefaultAsync(c =>
                c.UsuarioId == usuarioId &&
                c.Tipo == tipo);
    }

    

    public async Task<Conta?> ObterContaCompletaAsync(int usuarioId)
    {
        return await _context.Contas
            .Include(c => c.Usuario)
            .Include(c => c.Transacoes)
            .FirstOrDefaultAsync(c => c.UsuarioId == usuarioId);
    }

    
}
