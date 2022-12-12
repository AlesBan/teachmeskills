using System;
using System.Collections.Generic;
using Bogus;
using Bogus.DataSets;

namespace DZ_12_09_TSK02.Models
{
    public class Author
    {
        public Guid AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection<Book> Books { get; set; }
        public static IEnumerable<Author> Generate(int n)
        {
            var f = new Faker<Author>();
            
            f.RuleFor(x => x.AuthorId, x => x.Random.Guid());
            f.RuleFor(x => x.FirstName, x => x.Person.FirstName);
            f.RuleFor(x => x.LastName, x => x.Person.LastName);
            f.RuleFor(x => x.Country, x => x.Address.Country());
            f.RuleFor(x => x.BirthDate, x => x.Person.DateOfBirth);
            
            return f.Generate(n);
        }
    }
}