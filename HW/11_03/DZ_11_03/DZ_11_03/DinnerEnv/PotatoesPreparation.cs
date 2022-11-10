using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DZ_11_03.DinnerEnv
{
    static class PotatoesPreparation
    {
        public static void Peeling()
        {
            Console.WriteLine("Peeling popatoes");
            Thread.Sleep(3000);
        }
        public static void Washing()
        {
            Console.WriteLine("Washing popatoes");
            Thread.Sleep(100);
        }
        public static void Boiling()
        {
            Console.WriteLine("Boiling popatoes");
            Thread.Sleep(2000);
        }
    }
}
