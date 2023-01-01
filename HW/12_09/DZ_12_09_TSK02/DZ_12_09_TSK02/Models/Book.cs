using System;
using System.Collections.Generic;
using Bogus;

namespace DZ_12_09_TSK02.Models
{
    public class Book
    {
        public Guid BookId { get; set; }
        public string Name { get; set; }
        public Guid AuthorId { get; set; }
        public Author Author { get; set; }
        public DateTime Year { get; set; }
        public ICollection<UserBook> UserBooks { get; set; }

        public static IEnumerable<Book> Generate(int n, Guid[] authorIds)
        {
            var f = new Faker<Book>();

            f.RuleFor(x => x.BookId, x => x.Random.Guid());
            f.RuleFor(x => x.Name, x => x.Random.Word());
            f.RuleFor(x => x.AuthorId, x => authorIds[x.Random.Int(0, authorIds.Length - 1)]);
            f.RuleFor(x => x.Year, x => x.Date.Past());
            return f.Generate(n);
        }
    }
}