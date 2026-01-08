using BankSystem.Application.DTOs;
using BankSystem.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankSystem.API.Controllers;

public class LoginController : Controller
{
    private readonly IAuthService _service;

    public LoginController(IAuthService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View("Login");
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        var result =  await _service.LoginAsync(dto);

        Response.Cookies.Append("jwt", result.Token, new CookieOptions
        {
            HttpOnly = true,
            Secure = Request.IsHttps,
            SameSite = SameSiteMode.Strict,
            Expires = result.ExpiraEm
        });

        return RedirectToAction("Index", "Home");
    }

    

    public IActionResult Logout()
    {
        Response.Cookies.Delete("jwt");
        return RedirectToAction("Index");
    }


}
