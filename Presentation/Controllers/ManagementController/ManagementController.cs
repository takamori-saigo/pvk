using System.Security.Claims;
using DataAcces;
using Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace pvk.Controllers.ManagementController;

public class ManagementController: Controller
{
    private DataBaseContext _context;

    public ManagementController(DataBaseContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    [Authorize(Roles = "admin")]
    public IActionResult GroupList()
    {
        var user = GetCurrentUser();
        var groups = _context.Groups.Where(x => x.ManagerId == user.Id);

        return View("Management", groups);
    }
    
    private User GetCurrentUser()
    {
        var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
        return _context.Users.First(u => u.Id == userId);
    }
    
    [HttpGet]
    [Authorize(Roles = "admin")]
    public IActionResult GetGroupUsers(int groupId)
    {
        var users = _context.Users.Where(u => u.GroupId == groupId);
        ViewBag.GroupId = groupId;
        return View("UserSelector", users);
    }
    
    [HttpGet]
    [Authorize(Roles = "admin")]
    public IActionResult UserSelected(int userId, int groupId)
    {
        return RedirectToAction("Index", "Home");
    }
    
}