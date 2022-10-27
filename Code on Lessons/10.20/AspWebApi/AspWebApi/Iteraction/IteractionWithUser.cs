using System;
using System.Collections.Generic;
using System.Text;
using TableDataTypes.Exeptions;
using TableDataTypes.Helpers;
using TableDataTypes.JsonIteraction;
using TableDataTypes.Person;

namespace TableDataTypes.Iteraction
{
    internal class IteractionWithUser
    {
        protected IteractionWithUser()
        {

        }
        public static void Start()
        {
            IteractionMessages.GreetingMes();
            Table<string, int, Address> table = new Table<string, int, Address>();
            JsonIteractor.JsonWrite(PutDefaultLines());
            JsonIteractor.JsonRead().PrintAllTable();

            //PutLinesInTable(ref table);
        }
        public static void PutLinesInTable(ref Table<string, int, Address> table)
        {
            string choice = string.Empty;
            while (choice != "output")
            {
                table.AddNewLine(GetNewLine());
                choice = IteractionMessages.AskForContinue();
            }
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
        public static Line<string, int, Address> GetNewLine()
        {
            return new Line<string, int, Address>(GetNewStr("Enter Name"), GetNewInt(), GetNewAddress());
        }
        public static int GetNewInt()
        {
            Console.WriteLine("Enter your number");
            int newInt;
            try
            {
                newInt = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Invalide input");
                return GetNewInt();
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
    }
}
