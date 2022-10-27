using System;
using System.Collections.Generic;
using System.Text;
 
namespace OopFirst.MainClasses
{
    public class Director
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public string ToStringDirector()
        {
            return Name + ", " + Age + "years";
        }
    }
}
