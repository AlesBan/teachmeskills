using System;
using Web_10._27DZ.Interfaces;

namespace PersonEnv
{
    public class Person : IPerson
    {
        public Guid id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public Person()
        {

        }

        public Person(Guid id, string name, int age)
        {
            Name = name;
            Age = age;
            this.id = id;
        }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
            id = Guid.NewGuid();
        }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}";
        }
    }
}
