using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        public enum eEngineType
        {
            Fuel = 1,
            Electric = 2
        }

        private readonly float r_MaximumAmountOfEnergy;
        private float m_CurrentAmountOfEnergy;
        private float m_PercentOfEnergyLeft;

        public Engine(float i_PercentOfEnergyLeft, float i_MaximumAmountOfEnergy, float i_CurrentAmountOfEnergy)
        {
            m_PercentOfEnergyLeft = i_PercentOfEnergyLeft;
            r_MaximumAmountOfEnergy = i_MaximumAmountOfEnergy;
            m_CurrentAmountOfEnergy = i_CurrentAmountOfEnergy;
        }

        public void AddEnergy(float i_AmountOfEnergyToAdd)
        {
            m_PercentOfEnergyLeft += i_AmountOfEnergyToAdd;
        }

        public float PercentOfEnergyLeft
        {
            get { return m_PercentOfEnergyLeft; }
            set { m_PercentOfEnergyLeft = value; }
        }

        public float MaximumAmountOfEnergy
        {
            get { return r_MaximumAmountOfEnergy; }
        }

        public float CurrentAmountOfEnergy
        {
            get { return m_CurrentAmountOfEnergy; }
            set { m_CurrentAmountOfEnergy = value; }
        }
    }
}
