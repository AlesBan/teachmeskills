using System;
using System.Collections.Generic;
using System.Text;

namespace TableDataTypes.Person
{
    public class Address
    {
        public string Street { get; set; }
        public string Sity { get; set; }
        public string Country { get; set; }
        public Address()
        {

        }
        public Address(string street, string sity, string contry)
        {
            Street = street;
            Sity = sity;
            Country = contry;
        }
        public override string ToString()
        {
            return $"{Street}, {Sity}, {Country}";
        }
    }
}
