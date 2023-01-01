using System;
using System.Collections;
using System.Collections.Generic;
using Bogus;

namespace DZ_12_09_TSK02.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection<UserBook> UserBooks { get; set; }

        public static IEnumerable<User> Generate(int n)
        {
            var f = new Faker<User>();

            f.RuleFor(x => x.UserId, x => x.Random.Guid());
            f.RuleFor(x => x.FirstName, x => x.Person.FirstName);
            f.RuleFor(x => x.LastName, x => x.Person.LastName);
            f.RuleFor(x => x.Email, x => x.Random.Word() + x.Random.Number(10000).ToString() + "@example.com");
            f.RuleFor(x => x.BirthDate, x => x.Person.DateOfBirth);

            return f.Generate(n);
        }
    }
}