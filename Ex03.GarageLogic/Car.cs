using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        public enum eColor
        {
            Gray = 1,
            Blue,
            White,
            Black
        }

        public enum eNumbersOfDoors
        {
            TwoDoors = 2,
            ThreeDoors = 3,
            FourDoors = 4,
            FiveDoors = 5
        }

        private readonly eColor r_Color;
        private readonly eNumbersOfDoors r_NumberOfDoors;

        public Car(eColor i_CarColor, eNumbersOfDoors i_NumberOfDoors, string i_ModelName, string i_LicensePlateNumber, eMaximumAirPressure i_MaximumAirPressureForVehicle, List<Wheel> i_CarWheels, Engine i_CarEngine) : base(i_ModelName, i_LicensePlateNumber, i_MaximumAirPressureForVehicle, i_CarWheels, i_CarEngine)
        {
            r_Color = i_CarColor;
            r_NumberOfDoors = i_NumberOfDoors;
        }

        public eNumbersOfDoors NumbersOfDoors
        {
            get { return r_NumberOfDoors; }
        }

        public string GetColorInString()
        {
            string colorString = string.Empty;

            switch (r_Color)
            {
                case eColor.Black:
                    colorString = "Black";
                    break;
                case eColor.Blue:
                    colorString = "Blue";
                    break;
                case eColor.Gray:
                    colorString = "Gray";
                    break;
                case eColor.White:
                    colorString = "White";
                    break;
            }

            return colorString;
        }
    }
}
