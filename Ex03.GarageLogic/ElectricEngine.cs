using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {
        public ElectricEngine(float i_TimeLeftInBattery, float i_PercentOfEnergyLeft, float i_MaximumAmountOfEnergy) : base(i_PercentOfEnergyLeft, i_MaximumAmountOfEnergy, i_TimeLeftInBattery)
        {
        }

        public void ChargeBattery(float i_AmountOfEnergyToFill)
        {
            AddEnergy(i_AmountOfEnergyToFill);
        }
    }
}
