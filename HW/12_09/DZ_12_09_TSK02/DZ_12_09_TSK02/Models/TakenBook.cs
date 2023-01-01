using System;

namespace DZ_12_09_TSK02.Models
{
    public class TakenBook
    {
        public string UserFullName { get; set; }
        public DateTime UserBirthDate { get; set; }
        public string BookName { get; set; }
        public DateTime BookYear { get; set; }
        public string AuthorFullName { get; set; }
    }
}