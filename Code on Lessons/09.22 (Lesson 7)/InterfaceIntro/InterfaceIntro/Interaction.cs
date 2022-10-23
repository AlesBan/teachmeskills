using InterfaceIntro.Delegats;
using InterfaceIntro.Shapes;
using System;
using System.Collections.Generic;

namespace InterfaceIntro
{
    public class Interaction
    {
        protected Interaction()
        {

        }
        public static readonly ConsoleColor[] colors = (ConsoleColor[])Enum.GetValues(typeof(ConsoleColor));
        public const string ConclusionChoise = "OutPut";
        public const string Exit = "Exit";
        public static readonly string[] additionalyChoices = new string[] { "OutPut", "Exit", "History" };
        public static readonly string[] AllChoices = new string[] { "Circle", "Square", "Rectangle", "Text", "OutPut", "Exit", "Default" };
        public static readonly List<IPrintTable> printTables = new List<IPrintTable>();

        public static event Action<List<string>, PrinterConsole, MainFunctions> MenuEvent = (AvailableOptions, printer, mainFunctions) =>
            MainMenu(AvailableOptions, printer, mainFunctions);
        public static readonly Action<PrinterConsole> PrintAllHistory = (printerConsole) => History.ShowAllHistoty(printerConsole);


        public static void WriteAllAvailableShapes(List<string> AvailableOptions, Action<string> WriteLine)
        {
            for (int i = 1; i <= AvailableOptions.Count; i++)
            {
                WriteLine($"{i}) {AvailableOptions[i - 1]}");
            }
        }

        public static void MainMenu(List<string> AvailableOptions, PrinterConsole printer, MainFunctions mainFunctions)
        {
            WriteAllAvailableShapes(AvailableOptions, printer.WriteLine);
            int choice = default;
            while (choice <= 0 && choice! <= AvailableOptions.Count)
            {
                try
                {
                    int.TryParse(Console.ReadLine(), out choice);
                }
                catch
                {
                    printer.WriteLine("Input is invalid\nTry again");
                }
            }
            HadlingWithChoice(choice - 1, AvailableOptions, printer, mainFunctions);
        }

        public static void HadlingWithChoice(int choiceIndex, List<string> AvailableOptions, PrinterConsole printer, MainFunctions mainFunctions)
        {
            printer.Clear();
            string choice = AvailableOptions[choiceIndex];
            if (choice == "OutPut")
            {
                ProgramHelpers.PrintAllShapes(printer);
                OnMenuEvent(AvailableOptions, printer, mainFunctions);
            }
            else if (choice == "Exit")
            {
                mainFunctions.ExitFunc();
            }
            else if (choice == "History")
            {
                PrintAllHistory(printer);
            }
            else
            {
                var newShape = GetShapeValues.GetNewShape(AvailableOptions[choiceIndex], printer);
                printTables.Add(newShape);
                OnMenuEvent(AvailableOptions, printer, mainFunctions);
            }
        }

        public static void GetAllOptions(PrinterConsole printer, MainFunctions mainFunctions)
        {
            List<string> AvailableOptions = ProgramHelpers.GetAllChoices(ReflectionClass.GetClasses(printer.WriteLine));
            MainMenu(AvailableOptions, printer, mainFunctions);
        }

        public static void OnMenuEvent(List<string> AvailableOptions, PrinterConsole printer, MainFunctions mainFunctions)
        {
            MenuEvent?.Invoke(AvailableOptions, printer, mainFunctions);
        }
    }
}
