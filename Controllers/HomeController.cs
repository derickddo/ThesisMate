using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ThesisMate.Models;

namespace ThesisMate.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        //get the current user from session
        var user = HttpContext.Session.GetString("User");
        if (user == null)
        {
            return RedirectToAction("Login", "Account");
        }

        //get the user's role
        var userObj = JsonConvert.DeserializeObject<User>(user);
        if (userObj == null)
        {
            return RedirectToAction("Login", "Account");
        }
        var role = userObj.Role.ToString();
        
        switch (role)
        {
            case "Admin":
                return RedirectToAction("Index", "Admin");
            case "Student":
                return RedirectToAction("Index", "Student");
            case "Supervisor":
                return RedirectToAction("Index", "Supervisor");
            default:
                return RedirectToAction("Login", "Account");
        }
        


        
    }

    public IActionResult Forbidden()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
