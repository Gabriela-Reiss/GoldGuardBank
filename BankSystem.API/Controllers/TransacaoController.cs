using System.Security.Claims;
using BankSystem.Application.DTOs;
using BankSystem.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankSystem.API.Controllers;


[Authorize]
public class TransacaoController : Controller
{

    private readonly ITransacaoService _service;

    public TransacaoController(ITransacaoService service)
    {
        _service = service;
    }
    public IActionResult Deposito() => View();

    [HttpPost]
    public async Task<IActionResult> Deposito(ValorDto dto)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        await _service.DepositarAsync(userId, dto.Valor);
        return RedirectToAction("Index", "Home");
    }

    public IActionResult Saque() => View();

    [HttpPost]
    public async Task<IActionResult> Saque(ValorDto dto)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        await _service.SacarAsync(userId, dto.Valor);
        return RedirectToAction("Index", "Home");
    }

    public IActionResult Transferencia() => View();

    [HttpPost]
   
    public async Task<IActionResult> Transferencia(TransferenciaDto dto)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        await _service.TransferirAsync(
            userId,
            dto.NumeroContaDestino,
            dto.Valor
        );

        return RedirectToAction("Index", "Home");
    }

}
