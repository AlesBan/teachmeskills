using OopFirst.MainClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OopFirst.Shops
{
    class FoodShop : Shop
    {
        public FoodShop()
        {
            Products = new List<Product>
            {
                new Product("Яблоко", 13, 100),
                new Product("Груша", 13, 50),
                new Product("Арбуз", 13, 123)
            };
        }
    }
}
