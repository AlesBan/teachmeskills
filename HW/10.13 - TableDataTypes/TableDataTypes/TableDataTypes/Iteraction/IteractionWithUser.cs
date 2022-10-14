using System;
using System.Collections.Generic;
using System.Text;
using TableDataTypes.Exeptions;
using TableDataTypes.Helpers;
using TableDataTypes.Person;

namespace TableDataTypes.Iteraction
{
    class IteractionWithUser
    {
        public static void Start()
        {
            IteractionMessages.GreetingMes();
            IteractionMessages.ShowTypes();
            Table<string, int, Address> table = new Table<string, int, Address>();

            string choice = string.Empty;
            while (choice != "output")
            {
                table.AddNewLine(GetNewLine());
                choice = AskForContinue();
            }
            table.PrintAllTable();
        }

        public Line<string, int, Address> GetNewLine()
        {
            return new Line<string, int, Address>(GetNewStr("Enter Name"), GetNewInt(), GetNewAddress());
        }
        public int GetNewInt()
        {
            Console.WriteLine("Enter your number");
            int newInt = default;
            try
            {
                newInt = int.Parse(Console.ReadLine());
            }
            catch
            {
                return GetNewInt();
            }

            return newInt;
        }
        public bool GetNewBool()
        {
            Console.WriteLine("Enter your bool");
            bool newBool = default;
            try
            {
                newBool = bool.Parse(Console.ReadLine());
            }
            catch
            {
                return GetNewBool();
            }

            return newBool;
        }
        public Address GetNewAddress()
        {
            return new Address(GetNewStr("Enter street"), GetNewStr("Enter sity"), GetNewStr("Enter country"));
        }
        public string GetNewStr(string str)
        {
            Console.WriteLine("Enter your str");
            return Console.ReadLine();
        }
        
        
    }
}
