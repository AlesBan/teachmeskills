using InterfaceIntro.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceIntro
{
    static class ProgramHelpers
    {
        public static void Greeting()
        {
            Console.WriteLine("Hello! Chose one of these shapes to draw");
            Console.WriteLine("Write num of it");
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
        public static void PrintDefaultShapes(List<IPrintTable> printTables)
        {
            printTables.Add(new Square(8, 'h', (5, 5)));
            printTables.Add(new Rectangle(8, 8, 'r', (1, 2)));
            printTables.Add(new Circle(8, 't', (15, 15)));
            printTables.Add(new Text("ABOBABABA", (23, 10)));
            PrintAllShapes(printTables);
        }
        public static void PrintAllShapes(List<IPrintTable> printTables)
        {
            int bubbleHeight, maxHeight = default;
            foreach (IPrintTable printTable in printTables.Where(t => t != null))
            {
                ConsoleColor BorderColor = (ConsoleColor)(new Random()).Next(1, 15);
                Console.ForegroundColor = BorderColor;
                bubbleHeight = printTable.PrintAndReturnMaxHeight();
                maxHeight = bubbleHeight > maxHeight ? bubbleHeight : maxHeight;
                Console.ResetColor();
            }
            Console.CursorLeft = 0;
            Console.CursorTop = maxHeight + 4;
            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
            Console.Clear();
            Console.CursorLeft = 0;
            Console.CursorTop = 0;
        }
    }
}
