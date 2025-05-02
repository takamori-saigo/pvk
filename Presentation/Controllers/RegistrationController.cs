using Core;
using Core.AuthorizationModel;
using DataAcces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace pvk.Controllers;

public class RegistrationController : Controller
{
    private readonly DataBaseContext _context;
    public RegistrationController(DataBaseContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    [AllowAnonymous]
    public IActionResult Register()
    {
        return View("Registration");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Register(RegisterViewModel model)
    {
        if (_context.Users.Any(x => x.Email == model.Email))
        {
            Console.WriteLine("такой пользователь уже есть");
            return View(model);
        }

        var user = new User
        {
            Email = model.Email,
            PasswordHash = HashPassword.MakeHash(model.Password),
            Login = model.Login,
            Role = model.Role
        };
        Console.WriteLine("регистрация прошла успешно");
        _context.Users.Add(user);
        _context.SaveChanges();
        return View("Registration");

    }
}