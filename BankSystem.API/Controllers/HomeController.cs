using System.Security.Claims;
using BankSystem.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankSystem.API.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IContaService _contaService;

        public HomeController(IContaService contaService)
        {
            _contaService = contaService;
        }

        public async Task<IActionResult> Index()
        {
            var usuarioId = int.Parse(
                User.FindFirst(ClaimTypes.NameIdentifier)!.Value
            );

            var model = await _contaService.ObterResumoAsync(usuarioId);

            return View(model);
        }
    }
}
