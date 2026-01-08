using BankSystem.Application.DTOs;
using BankSystem.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankSystem.API.Controllers;

public class UsuarioController : Controller
{
    private readonly IAuthService _service;

    public UsuarioController(IAuthService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegistroUsuarioDto dto)
    {
        await _service.RegistryAsync(dto);
        return RedirectToAction("Index", "Login");
    }

}
