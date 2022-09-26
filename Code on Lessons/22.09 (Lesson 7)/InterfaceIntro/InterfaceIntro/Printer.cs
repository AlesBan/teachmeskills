using System;
using System.Collections.Generic;
using System.Text;
using InterfaceIntro.Shapes;

namespace InterfaceIntro
{
    static class Printer
    {
        public static void Print(Shape shape)
        {
            shape.Print();
        }

    }
}
