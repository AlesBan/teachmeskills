using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace DZ_11_03_async
{
    class Program
    {
        protected Program()
        {
        }

        public static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            StartPreparing start = new StartPreparing();
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;

            Task.Run(() =>
            {
                Console.WriteLine("Press 'c' to cancel");
                if (Console.ReadKey(true).KeyChar == 'c')
                    cts.Cancel();
            });

            Thread.Sleep(1000);

            Task task = Task.Run(() => start.Start(token), token);

            try
            {
                task.Wait(token);
            }
            catch (OperationCanceledException e)
            {
                if (e.CancellationToken == token)
                    Console.WriteLine("Canceled from UI thread throwing OCE.");
            }
            catch (AggregateException ae)
            {
                Console.WriteLine("AggregateException caught: " + ae.InnerException);
                foreach (var inner in ae.InnerExceptions)
                {
                    Console.WriteLine(inner.Message + inner.Source);
                }
            }

            StopProgram(stopWatch);
        }

        public static void StopProgram(Stopwatch stopWatch)
        {
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;

            string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime: " + elapsedTime);
        }
    }
}
