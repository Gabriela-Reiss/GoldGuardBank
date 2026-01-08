using BankSystem.Application.DTOs;
using BankSystem.Domain.Model;

namespace BankSystem.Application.Services.Interfaces;

public interface IJwtService
{
    LoginResultDto GerarToken(Usuario usuario);
}
