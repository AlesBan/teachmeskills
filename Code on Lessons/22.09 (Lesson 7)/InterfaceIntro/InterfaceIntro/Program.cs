using System;
using InterfaceIntro.Shapes;

namespace InterfaceIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            //Printer.Print(new Square(7,'*', (5,8)));
            Printer.Print(new Circle(7,'*',(5,5)));

        }
    }
}
