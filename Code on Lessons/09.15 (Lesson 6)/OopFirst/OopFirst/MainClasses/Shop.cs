using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace OopFirst.MainClasses
{
    public class Shop
    {
        public string NameOfShop { get; set; }
        public Address Address { get; set; } 
        public double Income { get; set; }
        public Director Director { get; set; }
        public string LifeTime { get; set; }
        public List<Product> Products { get; set; }
        public void GetIncome()
        {
            WriteLine($"Total income: {Income}");
        }
        public void ShowAddress()
        {
            WriteLine($"Shop's address: {Address.ToStringAddress()}");
        }
        public void AddNewProduct(string name, double price, int num)
        {
            Products.Add(new Product(name, price, num));
        }
        public void AddProduct(Product product, int num)
        {
            Products[Products.IndexOf(product)].Count += num;
        }

    }
}
