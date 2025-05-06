using System.Security.Claims;
using Core;
using DataAcces;
using Microsoft.AspNetCore.Mvc;

namespace pvk.Controllers;

public class ProfileController : Controller
{
    private readonly DataBaseContext _dataBaseContext;

    public ProfileController(DataBaseContext dataBaseContext)
    {
        _dataBaseContext = dataBaseContext;
    }
    
    [HttpGet]
    public IActionResult Profile()
    {
        var user = GetCurrentUser();
        return View(user);
    }

    [HttpPost]
    public IActionResult UpdateProfileField(string field, string value)
    {
        var user = GetCurrentUser();
        
        switch (field.ToLower())
        {
            case "email":
                user.Email = value;
                break;
            case "login":
                user.Login = value;
                break;
            case "name":
                user.Name = value;
                break;
            case "surname":
                user.Surname = value;
                break;
        }

        _dataBaseContext.SaveChanges();
        return RedirectToAction("Profile");
    }

    private User GetCurrentUser()
    {
        var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
        return _dataBaseContext.Users.First(u => u.Id == userId);
    }
}