using System;
using TableDataTypes.Delegats;
using TableDataTypes.Helpers;
using TableDataTypes.JsonIteraction;
using TableDataTypes.Person;
using System.Text.Json;

namespace TableDataTypes.Iteraction
{
    internal class IteractionWithUser
    {
        public static event Action<Table<string, int, Address>> MainMenuEvent = (table) => MainMenu(table);
        public static event Action<Table<string, int, Address>, int> TurnThePageEvent = (table, direction) =>
        TurnThePage(table, direction);
        
        protected IteractionWithUser()
        {

        }
        public static void Start()
        {
            JsonIteractor.JsonWrite(GettingInfo.PutDefaultLines());

            Table<string, int, Address> table = JsonIteractor.JsonRead();
            MainFunctions.OutPutFunc(table);
            OnMainMenuEvent(table);
        }
        public static void MainMenu(Table<string, int, Address> table)
        {
            int choice = default;
            IteractionMessages.WriteAvailableOptions();
            while (choice <= 0 && choice! <= Constants.AvaliableOptions.Length)
            {
                try
                {
                    int.TryParse(Console.ReadLine(), out choice);
                }
                catch
                {
                    IteractionMessages.WriteInvalideInput();
                }
            }
            HadlingWithChoice(choice - 1, ref table);
        }
        public static void HadlingWithChoice(int choiceIndex, ref Table<string, int, Address> table)
        {
            Console.Clear();
            string choice = Constants.AvaliableOptions[choiceIndex];
            switch (choice)
            {
                case "Add line":
                    MainFunctions.AddNewLineToListFunc(table);
                    OnMainMenuEvent(table);
                    break;
                case "OutPut":
                    MainFunctions.OutPutFunc(table);
                    OnMainMenuEvent(table);
                    break;
                case "Exit":
                    MainFunctions.ExitFunc();
                    break;
                case "Set pagination":
                    MainFunctions.SetPaginationFunc(table);
                    OnMainMenuEvent(table);
                    break;
                case "Next page":
                    OnTurnThePageEvent(ref table, 1);
                    break;
                case "Previous page":
                    OnTurnThePageEvent(ref table, -1);
                    break;
                case "Go to":
                    OnTurnThePageEvent(ref table, 0);
                    break;
                case "Read new file":

                    break;
            }
        }
        public static void TurnThePage(Table<string, int, Address> table, int direction)
        {
            if (direction == 1 && table.CurrentPage != table.Pages.Count)
            {
                table.CurrentPage++;
            }
            else if (direction == -1 && table.CurrentPage != 1)
            {
                table.CurrentPage--;
            }
            else if (direction == 0)
            {
                table.CurrentPage = GettingInfo.GetPageNumber(table);
            }
            Console.Clear();
            MainFunctions.OutPutFunc(table);
            OnMainMenuEvent(table);
        }
        public static void OnMainMenuEvent(Table<string, int, Address> table)
        {
            JsonIteractor.JsonWrite(table);
            MainMenuEvent?.Invoke(table);
        }
        public static void OnTurnThePageEvent(ref Table<string, int, Address> table, int direction)
        {
            TurnThePageEvent?.Invoke(table, direction);
        }
    }
}
