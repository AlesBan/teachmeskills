using async_breakfast.BreakfastEnv;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace async_breakfast
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            CancellationTokenSource cancellationToken = new CancellationTokenSource();
            CancellationToken token = cancellationToken.Token;

            cancellationToken.Cancel();
            Breakfast.WakeUp();
            Breakfast.TurnOnTV();
            Task MakeTeaTask = Breakfast.MakeTea(cancellationToken);
            Task<FriedEggs> FryEggsTask = Breakfast.FryEggs();
            Breakfast.WashTheDishes();
            Task<Toast> FryToasts = Breakfast.FryToasts();

            await MakeTeaTask;
            await Breakfast.MakeSandwich(await FryEggsTask, await FryToasts);
        }
    }
}
