using System;

namespace DZ_12_09_TSK02.Models
{
    public class UserBook
    {
        public Guid UserBookId { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid BookId { get; set; }
        public Book Book { get; set; }
    }
}