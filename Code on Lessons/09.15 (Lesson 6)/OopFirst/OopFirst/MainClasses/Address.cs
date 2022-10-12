using System;
using System.Collections.Generic;
using System.Text;

namespace OopFirst.MainClasses
{
    public class Address
    {
        public string country { get; set; }
        public string city { get; set; }
        public Address()
        {
            country = "defalt";
            city = "defalt";
        }
        public string ToStringAddress()
        {
            return country + ", " + city;
        }
    }
}
