using System.Security.Claims;
using BankSystem.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankSystem.API.Controllers;


[Authorize]
public class ContaController : Controller
{
    private readonly IContaService _contaService;

    public ContaController(IContaService contaService)
    {
        _contaService = contaService;
    }

    public async Task<IActionResult> Extrato()
    {
        var usuarioId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        
        var extrato = await _contaService.ObterExtratoAsync(usuarioId);

        return View(extrato);
    }
}
