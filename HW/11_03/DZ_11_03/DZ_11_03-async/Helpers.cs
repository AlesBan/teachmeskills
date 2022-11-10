using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DZ_11_03_async
{
    static class Helpers
    {
        public static void CheckCanceling(CancellationToken token)
        {
            //if (token.IsCancellationRequested)
            //{
            //    token.ThrowIfCancellationRequested();
            //}
        }
    }
}
