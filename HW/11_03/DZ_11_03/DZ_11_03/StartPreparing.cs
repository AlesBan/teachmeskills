using System;
using System.Collections.Generic;
using System.Text;
using DZ_11_03.CallingEnv;
using DZ_11_03.CleaningEnv;
using DZ_11_03.DinnerEnv;
using DZ_11_03.ShavingEnv;
using DZ_11_03.ShopEnv;

namespace DZ_11_03
{
    static class StartPreparing
    {
        public static void Start()
        {
            Callings.GuestsInviting();
            Shopping.GoShoping();
            Dinner.MakeDinner();
            Callings.GrannyCalling();
            Cleaning.MakeHouseClean();
            Shaving.ShavingFunc();

            Console.WriteLine("We are ready!!!");
        }

    }
}
