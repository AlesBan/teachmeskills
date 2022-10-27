using System;
using TableDataTypes.Iteraction;

namespace TableDataTypes
{
    class Program
    {
        protected Program()
        {

        }
        static void Main(string[] args)
        {
            IteractionWithUser.MainMenuEvent += IteractionWithUser.MainMenu;
            IteractionWithUser.TurnThePageEvent += IteractionWithUser.TurnThePage;
            IteractionWithUser.Start();
        }
    }
}
