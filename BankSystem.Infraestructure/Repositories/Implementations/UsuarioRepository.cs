using BankSystem.Domain.Model;
using BankSystem.Domain.Repositories.Interfaces;
using BankSystem.Infraestructure.Context;

namespace BankSystem.Infraestructure.Repositories.Implementations;

public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
{
    public UsuarioRepository(BankSystemDbContext context) : base(context)
    {

    }

    public async Task<Usuario> GetByCPF(string CPF)
    {
        return _dbSet.FirstOrDefault(u => u.CPF == CPF);
    }
}
