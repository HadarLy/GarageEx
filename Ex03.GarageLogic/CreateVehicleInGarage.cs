using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public static class CreateVwhicleInGarage
    {
        public enum eVehicleTypes
        {
            Motorcycle = 1,
            Car = 2,
            Truck = 3
        }

        public static FuelEngine CreateFuelEngine(FuelEngine.eFuelType i_FuelType, float i_CurrentAmountOfFuel, float i_PercentOfEnergyLeft, float i_MaximumAmountOfEnergy)
        {
            FuelEngine fuelEngineForCar = new FuelEngine(i_FuelType, i_CurrentAmountOfFuel, i_PercentOfEnergyLeft, i_MaximumAmountOfEnergy);

            return fuelEngineForCar;
        }

        public static ElectricEngine CreateElectricEngine(float i_TimeLeftInBattery, float i_PercentOfEnergyLeft, float i_MaximumAmountOfEnergy)
        {
            ElectricEngine electricEngineForCar = new ElectricEngine(i_TimeLeftInBattery, i_PercentOfEnergyLeft, i_MaximumAmountOfEnergy);

            return electricEngineForCar;
        }

        public static Wheel CreateWheel(string i_ManufacturerName, float i_CurrentAirPressure, float i_MaximumAirPressure)
        {
            Wheel NewWheel = new Wheel(i_ManufacturerName, i_CurrentAirPressure, i_MaximumAirPressure);

            return NewWheel;
        }

        public static Motorcycle CreateMotorcycle(Motorcycle.eLicenseType i_LicenseType, int i_EngineVolume, string i_ModelName, string i_LicensePlateNumber, Vehicle.eMaximumAirPressure i_MaximumAirPressureForVehicle, List<Wheel> i_WheelList, Engine i_VehicleEngine)
        {
            Motorcycle newMotorcycle = new Motorcycle(i_LicenseType, i_EngineVolume, i_ModelName, i_LicensePlateNumber, i_MaximumAirPressureForVehicle, i_WheelList, i_VehicleEngine);
            return newMotorcycle;
        }

        public static Car CreateCar(Car.eColor i_CarColor, Car.eNumbersOfDoors i_NumberOfDoors, string i_ModelName, string i_LicensePlateNumber, Vehicle.eMaximumAirPressure i_MaximumAirPressureForVehicle, List<Wheel> i_CarWheels, Engine i_CarEngine)
        {
            Car newCar = new Car(i_CarColor, i_NumberOfDoors, i_ModelName, i_LicensePlateNumber, i_MaximumAirPressureForVehicle, i_CarWheels, i_CarEngine);
            return newCar;
        }

        public static Truck CreateTruck(bool i_IsTrankCooled, float i_TrankVolume, string i_ModelName, string i_LicensePlateNumber, Vehicle.eMaximumAirPressure i_MaximumAirPressureForVehicle, List<Wheel> i_TruckWheels, Engine i_TruckEngine)
        {
            Truck newTruck = new Truck(i_IsTrankCooled, i_TrankVolume, i_ModelName, i_LicensePlateNumber, i_MaximumAirPressureForVehicle, i_TruckWheels, i_TruckEngine);
            return newTruck;
        }

        public static VehicleInGarage RegisterVehicleIntoGarage(string i_OwnersName, string i_OwnersPhoneNumber, Vehicle i_Vehicle)
        {
            VehicleInGarage newVehicleInGarage = new VehicleInGarage(i_OwnersName, i_OwnersPhoneNumber, i_Vehicle);

            return newVehicleInGarage;
        }
    }
}