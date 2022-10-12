using System;
using System.Collections.Generic;
using System.Text;

namespace OopFirst.MainClasses
{
    class Security
    {
        public string Name { get; set; }
        public string Schedule { get; set; }
        public double Price { get; set; }
        public Security()
        {
            Name = "default";
            Schedule = "default";
            Price = 0;
        }
    }
}
