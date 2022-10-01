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
        public Action<string> ActionAn = (str) => Console.WriteLine(str);
        static void Main()
        {
            List <IPrintTable> printTables = new List<IPrintTable>();
            List<string> AvailableOptions = ProgramHelpers.GetAllChoices(ReflectionClass.GetClasses());

            ProgramHelpers.Greeting((str) => Console.WriteLine(str));

            int choiseIndex = Interaction.GetChoice(AvailableOptions);
            Console.Clear();
            Console.WriteLine($"{AvailableOptions[choiseIndex]}:");
            while (choiseIndex != AvailableOptions.IndexOf("Exit"))
            {
                if (AvailableOptions[choiseIndex] == "OutPut")
                {
                    Console.Clear();
                    ProgramHelpers.PrintAllShapes(printTables);
                }
                else if (AvailableOptions[choiseIndex] == "Default")
                {
                    Console.Clear();
                    ProgramHelpers.PrintDefaultShapes(printTables);
                }
                else
                {
                    printTables.Add(GetShapeValues.GetNewShape(AvailableOptions[choiseIndex]));
                }
                choiseIndex = Interaction.GetChoice(AvailableOptions);
                Console.Clear();
                Console.WriteLine($"{AvailableOptions[choiseIndex]}:");
            }
        }
    }
}
