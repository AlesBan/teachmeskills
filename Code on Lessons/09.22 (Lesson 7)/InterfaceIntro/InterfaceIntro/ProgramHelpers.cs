using InterfaceIntro.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace InterfaceIntro
{
    static class ProgramHelpers
    {
        public static readonly ConsoleColor[] colors = (ConsoleColor[])Enum.GetValues(typeof(ConsoleColor));
        public static event Action<IPrintTable> HistoryAdd = (printTable) => History.AddInHistory(printTable);

        public static void Greeting(Action<string> printAction)
        {
            printAction("Hello! Chose one of these shapes to draw");
            printAction("Write num of it");
        }

        public static List<string> GetAllChoices(IEnumerable<Type> ShapeClasses)
        {
            List<string> AvailableOptions = new List<string>();
            foreach (Type type in ShapeClasses)
            {
                AvailableOptions.Add(type.Name);
            }
            foreach (string str in Interaction.additionalyChoices)
            {
                AvailableOptions.Add(str);
            }
            return AvailableOptions;
        }

        public static void PrintAllShapes(PrinterConsole printer)
        {
            int bubbleHeight, maxHeight = default;
            foreach (IPrintTable printTable in Interaction.printTables.Where(t => t != null))
            {
                bubbleHeight = printTable.PrintAndReturnMaxHeight(printer);
                OnHistotyAddEvent(printTable);
                maxHeight = bubbleHeight > maxHeight ? bubbleHeight : maxHeight;
                Console.ResetColor();
            }

            printer.SetCursorLeft(0);
            printer.SetCursorTop(maxHeight + 4);
            printer.WriteLine("Press Enter to continue.");
            printer.ReadLine();
            printer.Clear();
            printer.SetCursorLeft(0);
            printer.SetCursorTop(0);
        }
        public static void OnHistotyAddEvent(IPrintTable printTable)
        {
            HistoryAdd?.Invoke(printTable);
        }
    }
}
