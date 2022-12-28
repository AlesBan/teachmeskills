using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private static IEnumerable<Person> PersonsDb = new List<Person>()
        {
            new Person()
            {
                Name = "Amogus",
                Age = 9
            },
            new Person()
            {
                Name = "Amogus2",
                Age = 19
            },
            new Person()
            {
                Name = "Amogus4",
                Age = 13
            }
        };

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(PersonsDb);
        }

        public IActionResult Privacy()
        {
            ViewBag.Persons = PersonsDb;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}