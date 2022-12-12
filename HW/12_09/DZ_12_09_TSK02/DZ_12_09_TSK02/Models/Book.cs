using System;
using System.Collections.Generic;

namespace DZ_12_09_TSK02.Models
{
    public class Book
    {
        public Guid BookId { get; set; }
        public string Name { get; set; }
        public Guid AuthorId  { get; set; }
        public Author Author { get; set; }
        public DateTime Year { get; set; }
        public ICollection<UserBook> UserBooks { get; set; }
    }
}