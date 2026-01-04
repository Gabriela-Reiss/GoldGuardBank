using System.Globalization;
using BankSystem.Domain.Model;

namespace BankSystem.Domain.Repositories.Interfaces;

public interface IUsuarioRepository : IGenericRepository<Usuario>
{
    Task<Usuario> GetByCPF(string CPF);


}
