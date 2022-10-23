using System;
using System.Collections.Generic;
using System.Text;
using TableDataTypes.Person;
using TableDataTypes.Helpers;
namespace TableDataTypes.Iteraction
{
    static class GettingInfo
    {
        public static Line<string, int, Address> GetNewLine()
        {
            return new Line<string, int, Address>(GetNewStr("Enter Name"), GetNewInt("Enter Age"), GetNewAddress());
        }
        public static int GetNewInt(string str)
        {
            Console.WriteLine(str);
            int newInt;
            try
            {
                newInt = int.Parse(Console.ReadLine());
            }
            catch
            {
                IteractionMessages.WriteInvalideInput();
                return GetNewInt(str);
            }

            return newInt;
        }
        public static Address GetNewAddress()
        {
            Console.WriteLine("Enter Address");
            return new Address(GetNewStr("Enter street"), GetNewStr("Enter sity"), GetNewStr("Enter country"));
        }
        public static string GetNewStr(string str)
        {
            Console.WriteLine(str);
            return Console.ReadLine();
        }
        public static Table<string, int, Address> PutDefaultLines()
        {
            Table<string, int, Address> table = new Table<string, int, Address>();
            foreach (Line<string, int, Address> line in Constants.DefaultLines)
            {
                table.AddNewLine(line);
            }
            return table;
        }
        public static int GetPageNumber(Table<string, int, Address> table)
        {
            int page = default;
            Console.WriteLine($"Total pages: {table.Pages.Count}");
            while (page < 1 || page > table.Pages.Count)
            {
                page = GetNewInt("Enter page number");
            }
            return page;
        }
    }
}
