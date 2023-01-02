using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DZ_12_17_TSK03.Models;
using Microsoft.EntityFrameworkCore;

namespace DZ_12_17_TSK03.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private Context _context { get; set; }

        public HomeController(ILogger<HomeController> logger, Context context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RequestTable()
        {
            var requests =
                (from sr in _context.SupportRequests
                    join ss in _context.SupportSpecialists on sr.SpecialistId equals ss.Id
                    join d in _context.Departments on ss.DepartmentId equals d.Id
                    select new TableRequest
                    {
                        RequestTheme = sr.RequestTheme,
                        DepartmentName = d.Name,
                        SpecialistName = ss.Name,
                        Status = sr.Status
                    }).ToArray();
            return View(requests);
        }

        public IActionResult NewRequest()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetNewRequest(SupportRequestDto supportRequestDto)
        {
            var random = new Random();
            var supportRequest = new SupportRequest(supportRequestDto);
            var department = _context.Departments.Single(x => x.Name == supportRequestDto.Department);

            var specialists = _context.SupportSpecialists.Where(x => x.DepartmentId == department.Id).ToArray();
            supportRequest.SpecialistId = specialists[random.Next(specialists.Length)].Id;
            _context.SupportRequests.Add(supportRequest);
            _context.SaveChangesAsync();
            return Ok();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}