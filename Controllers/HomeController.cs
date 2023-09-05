using System.Diagnostics;
using System.IO.Compression;
using Microsoft.AspNetCore.Mvc;
using LoginParty.Models;

namespace LoginParty.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }


    [HttpPost("login/create")]
    public IActionResult CreateLogin(string Name)
    {
        HttpContext.Session.SetString("Name", Name);
        HttpContext.Session.SetInt32("Answer", 22);
        return RedirectToAction("Display");
    }

    [HttpGet("logins")]
    public ViewResult Display()
    {
        return View("Display");
    }

    [HttpPost("AddOne")]
    public IActionResult AddOne()
    {
        int? Previous = HttpContext.Session.GetInt32("Answer");
        if (Previous.HasValue)
        {
            int Now = Previous.Value + 1;
            HttpContext.Session.SetInt32("Answer", Now);
        }
            return RedirectToAction("CompletedMath");
    }

    [HttpGet("CompletedMath")]
    public ViewResult CompletedMath()
    {
        int? CurrentNumb = HttpContext.Session.GetInt32("Answer");
        ViewData["Answer"] = CurrentNumb;
        return View("Display");
    }

    [HttpPost("SubOne")]
    public IActionResult SubOne()
    {
        int? Previous = HttpContext.Session.GetInt32("Answer");
        if (Previous.HasValue)
        {
            int Now = Previous.Value - 1;
            HttpContext.Session.SetInt32("Answer", Now);
        }
            return RedirectToAction("CompletedMath");
    }


    [HttpPost("TimesTwo")]
    public IActionResult TimesTwo()
    {
        int? Previous = HttpContext.Session.GetInt32("Answer");
        if (Previous.HasValue)
        {
            int Now = Previous.Value * 2;
            HttpContext.Session.SetInt32("Answer", Now);
        }
            return RedirectToAction("CompletedMath");
    }


    [HttpPost("RandomValue")]
    public IActionResult RandomValue()
    {
        Random rando = new();
        int? Previous = HttpContext.Session.GetInt32("Answer");
        if (Previous.HasValue)
        {
        int Now = Previous.Value + rando.Next(1, 100);
        HttpContext.Session.SetInt32("Answer", Now);
        }
        return RedirectToAction("CompletedMath");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
