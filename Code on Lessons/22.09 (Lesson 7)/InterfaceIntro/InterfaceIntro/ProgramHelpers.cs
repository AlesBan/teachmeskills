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
            Assembly asmbly = Assembly.GetExecutingAssembly();
            List<Type> typeList = asmbly.GetTypes().Where(t => t.GetInterface("IPrintable") != null).ToList();
            int bubbleHeight, maxHeight = default;
            foreach (IPrintTable printTable in printTables.Where(t => t != null))
            {
                ConsoleColor BorderColor = ConsoleColor.Blue;
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
