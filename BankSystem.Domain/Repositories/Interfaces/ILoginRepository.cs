using BankSystem.Domain.Model;

namespace BankSystem.Domain.Repositories.Interfaces;

public interface ILoginRepository : IGenericRepository<Login>
{
    Login GetByCpf(string CPF);
}
