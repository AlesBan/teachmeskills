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
        public static void WriteAllAvailableShapes()
        {
            for (int i = 1; i <= Shapes.Length; i++)
            {
                Console.WriteLine($"{i}) {Shapes[i - 1]}");
            }
        }
        public static string GetChoice()
        {
            WriteAllAvailableShapes();
            int.TryParse(Console.ReadLine(), out int choise);
            if (choise > 0 && choise <= Shapes.Length)
            {
                return Shapes[choise - 1];
            }
            else
            {
                Console.WriteLine("Input is invalid\nTry again");

                return GetChoice();
            }
        }
    }
}
