using System;
using System.Collections.Generic;
using InterfaceIntro.Shapes;

namespace InterfaceIntro
{
    class Program
    {
        protected Program()
        {

        }
        static void Main()
        {
            List<IPrintTable> printTables = new List<IPrintTable>();
            (int,int) CursorDefaultIndexes = (0,0);
            Console.WriteLine("Hello! Chose one of these shapes to draw");
            Console.WriteLine("Write num of it");

            string choise = Interaction.GetChoice();
            while (choise != "Exit")
            {
                switch (choise)
                {
                    case "Circle":
                        printTables.Add(GetShapeValues.GetNewCircle());
                        CursorDefaultIndexes = (Console.CursorLeft, Console.CursorTop);
                        break;
                    case "Square":
                        printTables.Add(GetShapeValues.GetNewSquare());
                        CursorDefaultIndexes = (Console.CursorLeft, Console.CursorTop);
                        break;
                    case "Rectangle":
                        printTables.Add(GetShapeValues.GetNewRectangle());
                        CursorDefaultIndexes = (Console.CursorLeft, Console.CursorTop);
                        break;
                    case "Text":
                        printTables.Add(GetShapeValues.GetNewText());
                        CursorDefaultIndexes = (Console.CursorLeft, Console.CursorTop);
                        break;
                    case "OutPut":
                        PrintAllShapes(printTables, CursorDefaultIndexes);
                        break;
                    case"Default":
                        PrintDefaultShapes(printTables, CursorDefaultIndexes);
                        break; 
                }
                choise = Interaction.GetChoice();
            }
        }
        public static void PrintDefaultShapes(List<IPrintTable> printTables, (int, int) CursorIndexes)
        {
            printTables.Add(new Square(8, 'h', (5, 5)));
            printTables.Add(new Rectangle(8, 8, 'r', (1, 2)));
            printTables.Add(new Circle(8, 't', (15, 15)));
            printTables.Add(new Text("ABOBABABA", (23, 10)));
            PrintAllShapes(printTables, CursorIndexes);
        }
        public static void PrintAllShapes(List<IPrintTable> printTables, (int, int) CursorIndexes)
        {
            var (left, top) = CursorIndexes;
            int i = 0;

            foreach (IPrintTable printTable in printTables)
            {
                i++;
                ConsoleColor BorderColor = (ConsoleColor)(new Random()).Next(0, 15);
                Console.ForegroundColor = BorderColor;
                printTable.Print();
                Console.CursorLeft = left;
                Console.CursorTop = top;
                Console.ResetColor();
            }
            Console.CursorLeft = left;
            Console.CursorTop = top+50;
        }
    }
}
