using DZ_11_03_async.DinnerEnv.Food;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DZ_11_03_async.DinnerEnv
{
    static class MeatPreparation
    {
        public static async Task<FriedMeat> Defrosting()
        {
            Console.WriteLine($"Put the meat on defrosting {Thread.CurrentThread.ManagedThreadId}");
            await Task.Delay(2500);
            Console.WriteLine($"Meat is defrosted {Thread.CurrentThread.ManagedThreadId}");
            return new FriedMeat();
        }

        public static async Task PutPanOnFire()
        {
            Console.WriteLine($"Put pan on fire {Thread.CurrentThread.ManagedThreadId}");
            await Task.Delay(1000);
            Console.WriteLine($"Pan is ready {Thread.CurrentThread.ManagedThreadId}");
        }

        public static FriedMeat Preparing(FriedMeat friedMeat)
        {
            Console.WriteLine($"Preparing meat for frying {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(500);
            return friedMeat;
        }

        public static async Task<FriedMeat> Frying(FriedMeat friedMeat)
        {
            Console.WriteLine($"Frying meat {Thread.CurrentThread.ManagedThreadId}");
            await Task.Delay(2000);
            return friedMeat;
        }

    }
}
