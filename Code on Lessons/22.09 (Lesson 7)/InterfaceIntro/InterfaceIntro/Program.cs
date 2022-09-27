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
                    GetShapeValues.GetNewCircle().Print();
                    break;
                case "Square":
                    GetShapeValues.GetNewSquare().Print();
                    break;
                case "Rectangle":
                    GetShapeValues.GetNewRectangle().Print();
                    break;
                case "Text":
                    GetShapeValues.GetNewText().Print();
                    break;
            }
        }
    }
}
