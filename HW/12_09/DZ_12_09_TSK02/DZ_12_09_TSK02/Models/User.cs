using System;
using System.Collections;
using System.Collections.Generic;

namespace DZ_12_09_TSK02.Models
{
    public class User
    {
        public Guid UserId  { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection<UserBook> UserBooks { get; set; }
    }
}