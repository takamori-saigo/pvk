using System.Security.Claims;
using Core;
using Core.AuthorizationModel;
using DataAcces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;
using Task = System.Threading.Tasks.Task;

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
    public async Task<IActionResult> Register(RegisterViewModel model)
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
        await SignInUserAsync(user);
        return RedirectToAction("Index", "Profile");
    }
    
    public async Task SignInUserAsync(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Login),
        };

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme)),
            new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTime.UtcNow.AddDays(7)
            });
    }
}