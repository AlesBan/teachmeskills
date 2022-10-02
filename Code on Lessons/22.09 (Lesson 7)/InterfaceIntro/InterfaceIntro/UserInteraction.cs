using InterfaceIntro.Shapes;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceIntro
{
    public class UserInteraction
    {
        protected UserInteraction()
        {

        }
        public static void InteractionWithUser(Printer printer)
        {
            List<IPrintTable> printTables = new List<IPrintTable>();
            List<string> AvailableOptions = ProgramHelpers.GetAllChoices(ReflectionClass.GetClasses(printer.WriteLine));

            ProgramHelpers.Greeting(printer.WriteLine);

            int choiseIndex = Interaction.GetChoice(AvailableOptions, printer.WriteLine);
            printer.Clear();
            printer.WriteLine($"{AvailableOptions[choiseIndex]}:");
            while (choiseIndex != AvailableOptions.IndexOf("Exit"))
            {
                if (AvailableOptions[choiseIndex] == "OutPut")
                {
                    printer.Clear();
                    ProgramHelpers.PrintAllShapes(printTables, printer);
                }
                else if (AvailableOptions[choiseIndex] == "Default")
                {
                    printer.Clear();
                    ProgramHelpers.PrintDefaultShapes(printTables, printer);
                }
                else
                {
                    printTables.Add(GetShapeValues.GetNewShape(AvailableOptions[choiseIndex], printer));
                }
                choiseIndex = Interaction.GetChoice(AvailableOptions, printer.WriteLine);
                printer.Clear();
                printer.WriteLine($"{AvailableOptions[choiseIndex]}:");
            }
        }
    }
}
