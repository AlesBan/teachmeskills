using System;
using System.Collections.Generic;
using System.Text;
using TableDataTypes.Iteraction;
using TableDataTypes.JsonIteraction;
using TableDataTypes.Person;

namespace TableDataTypes.Delegats
{
    static class MainFunctions
    {
        public static readonly Action<Table<string, int, Address>> OutPutFunc = (table) => OutPutFunction(table);
        public static readonly Action ExitFunc = () => ExitFunction();
        public static readonly Action<Table<string, int, Address>> AddNewLineToListFunc = (table) => AddNewLineToListFunction(ref table);
        public static readonly Action<Table<string, int, Address>> SetPaginationFunc = (table) => SetPaginationFunction(ref table);
        public static readonly Func<Table<string, int, Address>> GetTableFromNewFileFunc = () => GetTableFromNewFile();


        public static Table<string, int, Address> GetTableFromNewFile()
        {
            try
            {
                return JsonIteractor.JsonRead(GettingInfo.GetNewStr("Enter full file path"));
            }
            catch
            {
                return null;
            }
        }
        public static void SetPaginationFunction(ref Table<string, int, Address> table)
        {
            table.ItemsOnPage = GettingInfo.GetNewInt("pagination number");
        }
    public static void AddNewLineToListFunction(ref Table<string, int, Address> table)
        {
            table.AddNewLine(GettingInfo.GetNewLine());
        }
        public static void OutPutFunction(Table<string, int, Address> table)
        {
            table.FillPaginationList();
            table.PrintTable();
        }
        public static void ExitFunction()
        {
            Console.Clear();
            Console.WriteLine("Goodbye!");
            Environment.Exit(0);
        }
    }
}
