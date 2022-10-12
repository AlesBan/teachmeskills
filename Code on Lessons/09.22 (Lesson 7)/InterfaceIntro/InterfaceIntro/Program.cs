using InterfaceIntro.Delegats;

namespace InterfaceIntro
{
    class Program
    {
        protected Program()
        {

        }
        static void Main()
        {
            PrinterConsole printer = new PrinterConsole();
            MainFunctions mainFunctions = new MainFunctions();
            ProgramHelpers.Greeting(printer.WriteLine);
            Interaction.GetAllOptions(printer, mainFunctions);
            Interaction.MenuEvent += Interaction.MainMenu;
        }
    }
}
