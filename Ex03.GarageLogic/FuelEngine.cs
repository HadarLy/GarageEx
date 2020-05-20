using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class FuelEngine : Engine
    {
        public enum eFuelType
        {
            Octan95 = 1,
            Octan96,
            Octan98,
            Soler
        }

        private readonly eFuelType r_TheFuelType;

        public FuelEngine(eFuelType i_FuelType, float i_CurrentAmountOfFuel, float i_PercentOfEnergyLeft, float i_MaximumAmountOfEnergy) : base(i_PercentOfEnergyLeft, i_MaximumAmountOfEnergy, i_CurrentAmountOfFuel)
        {
            r_TheFuelType = i_FuelType;
        }

        public eFuelType TheFuelType
        {
            get { return r_TheFuelType; }
        }

        public void Refuel(float i_AmountOfEnergyToFill, int i_FuelType)
        {
            AddEnergy(i_AmountOfEnergyToFill);
        }

        public string GetFuelTypeInString()
        {
            string vehicleFuelTypeString = string.Empty;

            switch (r_TheFuelType)
            {
                case eFuelType.Octan95:
                    vehicleFuelTypeString = "Octan95";
                    break;
                case eFuelType.Octan96:
                    vehicleFuelTypeString = "Octan96";
                    break;
                case eFuelType.Octan98:
                    vehicleFuelTypeString = "Octan98";
                    break;
                case eFuelType.Soler:
                    vehicleFuelTypeString = "Soler";
                    break;
            }

            return vehicleFuelTypeString;
        }
    }
}
