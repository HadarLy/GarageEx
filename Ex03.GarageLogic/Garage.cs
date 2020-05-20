using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, VehicleInGarage> m_VehiclesDictionary;

        public Garage()
        {
            m_VehiclesDictionary = new Dictionary<string, VehicleInGarage>();
        }

        public Dictionary<string, VehicleInGarage> VehiclesDictionary
        {
            get { return m_VehiclesDictionary; }
        }

        public VehicleInGarage SearchForVehicleInGarage(string i_LicensePlate)
        {
            VehicleInGarage requestedVehicle = null;

            m_VehiclesDictionary.TryGetValue(i_LicensePlate, out requestedVehicle);

            return requestedVehicle;
        }

        public List<string> MakeLicensePlatesListOfVehiclesInRequestedStatus(VehicleInGarage.eVehicleStatus i_RequestedStatus)
        {
            List<string> requestedList = new List<string>();

            foreach (KeyValuePair<string, VehicleInGarage> pair in m_VehiclesDictionary)
            {
                if (pair.Value.VehicleStatus == i_RequestedStatus)
                {
                    requestedList.Add(pair.Key);
                }
            }

            return requestedList;
        }

        public bool ChangeStatusOfVehicleInGarage(string i_LicensePlate, VehicleInGarage.eVehicleStatus i_NewStatus)
        {
            VehicleInGarage requestedVehicle = SearchForVehicleInGarage(i_LicensePlate);
            bool statusChanged;

            if (requestedVehicle != null)
            {
                requestedVehicle.VehicleStatus = i_NewStatus;
                statusChanged = true;
            }
            else
            {
                statusChanged = !true;
            }

            return statusChanged;
        }

        public bool InflateWheelsToMaximumAirPressure(string i_LicensePlate)
        {
            VehicleInGarage requestedVehicle = SearchForVehicleInGarage(i_LicensePlate);
            bool InflateDone;

            if (requestedVehicle != null)
            {
                foreach (Wheel wheel in requestedVehicle.TheVehicle.VehicleWheels)
                {
                    float airToAdd = wheel.MaximumAirPressureForWheel - wheel.CurrentAirPressure;
                    wheel.InflateWheel(airToAdd);
                }

                InflateDone = true;
            }
            else
            {
                InflateDone = !true;
            }

            return InflateDone;
        }

        public bool RefuleVechileWithFuelEngine(string i_LicensePlate, FuelEngine.eFuelType i_RequestedFuelType, float i_AmountOfFuelToFill)
        {
            VehicleInGarage requestedVehicle = SearchForVehicleInGarage(i_LicensePlate);
            bool refuelDone;

            if (requestedVehicle != null)
            {
                bool isFuelEngine = requestedVehicle.TheVehicle.VehicleEngine is FuelEngine;

                if (isFuelEngine)
                {
                    FuelEngine vehicleEngine = requestedVehicle.TheVehicle.VehicleEngine as FuelEngine;
                    if (vehicleEngine.TheFuelType == i_RequestedFuelType)
                    {
                        if (requestedVehicle.TheVehicle.VehicleEngine.CurrentAmountOfEnergy + i_AmountOfFuelToFill <= requestedVehicle.TheVehicle.VehicleEngine.MaximumAmountOfEnergy)
                        {
                            requestedVehicle.TheVehicle.VehicleEngine.CurrentAmountOfEnergy += i_AmountOfFuelToFill;
                            requestedVehicle.TheVehicle.VehicleEngine.PercentOfEnergyLeft = (requestedVehicle.TheVehicle.VehicleEngine.CurrentAmountOfEnergy / requestedVehicle.TheVehicle.VehicleEngine.MaximumAmountOfEnergy) * 100;
                        }
                        else
                        {
                            float maxValue = requestedVehicle.TheVehicle.VehicleEngine.MaximumAmountOfEnergy - requestedVehicle.TheVehicle.VehicleEngine.CurrentAmountOfEnergy;
                            throw new ValueOutOfRangeException(0, maxValue);
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Wrong fuel type!");
                    }
                }
                else
                {
                    throw new ArgumentException("The requested vehicle does not run on gas!");
                }

                refuelDone = true;
            }
            else
            {
                refuelDone = !true;
            }

            return refuelDone;
        }

        public void ChargeElectricVehicle(string i_LicensePlate, float i_MinutesToCharge)
        {
            VehicleInGarage requestedVehicle = SearchForVehicleInGarage(i_LicensePlate);
            float hoursToCharge = i_MinutesToCharge / 60;
            bool isElectricEngine = requestedVehicle.TheVehicle.VehicleEngine is ElectricEngine;

            if (requestedVehicle != null)
            {
                if (isElectricEngine)
                {
                    ElectricEngine vehicleEngine = requestedVehicle.TheVehicle.VehicleEngine as ElectricEngine;
                    if (requestedVehicle.TheVehicle.VehicleEngine.CurrentAmountOfEnergy + hoursToCharge <= requestedVehicle.TheVehicle.VehicleEngine.MaximumAmountOfEnergy)
                    {
                        requestedVehicle.TheVehicle.VehicleEngine.CurrentAmountOfEnergy += hoursToCharge;
                        requestedVehicle.TheVehicle.VehicleEngine.PercentOfEnergyLeft = (requestedVehicle.TheVehicle.VehicleEngine.CurrentAmountOfEnergy / requestedVehicle.TheVehicle.VehicleEngine.MaximumAmountOfEnergy) * 100;
                    }
                    else
                    {
                        float maxValue = (requestedVehicle.TheVehicle.VehicleEngine.MaximumAmountOfEnergy - requestedVehicle.TheVehicle.VehicleEngine.CurrentAmountOfEnergy) * 60;
                        throw new ValueOutOfRangeException(0, maxValue);
                    }
                }
                else
                {
                    throw new ArgumentException("The requested vehicle is not electric!");
                }
            }
            else
            {
                throw new ArgumentException("The requested vehicle does not run on gas!");
            } 
        }

        public void AddVehicleToTheGarageList(VehicleInGarage i_VehicleToAdd)
        {
            m_VehiclesDictionary.Add(i_VehicleToAdd.TheVehicle.LicensePlateNumber, i_VehicleToAdd);
        }
    }
}
