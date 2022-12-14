using System;
using System.Collections.Generic;
using System.Text;

namespace DZ_11_03.DinnerEnv
{
    static class Dinner
    {
        public static void MakeDinner()
        {
            MeatPreparation.Defrosting();
            MeatPreparation.PutPanOnFire();
            MeatPreparation.Preparing();
            MeatPreparation.Frying();

            PotatoesPreparation.Peeling();
            PotatoesPreparation.Washing();
            PotatoesPreparation.Boiling();

            SaladPreparation.WashingVegetables();
            SaladPreparation.CutVegetables();
            SaladPreparation.DressTheSalad();
        }
    }
}
