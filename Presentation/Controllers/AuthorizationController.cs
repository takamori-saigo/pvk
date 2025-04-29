using Microsoft.AspNetCore.Mvc;

namespace pvk.Controllers;

public class AuthorizationController: Controller
{
    public IActionResult Authorization()
    {
        return View();
    }

    public IActionResult Registration()
    {
        return View();
    }
}