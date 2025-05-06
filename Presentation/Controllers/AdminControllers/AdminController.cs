using System.Security.Claims;
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

        var user = FindAdmin();
        ViewBag.Groups = _context.Groups.Where(x => user.Id == x.ManagerId).ToList(); 
        var users = query.ToList();
        return View("AddInternsInGroup", users);
    }

    [HttpPost]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> AddToGroup(int userId, int groupId)
    {
         var user = await _context.Users.FindAsync(userId);
         user.GroupId = groupId;
         await _context.SaveChangesAsync();
         return RedirectToAction("AdminPanel", new { searchTerm = TempData["LastSearch"] });
    }

    [HttpGet]
    [Authorize(Roles = "admin")]
    public IActionResult CreateGroup()
    {
        return View("CreateGroup");
    }
    
    [HttpPost]
    [Authorize(Roles = "admin")]
    public IActionResult CreateGroup(string nameOfGroup)
    {
        var user = FindAdmin();
        _context.Groups.Add(new Group
        {
            Name = nameOfGroup,
            ManagerId =user.Id,
            Manager = user
        });
        _context.SaveChanges();
        return View();
    }

    private User FindAdmin()
    {
        var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
        var user = _context.Users.First(u => u.Id == userId);
        return user;
    }
}