using Core;
using DataAcces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace pvk.Controllers;

public class AdminController: Controller
{
    private DataBaseContext _context;

    public AdminController(DataBaseContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    [Authorize(Roles = "admin")]
    public IActionResult AdminPanel()
    {
        var users = _context.Users.Where(x => x.Role != Role.admin).ToList();
        return View("AddInternsInGroup", users);
    }

    [HttpPost]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> FindInter(string loginOfUser)
    {
        var users = from u in _context.Users 
            where u.Role != Role.admin 
            where u.Login == loginOfUser
            select u;

        return PartialView("_UsersTablePartial", users);
    }
}