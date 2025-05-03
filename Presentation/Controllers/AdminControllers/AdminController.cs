using Core;
using DataAcces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


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
    public IActionResult AdminPanel(string searchTerm = null)
    {
        IQueryable<User> query = _context.Users.Where(x => x.Role != Role.admin);

        if (!string.IsNullOrEmpty(searchTerm))
        {
            query = query.Where(u => u.Login.Contains(searchTerm));
        }

        ViewBag.Groups = _context.Groups.ToList(); 
        var users = query.ToList();
        return View("AddInternsInGroup", users);
    }

    [HttpPost]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> AddToGroup(int userId, int groupId)
    {
        return RedirectToAction("AdminPanel", new { searchTerm = TempData["LastSearch"] });
    }
}