using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DZ_11_03_async.CallingEnv;
using DZ_11_03_async.CleaningEnv;
using DZ_11_03_async.DinnerEnv;
using DZ_11_03_async.ShavingEnv;
using DZ_11_03_async.ShopEnv;

namespace DZ_11_03_async
{
    internal class StartPreparing
    {
        readonly CancellationTokenSource internalTokenSource = new CancellationTokenSource();

        public async Task Start(CancellationToken externalToken)
        {
            CancellationToken internalToken = internalTokenSource.Token;

            using CancellationTokenSource linkedCts =
                    CancellationTokenSource.CreateLinkedTokenSource(internalToken, externalToken);
            try
            {
                Callings.GuestsInviting();
                Shopping.GoShoping();
                Dinner dinner = new Dinner();
                Task MakeDinnerTask = dinner.MakeDinner(linkedCts.Token);
                Callings.GrannyCalling();
                Cleaning.MakeHouseClean();
                Shaving.ShavingFunc();
                await MakeDinnerTask;
            }
            catch
            {
                Cancelling(externalToken);
            }
            Console.WriteLine($"We are ready!!! {Thread.CurrentThread.ManagedThreadId}");
        }

        public static void Cancelling(CancellationToken externalToken)
        {
            Console.WriteLine("Cancelling per user request.");
            externalToken.ThrowIfCancellationRequested();
        }
    }
}
