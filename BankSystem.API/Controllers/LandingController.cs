using Microsoft.AspNetCore.Mvc;

namespace BankSystem.API.Controllers;

public class LandingController : Controller
{
    public IActionResult Page()
    {
        return View();
    }
}
