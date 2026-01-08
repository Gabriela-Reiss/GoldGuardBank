using BankSystem.Application.DTOs;

namespace BankSystem.Application.Services.Interfaces;

public interface IAuthService
{
    Task RegistryAsync(RegistroUsuarioDto usuario);
    Task<LoginResultDto> LoginAsync(LoginDto login);
}
