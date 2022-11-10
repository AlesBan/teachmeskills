using DZ_11_03_async.DinnerEnv.Food;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DZ_11_03_async.DinnerEnv
{
    class Dinner
    {
        public async Task MakeDinner(CancellationToken externalToken)
        {
            Task<FriedMeat> FryMeatTask = FryMeat(externalToken);
            Task<BoiledPotatoes> BoilPotatoesTask = BoilPotatoes(externalToken);

            List<Task> dinnerTasks = new List<Task>
                {
                FryMeatTask, BoilPotatoesTask
                };

            await DinnerReadiness(dinnerTasks, externalToken);
        }

        public async Task DinnerReadiness(List<Task> dinnerTasks, CancellationToken externalToken)
        {
            while (dinnerTasks.Count > 0)
            {
                Task finishedTask = await Task.WhenAny(dinnerTasks);
                if (finishedTask.ToString().Contains("FryMeat"))
                {
                    Console.WriteLine($"Meat is ready! {Thread.CurrentThread.ManagedThreadId}");

                }
                else if (finishedTask.ToString().Contains("BoilPotatoes"))
                {
                    Console.WriteLine($"Potatoes are ready! {Thread.CurrentThread.ManagedThreadId}");
                }
                dinnerTasks.Remove(finishedTask);
            }
            MakeSalad(externalToken);
            Console.WriteLine($"Dinner is ready {Thread.CurrentThread.ManagedThreadId}");
        }

        public async Task<FriedMeat> FryMeat(CancellationToken externalToken)
        {

            Task<FriedMeat> DefrostingMeatTask = MeatPreparation.Defrosting();
            Task PutPanOnFireTask = MeatPreparation.PutPanOnFire();

            await PutPanOnFireTask;

            return await MeatPreparation.Frying(MeatPreparation.Preparing(await DefrostingMeatTask));
        }

        public async Task<BoiledPotatoes> BoilPotatoes(CancellationToken externalToken)
        {
            Task<BoiledPotatoes> BoilingTask = PotatoesPreparation.Boiling(PotatoesPreparation.Washing(PotatoesPreparation.Peeling()));
            return await BoilingTask;
        }

        public Salad MakeSalad(CancellationToken externalToken)
        {
            SaladPreparation.WashingVegetables();
            SaladPreparation.CutVegetables();
            SaladPreparation.DressTheSalad();
            return new Salad();
        }
    }
}
