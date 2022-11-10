using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DZ_11_03_async.DinnerEnv
{
    static class SaladPreparation
    {
        public static void WashingVegetables()
        {
            Console.WriteLine($"Washing vegetables {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(500);
        }

        public static void CutVegetables()
        {
            Console.WriteLine($"Cut vegetables {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(1500);
        }

        public static void DressTheSalad()
        {
            Console.WriteLine($"Dressing the salad {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(500);
            Console.WriteLine($"Salade is ready {Thread.CurrentThread.ManagedThreadId}");
        }

    }
}
