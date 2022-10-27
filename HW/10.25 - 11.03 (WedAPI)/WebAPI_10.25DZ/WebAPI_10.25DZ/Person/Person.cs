using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_10._25DZ.Interfaces;

namespace WebAPI_10._25DZ
{
    public class Person : IPerson
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        string IPerson.ToString()
        {
            return $"Name: {Name}, Age: {Age}";
        }
    }
}
