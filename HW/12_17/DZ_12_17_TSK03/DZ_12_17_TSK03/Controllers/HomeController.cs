using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DZ_12_17_TSK03.Models;

namespace DZ_12_17_TSK03.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    public static List<Person> Persons = new List<Person>()
    {
        new Person()
        {
            name = "Abobus",
            age = 9
        },
        new Person()
        {
            name = "Ales",
            age = 19
        }
    };

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public static IActionResult addPerson(Person person)
    {
        Persons.Add(person);
            
        return View();
    }
    public IActionResult CustomPage()
    {
        return View("Custom");
    }
    public IActionResult Index()
    {
        ViewData["Date"] = DateTime.Now;
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
}