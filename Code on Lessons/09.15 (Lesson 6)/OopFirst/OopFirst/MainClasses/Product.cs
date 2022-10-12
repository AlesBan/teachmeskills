using System;
using System.Collections.Generic;
using System.Text;

namespace OopFirst.MainClasses
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public Product(string name, double price, int count)
        {
            Name = name;
            Price = price;
            Count = count;
        }

        public string ProductStr()
        {
            return Name + " " + Price;
        }
    }
}
