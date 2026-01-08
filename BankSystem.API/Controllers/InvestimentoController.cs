using System.Security.Claims;
using BankSystem.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankSystem.API.Controllers;

[Authorize]
public class InvestimentoController : Controller
{
    private readonly IInvestimentoService _investimentoService;
    private readonly IAtivoService _ativoService;

    public InvestimentoController(
        IInvestimentoService investimentoService,
        IAtivoService ativoService)
    {
        _investimentoService = investimentoService;
        _ativoService = ativoService;
    }





    public async Task<IActionResult> Index()
    {
        var userId = int.Parse(
            User.FindFirst(ClaimTypes.NameIdentifier)!.Value
        );

        var ativos = await _ativoService.ObterAtivosAsync();
        var carteira = await _investimentoService.ObterCarteiraAsync(userId);

        ViewBag.Carteira = carteira;

        return View(ativos);
    }




    [HttpPost]
    public async Task<IActionResult> Comprar(int ativoId, decimal quantidade)
    {
        var userId = int.Parse(
            User.FindFirst(ClaimTypes.NameIdentifier)!.Value
        );

        await _investimentoService.ComprarAsync(userId, ativoId, quantidade);

        TempData["Sucesso"] = "Investimento realizado com sucesso!";

        return RedirectToAction(nameof(Index));
    }

}
