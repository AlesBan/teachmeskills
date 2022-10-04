using InterfaceIntro.Delegats;
using InterfaceIntro.Shapes;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceIntro
{
    class Interaction
    {
        protected Interaction()
        {

        }
        public static readonly ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));
        public static readonly string[] Shapes = new string[] { "Circle", "Square", "Rectangle", "Text" };
        public const string ConclusionChoise = "OutPut";
        public const string Exit = "Exit";
        public static readonly string[] additionalyChoices = new string[] { "OutPut", "Exit" };
        public static readonly string[] AllChoices = new string[] { "Circle", "Square", "Rectangle", "Text", "OutPut", "Exit", "Default" };
        public static readonly List<IPrintTable> printTables = new List<IPrintTable>();

        public static void WriteAllAvailableShapes(List<string> AvailableOptions, Action<string> WriteLine)
        {
            for (int i = 1; i <= AvailableOptions.Count; i++)
            {
                WriteLine($"{i}) {AvailableOptions[i - 1]}");
            }
        }
        public static void MainMenu(List<string> AvailableOptions, Printer printer, MainFunctions mainFunctions)
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
            HadlingWithChoice(choice - 1,AvailableOptions, printer, mainFunctions);            
        }
        public static void HadlingWithChoice(int choiceIndex, List<string> AvailableOptions, Printer printer, MainFunctions mainFunctions)
        {
            printer.Clear();
            string choice = AvailableOptions[choiceIndex];
            if (choice == "OutPut")
            {
                ProgramHelpers.PrintAllShapes(printer);
                mainFunctions.MainMenuFunc(AvailableOptions, printer, mainFunctions);
            }
            else if (choice == "Exit")
            {
                mainFunctions.ExitFunc();
            }
            else
            {
                printTables.Add(GetShapeValues.GetNewShape(AvailableOptions[choiceIndex], printer));
                mainFunctions.MainMenuFunc(AvailableOptions, printer, mainFunctions);
            }
        }
        public static void GetAllOptions(Printer printer, MainFunctions mainFunctions)
        {
            List<string> AvailableOptions = ProgramHelpers.GetAllChoices(ReflectionClass.GetClasses(printer.WriteLine));
            MainMenu(AvailableOptions, printer, mainFunctions);
        }
    }
}
