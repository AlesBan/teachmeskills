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
        public static readonly string[] additionalyChoices = new string[] { "OutPut", "Exit", "Default" };
        public static readonly string[] AllChoices = new string[] { "Circle", "Square", "Rectangle", "Text", "OutPut", "Exit", "Default" };
        public static void WriteAllAvailableShapes(List<string> AvailableOptions)
        {
            for (int i = 1; i <= AvailableOptions.Count; i++)
            {
                Console.WriteLine($"{i}) {AvailableOptions[i - 1]}");
            }
        }
        public static int GetChoice(List<string> AvailableOptions)
        {
            WriteAllAvailableShapes(AvailableOptions);
            int.TryParse(Console.ReadLine(), out int choise);
            if (choise > 0 && choise <= AvailableOptions.Count)
            {
                return choise - 1;
            }
            else
            {
                Console.WriteLine("Input is invalid\nTry again");
                return GetChoice(AvailableOptions);
            }
        }
    }
}
