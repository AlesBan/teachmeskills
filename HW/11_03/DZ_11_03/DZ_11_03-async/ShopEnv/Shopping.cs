using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DZ_11_03_async.ShopEnv
{
    static class Shopping
    {
        public static void GoShoping()
        {
            Console.WriteLine($"Our fridge is empty. Let\'s go shopping! {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(2000);
            Console.WriteLine($"Back home {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
