using System;
using System.Collections.Generic;
using System.Text;
using TableDataTypes.Iteraction;
using TableDataTypes.JsonIteraction;
using TableDataTypes.Person;
using System.Text.Json;

namespace TableDataTypes.Delegats
{
    static class MainFunctions
    {
        public static readonly Action<Table<string, int, Address>> OutPutFunc = (table) => OutPutFunction(table);
        public static readonly Action ExitFunc = () => ExitFunction();
        public static readonly Func<Table<string, int, Address>, Table<string, int, Address>> AddNewLineToListFunc = (table) => AddNewLineToListFunction(ref table);
        public static readonly Action<Table<string, int, Address>> SetPaginationFunc = (table) => SetPaginationFunction(ref table);
        public static readonly Func<Table<string, int, Address>> GetTableFromNewFileFunc = () => GetTableFromNewFile();
        public static readonly Func<Table<string, int, Address>, Table<string, int, Address>> DeleteItemFunc = (table) => DeleteItem(ref table);

        public static Table<string, int, Address> DeleteItem(ref Table<string, int, Address> table)
        {
            int index = default;
            while (index < 1 || index > table.Count)
            {
                index = GettingInfo.GetNewInt("Enter item number");
            }
            table.DeleteLine(index);
            return table;
        }

        public static Table<string, int, Address> GetTableFromNewFile()
        {
            try
            {
                string str = GettingInfo.GetNewStr("Enter full file path");
                var table = JsonIteractor.JsonRead(str);
                return table;
            }
            catch
            {
                return null;
            }
            finally
            {
                Console.Clear();
            }
        }
        public static void SetPaginationFunction(ref Table<string, int, Address> table)
        {
            table.ItemsOnPage = GettingInfo.GetNewInt("pagination number");
            Console.Clear();
        }

        public static Table<string, int, Address> AddNewLineToListFunction(ref Table<string, int, Address> table)
        {
            table.AddNewLine(GettingInfo.GetNewLine());
            return table;
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
