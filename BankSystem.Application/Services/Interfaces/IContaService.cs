using BankSystem.Application.DTOs;

namespace BankSystem.Application.Services.Interfaces;

public interface IContaService
{
    Task<HomeContaDto> ObterResumoAsync(int usuarioId);
    Task<IEnumerable<ExtratoDto>> ObterExtratoAsync(int usuarioId);
}


