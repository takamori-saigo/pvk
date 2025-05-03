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
    public async Task<IActionResult> Authorization(LoginViewModel model)
    {
        var user = _context.Users.FirstOrDefault(u => u.Login == model.Login);
        if (user == null) return View(model);

        if (!VerifyPassword(model.Password, user.PasswordHash))
        {
            return View(model);
        }

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

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Authorization", "Authorization");
    }
    // public int Id { get; set; }
    // public string Email { get; set; } = null!;
    // public string Login { get; set; } = null!;
    // public string PasswordHash { get; set; } = null!;
    //
    // public int RoleId { get; set; }
    // public Role? Role { get; set; } = null!;
    //
    // public int? GroupId { get; set; }
    // public Group? Group { get; set; }
    
    private bool VerifyPassword(string inputPassword, string passwordHash) => HashPassword.MakeHash(inputPassword) == passwordHash;
}