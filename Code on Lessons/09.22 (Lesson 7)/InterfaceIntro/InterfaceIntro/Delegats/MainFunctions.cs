using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceIntro.Delegats
{
    public class MainFunctions
    {
        public readonly Action<List<IPrintTable>, PrinterConsole> OutPutFunc = (printTables, printer) => OutPutFunction(printTables, printer);
        public readonly Action ExitFunc = () => ExitFunction();
        public readonly Action<List<IPrintTable>, List<string>, int, PrinterConsole> AddShapeToListFunc = (printTables, AvailableOptions, choiceIndex, printer) =>
        AddShapeToList(ref printTables, AvailableOptions, choiceIndex, printer);

       

        public static void AddShapeToList(ref List<IPrintTable> printTables, List<string> AvailableOptions, int choiceIndex, PrinterConsole printer)
        {
            printTables.Add(GetShapeValues.GetNewShape(AvailableOptions[choiceIndex], printer));
        }
        public static void OutPutFunction(List<IPrintTable> printTables, PrinterConsole printer)
        {
            printer.Clear();
            ProgramHelpers.PrintAllShapes(printer);
        }
        public static void ExitFunction()
        {
            Environment.Exit(0);
        }
    }
}
