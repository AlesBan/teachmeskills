using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DZ_11_03.CleaningEnv
{
    static class Cleaning
    {
        public static void MakeHouseClean()
        {
            WindowsCleaning();
            Sweeping();
            FloorCleaning();
            WashingDishes();
        }
        public static void WindowsCleaning()
        {
            Console.WriteLine("Cleaning windows");
            Thread.Sleep(1000);
        }
        public static void WashingDishes()
        {
            Console.WriteLine("Washing dishes");
            Thread.Sleep(1000);
        }
        public static void Sweeping()
        {
            Console.WriteLine("Sweeping floor");
            Thread.Sleep(1000);
        }
        public static void FloorCleaning()
        {
            Console.WriteLine("Сlean the floor");
            Thread.Sleep(1000);
        }
    }
}
