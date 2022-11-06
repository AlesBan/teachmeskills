using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace async_breakfast.BreakfastEnv
{
    static class Breakfast
    {
        public static void WakeUp()
        {
            Console.WriteLine("Wake up");
        }
        public static void TurnOnTV()
        {
            Console.WriteLine("Turn on TV");
        }
        public static async Task MakeTea(CancellationTokenSource token)
        {
            Console.WriteLine($"Pour water in the kettle {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"Kettle on {Thread.CurrentThread.ManagedThreadId}");

            await Task.Delay(2000);

            Console.WriteLine("Put tea in the cup");

            Console.WriteLine($"Pour boiled water {Thread.CurrentThread.ManagedThreadId}");

            await Task.Delay(2000, token.Token);
            token.Cancel();
            Console.WriteLine($"Get tea from the cup {Thread.CurrentThread.ManagedThreadId}");
        }

        public static async Task<FriedEggs> FryEggs()
        {
            Console.WriteLine($"Put pan on fire {Thread.CurrentThread.ManagedThreadId}");

            await Task.Delay(3000);
             

            Console.WriteLine($"Pour oil on the pan {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"Put egg on pan {Thread.CurrentThread.ManagedThreadId}");

            await Task.Delay(3000);

            Console.WriteLine($"Get egg from pan {Thread.CurrentThread.ManagedThreadId}");
            return new FriedEggs();
        }
        public static void WashTheDishes()
        {
            Console.WriteLine("WashTheDishes");
        }

        public static async Task<Toast> FryToasts()
        {
            Console.WriteLine($"Put toast on toaster {Thread.CurrentThread.ManagedThreadId}");

            await Task.Delay(3000);
            Console.WriteLine($"Get egg from toaster {Thread.CurrentThread.ManagedThreadId}");
            return new Toast();
        }

        public static async Task MakeSandwich(FriedEggs eggs, Toast toast)
        {
            Console.WriteLine("Combine eggs and toast into sandwich");
        }
    }
}
