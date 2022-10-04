using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using InterfaceIntro.Delegats;
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
            MainFunctions mainFunctions = new MainFunctions();
            ProgramHelpers.Greeting(printer.WriteLine);
            Interaction.GetAllOptions(printer, mainFunctions);
        }
    }
}
