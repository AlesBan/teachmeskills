using DZ_11_03_async.DinnerEnv.Food;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DZ_11_03_async.DinnerEnv
{
    static class PotatoesPreparation
    {
        public static BoiledPotatoes Peeling()
        {
            Console.WriteLine($"Peeling popatoes {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(3000);
            Console.WriteLine($"Popatoes are peeled {Thread.CurrentThread.ManagedThreadId}");
            return new BoiledPotatoes();
        }

        public static BoiledPotatoes Washing(BoiledPotatoes boiledPotatoes)
        {
            Console.WriteLine($"Washing popatoes {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(100);
            Console.WriteLine($"Popatoes are washed {Thread.CurrentThread.ManagedThreadId}");
            return boiledPotatoes;
        }

        public static async Task<BoiledPotatoes> Boiling(BoiledPotatoes boiledPotatoes)
        {
            Console.WriteLine($"Start boiling water {Thread.CurrentThread.ManagedThreadId}");
            await Task.Delay(2000);
            Console.WriteLine($"Water is boiled {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"Toss potatoes in boiled water {Thread.CurrentThread.ManagedThreadId}");
            await Task.Delay(2000);
            return boiledPotatoes;
        }
    }
}
