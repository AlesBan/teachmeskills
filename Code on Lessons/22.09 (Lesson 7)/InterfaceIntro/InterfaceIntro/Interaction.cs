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
        public static readonly string[] Shapes = new string[] { "Circle", "Square", "Rectangle", "Text" };
        public const string ConclusionChoise = "OutPut";
        public const string Exit = "Exit";

        public static readonly string[] AllChoices = new string[] { "Circle", "Square", "Rectangle", "Text", "OutPut", "Exit", "Default" };
        public static void WriteAllAvailableShapes()
        {
            for (int i = 1; i <= AllChoices.Length; i++)
            {
                Console.WriteLine($"{i}) {AllChoices[i - 1]}");
            }
        }
        public static string GetChoice()
        {
            WriteAllAvailableShapes();
            int.TryParse(Console.ReadLine(), out int choise);
            if (choise > 0 && choise <= AllChoices.Length)
            {
                return AllChoices[choise - 1];
            }
            else
            {
                Console.WriteLine("Input is invalid\nTry again");
                return GetChoice();
            }
        }
    }
}
