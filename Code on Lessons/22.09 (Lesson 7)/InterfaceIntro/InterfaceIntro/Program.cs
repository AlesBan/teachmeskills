using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using InterfaceIntro.Shapes;
using Microsoft.VisualBasic.CompilerServices;

namespace InterfaceIntro
{
    class Program
    {
        protected Program()
        {

        }
        static void Main()
        {
            Printer printer = new Printer();
            UserInteraction.InteractionWithUser(printer);
        }
    }
}
