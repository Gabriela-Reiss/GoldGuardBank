using System.Security.Claims;
using BankSystem.Application.Services.Interfaces;
using BankSystem.Domain.Model.Enums;
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

    // 📌 Carteira do usuário
    public async Task<IActionResult> Index()
    {
        var userId = int.Parse(
            User.FindFirst(ClaimTypes.NameIdentifier)!.Value
        );

        var carteira = await _investimentoService.ObterCarteiraAsync(userId);
        return View(carteira);
    }

    // 📌 Tela de escolha do perfil
    [HttpGet]
    public IActionResult Perfis()
    {
        return View();
    }

    // 📌 Consulta de ativos (API)
    [HttpGet]
    public async Task<IActionResult> Ativos(PerfilInvestimento perfil)
    {
        var ativos = await _ativoService.ObterPorPerfilAsync(perfil);
        return View(ativos);
    }

    // 📌 Compra de ativo (AÇÃO DE NEGÓCIO)
    [HttpPost]
    public async Task<IActionResult> Comprar(int ativoId, decimal quantidade)
    {
        var userId = int.Parse(
            User.FindFirst(ClaimTypes.NameIdentifier)!.Value
        );

        await _investimentoService.ComprarAsync(
            userId,
            ativoId,
            quantidade
        );

        return RedirectToAction(nameof(Index));
    }
}
