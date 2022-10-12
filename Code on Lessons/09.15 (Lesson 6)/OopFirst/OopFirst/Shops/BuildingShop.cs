using OopFirst.MainClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OopFirst.Shops
{
    class BuildingShop : Shop
    {
        public BuildingShop()
        {
            Products = new List<Product>
            {
                new Product("Молоток", 13, 100),
                new Product("Кирпич", 13, 50),
                new Product("Пила", 13, 123)
            };
        }
    }
}
