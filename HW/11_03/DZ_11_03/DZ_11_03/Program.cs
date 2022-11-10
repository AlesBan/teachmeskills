using System;
using System.Diagnostics;
using System.Threading;

namespace DZ_11_03
{
    class Program
    {
        protected Program()
        {

        }
        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            StartPreparing.Start();
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;

            string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime: " + elapsedTime);
        }
    }
}
