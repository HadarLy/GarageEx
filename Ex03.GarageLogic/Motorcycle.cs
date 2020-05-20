using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        public enum eLicenseType
        {
            A = 1,
            A1,
            B1,
            B2
        }

        private readonly eLicenseType r_LicenseType;
        private readonly int r_EngineVolume; 

        public Motorcycle(eLicenseType i_LicenseType, int i_EngineVolume, string i_ModelName, string i_LicensePlateNumber, eMaximumAirPressure i_MaximumAirPressureForVehicle, List<Wheel> i_CarWheels, Engine i_MotorCycleEngine) : base(i_ModelName, i_LicensePlateNumber, i_MaximumAirPressureForVehicle, i_CarWheels, i_MotorCycleEngine)
        {
            r_LicenseType = i_LicenseType;
            r_EngineVolume = i_EngineVolume;
        }

        public string GetLicenseTypeInString()
        {
            string licenseTypeString = string.Empty;

            switch (r_LicenseType)
            {
                case eLicenseType.A:
                    licenseTypeString = "A";
                    break;
                case eLicenseType.A1:
                    licenseTypeString = "A1";
                    break;
                case eLicenseType.B1:
                    licenseTypeString = "B1";
                    break;
                case eLicenseType.B2:
                    licenseTypeString = "B2";
                    break;
            }

            return licenseTypeString;
        }

        public int EngineVolume
        {
            get { return r_EngineVolume; }
        }
    }
}
