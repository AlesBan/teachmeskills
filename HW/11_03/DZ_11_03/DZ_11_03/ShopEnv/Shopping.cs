using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DZ_11_03.ShopEnv
{
    static class Shopping
    {
        public static void GoShoping()
        {
            Console.WriteLine("Our fridge is empty. Let\'s go shopping!");
            Thread.Sleep(2000);
        }
    }
}
