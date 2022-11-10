using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DZ_11_03_async.ShavingEnv
{
    static class Shaving
    {
        public static void ShavingFunc()
        {
            Console.WriteLine($"We are overgrown. Need to shave {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(1000);
        }
    }
}
