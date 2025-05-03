using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace pvk.Controllers;


[Authorize]
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View("HomePage"); 
    }
}
