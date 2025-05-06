using System;
using System.Security.Claims;
using DataAcces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace pvk.Controllers;


[Authorize]
public class HomeController : Controller
{
    private readonly DataBaseContext _context;
    public HomeController(DataBaseContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
        var user = _context.Users.First(u => u.Id == userId);
        return View("HomePage", user); 
    }
}
