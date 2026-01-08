using BankSystem.Domain.Model;
using BankSystem.Domain.Repositories.Interfaces;
using BankSystem.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Infraestructure.Repositories.Implementations;

public class LoginRepository : GenericRepository<Login>, ILoginRepository
{
    public LoginRepository(BankSystemDbContext context) : base(context)
    {
    }

    public Login GetByCpf(string CPF)
    {
        return _context.Logins
            .Include(l => l.Usuario)
            .FirstOrDefault(l => l.CPF == CPF);
    }
}
