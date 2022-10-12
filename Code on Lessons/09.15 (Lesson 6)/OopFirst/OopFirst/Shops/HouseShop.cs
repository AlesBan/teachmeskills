using OopFirst.MainClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OopFirst.Shops
{
    class HouseShop : Shop
    {
        public HouseShop()
        {
            Products = new List<Product>
            {
                new Product("Шампунь", 12, 100),
                new Product("Мыло", 54, 50),
                new Product("Гель для душа", 78, 123)
            };
        }
    }
}
