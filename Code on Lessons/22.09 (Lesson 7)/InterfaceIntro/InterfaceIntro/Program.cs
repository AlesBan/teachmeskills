using System;
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
            ConsoleColor BorderColor = ConsoleColor.Yellow;
            Console.ForegroundColor = BorderColor;
            Console.WriteLine("Hello! Chose one of these shapes to draw");
            Console.WriteLine("Write num of it");

            string choise = Interaction.GetChoice();
            switch (choise)
            {
                case "Circle":
                    Printer.Print(GetShapeValues.GetNewCircle());
                    break;
                case "Square":
                    Printer.Print(GetShapeValues.GetNewSquare());
                    break;
                case "Rectangle":
                    Printer.Print(GetShapeValues.GetNewRectangle());
                    break;
            }
        }
    }
}
