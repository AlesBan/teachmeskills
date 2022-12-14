using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DZ_11_03.CallingEnv
{
    static class Callings
    {
        public static void GuestsInviting()
        {
            Console.WriteLine("Invite guests");
            Thread.Sleep(500);
        }
        public static void GrannyCalling()
        {
            Console.WriteLine("My granny is calling");
            Thread.Sleep(1500);
        }
    }
}
