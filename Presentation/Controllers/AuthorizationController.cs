using Core.AuthorizationModel;
using DataAcces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace pvk.Controllers;

public class AuthorizationController: Controller
{
    private readonly DataBaseContext _context;
    public AuthorizationController(DataBaseContext context)
    {
        _context = context;
    }
    
    [AllowAnonymous]
    [HttpGet]
    public IActionResult Authorization()
    {
        return View();
    }

    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public IActionResult Authorization(LoginViewModel model)
    {
        var user = _context.Users.FirstOrDefault(u => u.Login == model.Login);
        if (user == null) return View(model);

        if (!VerifyPassword(model.Password, user.PasswordHash))
        {
            Console.WriteLine("пользователь не найден");
            return View(model);
        }

        Console.WriteLine("авторизация прошла успешно");
        return View(model);
    }

    private bool VerifyPassword(string inputPassword, string passwordHash) => GetHash(inputPassword) == passwordHash;

    private string GetHash(string password) => password.Select(x => x - '0').Select(x => x*355).Sum().ToString();
}