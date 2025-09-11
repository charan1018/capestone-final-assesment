using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyMvcProjectSessions.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MyMvcProjectSessions.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public string SessionName { get; private set; }
    public string SessionAge { get; private set; }

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult Index1()
    {
        //set session data
        HttpContext.Session.SetString(SessionName, "Kavitha");
        HttpContext.Session.SetInt32(SessionAge, 20);

        return View();
    }
    public IActionResult About()
    {
        //Retrive session data
        ViewBag.Name = HttpContext.Session.GetString(SessionName);
        ViewBag.Age = HttpContext.Session.GetInt32(SessionAge);

        ViewData["Message"] = "ASP.NET Core!";

        return View();
    }

    public IActionResult Contact()
    {
        ViewData["Message"] = "Your Contact page";
        return View();
    }

    public IActionResult ErrorMessage()
    {
        ViewData["Meassage"] = "ErrorMeassage";
        return View();
    }
}
