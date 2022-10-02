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
        public static readonly ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));
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
        public static void PrintDefaultShapes(List<IPrintTable> printTables, Printer printer)
        {
            printTables.Add(new Square(8, 'h', (5, 5)));
            printTables.Add(new Rectangle(8, 8, 'r', (1, 2)));
            printTables.Add(new Circle(8, 't', (15, 15)));
            printTables.Add(new Text("ABOBABABA", (23, 10)));
            PrintAllShapes(printTables, printer);
        }

        public static void PrintAllShapes(List<IPrintTable> printTables, Printer printer)
        {
            int bubbleHeight, maxHeight = default;
            foreach (IPrintTable printTable in printTables.Where(t => t != null))
            {
                bubbleHeight = printTable.PrintAndReturnMaxHeight(printer);
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
    }
}
