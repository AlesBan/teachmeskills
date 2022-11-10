using System;
using System.Threading;

namespace DZ_11_03_async.CallingEnv
{
    static class Callings
    {
        public static void GuestsInviting()
        {
            Console.WriteLine($"Invite guests {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(500);
        }

        public static void GrannyCalling()
        {
            Console.WriteLine($"My granny is calling {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(1500);
        }
    }
}
