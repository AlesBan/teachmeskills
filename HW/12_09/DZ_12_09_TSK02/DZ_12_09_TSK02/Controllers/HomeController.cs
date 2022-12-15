using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks.Dataflow;
using DZ_12_09_TSK02.Models;
using Microsoft.AspNetCore.Mvc;

namespace DZ_12_09_TSK02.Controllers
{
    public class HomeController : Controller
    {
        private Context _context;

        public HomeController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return null;
        }
        [HttpGet]
        public IActionResult TakenBooks()
        {
            return Ok(GetTakenBooks());
        }

        public IEnumerable<TakenBook> GetTakenBooks()
        {
            var takenBooks =
                (from ub in _context.UserBooks
                join u in _context.Users on ub.UserId equals u.UserId
                join b in _context.Books on ub.BookId equals b.BookId
                join au in _context.Authors on b.AuthorId equals au.AuthorId
                select new TakenBook
                {
                    UserFullName = u.FirstName + " " + u.LastName,
                    UserBirthDate = u.BirthDate,
                    BookName = b.Name,
                    BookYear = b.Year,
                    AuthorFullName =  au.FirstName + " " + au.LastName,
                }).ToArray();
            return takenBooks;
        }
    }
}