using System;
using System.Collections.Generic;
using System.Text;
using TableDataTypes.Helpers;

namespace TableDataTypes.Iteraction
{
    static class IteractionMessages
    {
        public static void WriteAvailableOptions()
        {
            Console.WriteLine("\n\nAvailable options: ");
            for (int i = 0; i < Constants.AvaliableOptions.Length; i++)
            {
                Console.WriteLine($"{i + 1}) {Constants.AvaliableOptions[i]}");
            }
        }
        public static void WriteInvalideInput()
        {
            Console.WriteLine("Input is invalid\nTry again");
        }
        public static string AskForContinue()
        {
            Console.WriteLine("Enter smt or press Enter if you want to continue\n adding lines");
            Console.WriteLine("Oterwise print output");
            return Console.ReadLine();
        }
        public static void GreetingMes()
        {
            Console.WriteLine("Hello! You already have Person table with 3 columns: \nName | Age | Address\n");
        }
        public static void PrintNumberOfTypeMes()
        {
            Console.WriteLine("Write number of type you want to add");
        }
        public static void ShowTypes()
        {
            int index = 0;
            foreach (Type type in Constants.DataTypes)
            {
                Console.WriteLine($"{++index}) {type.Name}");
            }
        }
    }
}
