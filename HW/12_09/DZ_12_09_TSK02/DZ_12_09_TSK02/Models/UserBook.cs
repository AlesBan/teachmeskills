using System;
using System.Collections.Generic;
using Bogus;

namespace DZ_12_09_TSK02.Models
{
    public class UserBook
    {
        public Guid UserBookId { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid BookId { get; set; }
        public Book Book { get; set; }
        
        public static IEnumerable<UserBook> Generate(int n,  Guid[] usersIds, Guid[] booksIds)
        {
            var f = new Faker<UserBook>();
            
            f.RuleFor(x => x.UserBookId, x => x.Random.Guid());
            f.RuleFor(x => x.UserId, x => usersIds[x.Random.Int(0, usersIds.Length - 1)]);
            f.RuleFor(x => x.BookId, x => booksIds[x.Random.Int(0, booksIds.Length - 1)]);
            
            return f.Generate(n);
        }
    }
}