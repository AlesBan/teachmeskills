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
            Console.ForegroundColor = ConsoleColor.Yellow;
            List <IPrintTable> printTables = new List<IPrintTable>();
            IEnumerable<Type> ShapeClasses = ReflectionClass.GetClasses();
            List<string> AvailableOptions = ProgramHelpers.GetAllChoices(ShapeClasses);

            ProgramHelpers.Greeting();

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
                printTables.Add(GetShapeValues.GetNewShape(AvailableOptions[choiseIndex]));
                choiseIndex = Interaction.GetChoice(AvailableOptions);
                Console.Clear();
                Console.WriteLine($"{AvailableOptions[choiseIndex]}:");
            }
        }
    }
}
