using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DZ_11_03.DinnerEnv
{
    static class MeatPreparation
    {
        public static void Defrosting()
        {
            Console.WriteLine("Put the meat on defrosting");
            Thread.Sleep(3000);
        }
        public static void PutPanOnFire()
        {
            Console.WriteLine("Put pan on fire");
            Thread.Sleep(1000);
            Console.WriteLine("Pan is ready");
        }
        public static void Preparing()
        {
            Console.WriteLine("Preparing meat for frying");
            Thread.Sleep(500);
        }
        public static void Frying()
        {
            Console.WriteLine("Frying meat");
            Thread.Sleep(2000);
            Console.WriteLine("Meat is ready");
        }

    }
}
