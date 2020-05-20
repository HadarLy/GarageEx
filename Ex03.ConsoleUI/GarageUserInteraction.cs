using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class GarageUserInteraction
    {
        public enum eFunctionsOptions
        {
            RegisterVehicle = 1,
            DisplayLicensePlate = 2,
            ChangeVehicleStatus = 3,
            InflateWheels = 4,
            Refuel = 5,
            ChargeBattery = 6,
            DisplayVehiclesDetails = 7,
            Quit = 8
        }

        public const int k_NumberOfFunctions = 8;
        public const int k_NumberOfVehicleTypes = 3;
        public const int k_NumberOfEngineTypes = 2;

        public static void RunGarage()
        {
            Garage myGarage;
            myGarage = new Garage();
            bool quitGarage = !true;
            string userFunctionChoice;
            int userChoice = 0;
            string licensePlateNumber;

            while (quitGarage == !true)
            {
                bool isChoiceValid = !true;

                while (isChoiceValid == !true)
                {
                    printFunctionsMenu();
                    userFunctionChoice = Console.ReadLine();
                    try
                    {
                        userChoice = convertUserChoiceToInt(userFunctionChoice);
                        isChoiceValid = checkChoiceValidity(userChoice, 1, k_NumberOfFunctions);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input! bad format");
                    }
                }

                eFunctionsOptions functionChoise = (eFunctionsOptions)userChoice;

                switch (functionChoise)
                {
                    case eFunctionsOptions.RegisterVehicle:
                        licensePlateNumber = getLicensePlate();

                        if (myGarage.SearchForVehicleInGarage(licensePlateNumber) == null)
                        {
                            registerVehicle(licensePlateNumber, myGarage);
                        }

                        break;
                    case eFunctionsOptions.DisplayLicensePlate:
                        displayLicensePlatesFunction(myGarage);
                        break;
                    case eFunctionsOptions.ChangeVehicleStatus:
                        if (myGarage.ChangeStatusOfVehicleInGarage(getLicensePlate(), getStatusOfVehicle()))
                        {
                            Console.WriteLine("Status Successfully changed");
                        }
                        else
                        {
                            Console.WriteLine("Error! Status didn't change");
                        }

                        break;
                    case eFunctionsOptions.InflateWheels:
                        licensePlateNumber = getLicensePlate();

                        if (myGarage.InflateWheelsToMaximumAirPressure(licensePlateNumber))
                        {
                            Console.WriteLine("wheels inflated to maximum Successfully");
                        }
                        else
                        {
                            Console.WriteLine("Error!wheels didn't inflat to maximum ");
                        }

                        break;
                    case eFunctionsOptions.Refuel:
                        refuelRequestedVehicle(myGarage);
                        break;
                    case eFunctionsOptions.ChargeBattery:
                        chargeBatteryInVehicle(myGarage);
                        break;
                    case eFunctionsOptions.DisplayVehiclesDetails:
                        displayAllDetailsOfVehicle(getLicensePlate(), myGarage);
                        break;
                    case eFunctionsOptions.Quit:
                        quitGarage = true;
                        break;
                    default:
                        Console.WriteLine("invalid choice! to exit the system please press 8");
                        break;
                }
            }
        }

        private static string getLicensePlate()
        {
            string licensePlate = string.Empty;

            while (licensePlate == string.Empty)
            {
                Console.WriteLine("Please enter a license plate number");
                licensePlate = Console.ReadLine();
            }

            return licensePlate;
        }

        private static void registerVehicle(string i_VehicleLicensePlate, Garage i_Garage)
        {
            string stringUserChoiceForVehicle;
            int intUserChoiceForVehicle = 0;
            bool isChoiceValid = !true;
            CreateVwhicleInGarage.eVehicleTypes typeOfVehicleToAdd;
            string vehicleOwnersName = getVehicleOwnersName();
            string vehicleOwnersPhoneNumber = getVehicleOwnersPhoneNumber();
            string vehicleModelName = getVehicleModelName();
            Engine engineForVehicle;
            List<Wheel> wheelsForVehicle;
            Vehicle vehicleToAdd = null;
            VehicleInGarage newVehicleToAddToTheGarage;

            while (isChoiceValid == !true)
            {
                printVehicleMenu();
                stringUserChoiceForVehicle = Console.ReadLine();
                try
                {
                    intUserChoiceForVehicle = convertUserChoiceToInt(stringUserChoiceForVehicle);
                    isChoiceValid = checkChoiceValidity(intUserChoiceForVehicle, 1, k_NumberOfVehicleTypes);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input! bad format");
                }
            }

            typeOfVehicleToAdd = (CreateVwhicleInGarage.eVehicleTypes)intUserChoiceForVehicle;

            switch (typeOfVehicleToAdd)
            {
                case CreateVwhicleInGarage.eVehicleTypes.Motorcycle:
                    engineForVehicle = getEngineForUser(CreateVwhicleInGarage.eVehicleTypes.Motorcycle);
                    wheelsForVehicle = getWheelsFromUser(Vehicle.eNuberOfWheelsForVehicle.TwoWheels, Vehicle.eMaximumAirPressure.MotorcycleAirPressure);
                    Motorcycle.eLicenseType licenseType = getLicenseTypeFromUser();
                    int engineVolume = getEngineVolumeFromUser();
                    vehicleToAdd = CreateVwhicleInGarage.CreateMotorcycle(licenseType, engineVolume, vehicleModelName, i_VehicleLicensePlate, Vehicle.eMaximumAirPressure.MotorcycleAirPressure, wheelsForVehicle, engineForVehicle);
                    break;
                case CreateVwhicleInGarage.eVehicleTypes.Car:
                    engineForVehicle = getEngineForUser(CreateVwhicleInGarage.eVehicleTypes.Car);
                    wheelsForVehicle = getWheelsFromUser(Vehicle.eNuberOfWheelsForVehicle.FourWheels, Vehicle.eMaximumAirPressure.CarAirPressure);
                    Car.eNumbersOfDoors numberOfDoors = getNumberOfDoorsInCar();
                    Car.eColor carColor = getCarColor();
                    vehicleToAdd = CreateVwhicleInGarage.CreateCar(carColor, numberOfDoors, vehicleModelName, i_VehicleLicensePlate, Vehicle.eMaximumAirPressure.CarAirPressure, wheelsForVehicle, engineForVehicle);
                    break;
                case CreateVwhicleInGarage.eVehicleTypes.Truck:
                    engineForVehicle = getEngineForUser(CreateVwhicleInGarage.eVehicleTypes.Truck);
                    wheelsForVehicle = getWheelsFromUser(Vehicle.eNuberOfWheelsForVehicle.TwelveWheels, Vehicle.eMaximumAirPressure.TruckAirPressure);
                    bool isTrunkCooled = askUserIfTruckTrunkCooled();
                    float trunkVolume = getTruckTrunkVolumeFromUser();
                    vehicleToAdd = CreateVwhicleInGarage.CreateTruck(isTrunkCooled, trunkVolume, vehicleModelName, i_VehicleLicensePlate, Vehicle.eMaximumAirPressure.TruckAirPressure, wheelsForVehicle, engineForVehicle);
                    break;
            }

            newVehicleToAddToTheGarage = CreateVwhicleInGarage.RegisterVehicleIntoGarage(vehicleOwnersName, vehicleOwnersPhoneNumber, vehicleToAdd);
            i_Garage.AddVehicleToTheGarageList(newVehicleToAddToTheGarage);
            Console.WriteLine("Vehicle added successfully");
        }

        private static void printVehicleMenu()
        {
            string menu;

            menu = string.Format(@"Please enter the type of vehicle you would like to put in the garage : 
press 1 for motorcycle
press 2 for car
press 3 for truck");
            Console.WriteLine(menu);
        }

        private static string getVehicleOwnersName()
        {
            string ownersName;

            Console.WriteLine("Please enter the vehicle owners name: ");
            ownersName = Console.ReadLine();

            return ownersName;
        }

        private static string getVehicleOwnersPhoneNumber()
        {
            string ownersPhoneNumber = string.Empty;
            bool isInputValid = !true;
            int countValidLetters = 0;

            while (isInputValid == !true)
            {
                Console.WriteLine("Please enter the vehicle owners phone number: ");
                ownersPhoneNumber = Console.ReadLine();

                for (int i = 0; i < ownersPhoneNumber.Length; i++)
                {
                    if (ownersPhoneNumber[i] >= '0' || ownersPhoneNumber[i] <= '9')
                    {
                        countValidLetters++;
                    }
                }

                if (countValidLetters == ownersPhoneNumber.Length)
                {
                    isInputValid = true;
                }
                else
                {
                    Console.WriteLine("Invalid Input!");
                }
            }

            return ownersPhoneNumber;
        }

        private static void printFunctionsMenu()
        {
            string Functionsmenu;

            Functionsmenu = string.Format(@"Press 1 to register a vehicle in the garage 
Press 2 to display license-plates numbers of the vehicles in the garage 
Press 3 to change a status of a vehicle
Press 4 to inflate a vehicle's wheels to maximum air-pressure
Press 5 to refule a vehicle
Press 6 to charge a vehicle's battery
Press 7 to display a vehicle's details
Press 8 to quit");

            Console.WriteLine(Functionsmenu);
        }

        private static bool checkChoiceValidity(int i_Choice, int i_LowerBoundery, int i_UpperBoundery)
        {
            bool isValid = !true;

            if (i_Choice >= i_LowerBoundery && i_Choice <= i_UpperBoundery)
            {
                isValid = true;
            }

            if (isValid == !true)
            {
                Console.WriteLine("Invalid Input!");
            }

            return isValid;
        }

        private static int convertUserChoiceToInt(string i_UserChoice)
        {
            int choice = 0;

            try
            {
                choice = int.Parse(i_UserChoice);
            }
            catch (FormatException ex)
            {
                throw ex;
            }

            return choice;
        }

        private static void displayLicensePlatesOfAllVehiclesInGarage(Garage i_Garage)
        {
            Dictionary<string, VehicleInGarage> VehiclesDictionary = i_Garage.VehiclesDictionary;

            if (VehiclesDictionary.Count == 0)
            {
                Console.WriteLine("There are no vehicles in the garage.");
            }
            else
            {
                foreach (KeyValuePair<string, VehicleInGarage> pair in VehiclesDictionary)
                {
                    Console.WriteLine("{0}", pair.Key);
                }
            }
        }

        private static void displayLicensePlatesOfVehiclesInRequestedStatus(Garage i_Garage, VehicleInGarage.eVehicleStatus i_RequestedStatus)
        {
            List<string> licensePlatesList = i_Garage.MakeLicensePlatesListOfVehiclesInRequestedStatus(i_RequestedStatus);

            if (licensePlatesList.Count == 0)
            {
                Console.WriteLine("There are no vehicles in this status at the garage.");
            }
            else
            {
                foreach (string licensePlate in licensePlatesList)
                {
                    Console.WriteLine("{0}", licensePlate);
                }
            }
        }

        private static Engine getEngineForUser(CreateVwhicleInGarage.eVehicleTypes i_UserVehicleType)
        {
            Engine engineForUser;

            if (i_UserVehicleType != CreateVwhicleInGarage.eVehicleTypes.Truck)
            {
                Engine.eEngineType requestedEngine;

                requestedEngine = getEngineTypeFromUser(k_NumberOfEngineTypes);

                if (requestedEngine == Engine.eEngineType.Fuel)
                {
                    if (i_UserVehicleType == CreateVwhicleInGarage.eVehicleTypes.Motorcycle)
                    {
                        float currentAmountOfFuelLeft = getAmountOfFuelLeftInVeicle(6);
                        float percentOfFuelInVehicle = (currentAmountOfFuelLeft / 6) * 100;
                        engineForUser = CreateVwhicleInGarage.CreateFuelEngine(FuelEngine.eFuelType.Octan96, currentAmountOfFuelLeft, percentOfFuelInVehicle, 6);
                    }
                    else
                    {
                        float currentAmountOfFuelLeft = getAmountOfFuelLeftInVeicle(45);
                        float percentOfFuelInVehicle = (currentAmountOfFuelLeft / 45) * 100;
                        engineForUser = CreateVwhicleInGarage.CreateFuelEngine(FuelEngine.eFuelType.Octan98, currentAmountOfFuelLeft, percentOfFuelInVehicle, 45);
                    }
                }
                else
                {
                    if (i_UserVehicleType == CreateVwhicleInGarage.eVehicleTypes.Motorcycle)
                    {
                        float timeLeftInBattery = getTimeLeftInBattery(1.8f);
                        float percentOfBatteryInVehicle = (timeLeftInBattery / 1.8f) * 100;
                        engineForUser = CreateVwhicleInGarage.CreateElectricEngine(timeLeftInBattery, percentOfBatteryInVehicle, 1.8f);
                    }
                    else 
                    {
                        float timeLeftInBattery = getTimeLeftInBattery(3.2f);
                        float percentOfBatteryInVehicle = (timeLeftInBattery / 3.2f) * 100;
                        engineForUser = CreateVwhicleInGarage.CreateElectricEngine(timeLeftInBattery, percentOfBatteryInVehicle, 3.2f);
                    }
                }
            }
            else
            {
                float currentAmountOfFuelLeft = getAmountOfFuelLeftInVeicle(115);
                float percentOfFuelInVehicle = (currentAmountOfFuelLeft / 115) * 100;
                engineForUser = CreateVwhicleInGarage.CreateFuelEngine(FuelEngine.eFuelType.Soler, currentAmountOfFuelLeft, percentOfFuelInVehicle, 115);
            }

            return engineForUser;
        }

        private static Engine.eEngineType getEngineTypeFromUser(int i_NumberOfEnginetypes)
        {
            Engine.eEngineType requestedEngine;

            string msg, userEngineChoice;
            int intUserEngineChoice = 0;

            bool isChoiceValid = !true;

            while (isChoiceValid == !true)
            {
                msg = string.Format(@"Please enter the type of engine for your car : 
press 1 for fuel engine
press 2 for electric engine");
                Console.WriteLine(msg);
                userEngineChoice = Console.ReadLine();
                try
                {
                    intUserEngineChoice = convertUserChoiceToInt(userEngineChoice);
                    isChoiceValid = checkChoiceValidity(intUserEngineChoice, 1, i_NumberOfEnginetypes);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input! bad format");
                }
            }

            requestedEngine = (Engine.eEngineType)intUserEngineChoice;

            return requestedEngine;
        }

        private static float getAmountOfFuelLeftInVeicle(float i_MaximumAmountForVehicle)
        {
            string stringFuelLeft;
            float amountOfFuelLeft = 0; // default
            bool isInputValid = !true;

            while (isInputValid == !true)
            {
                Console.WriteLine("Please enter the amount of fuel left in the vehicle(in liters): ");
                stringFuelLeft = Console.ReadLine();

                try
                {
                    amountOfFuelLeft = float.Parse(stringFuelLeft);
                    if (i_MaximumAmountForVehicle >= amountOfFuelLeft && amountOfFuelLeft >= 0)
                    {
                        isInputValid = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input! amount of fuel left is out of range");
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return amountOfFuelLeft;
        }

        private static float getTimeLeftInBattery(float i_MaximumBatteryTime)
        {
            string stringTimeLeft;
            float batteryTimeLeft = 0;
            bool isInputValid = !true;

            while (isInputValid == !true)
            {
                Console.WriteLine("Please enter the time left in battery(in hours): ");
                stringTimeLeft = Console.ReadLine();

                try
                {
                    batteryTimeLeft = float.Parse(stringTimeLeft);
                    if (batteryTimeLeft <= i_MaximumBatteryTime && batteryTimeLeft >= 0)
                    {
                        isInputValid = true;
                    }
                    else
                    {
                        Console.WriteLine("battery time entered is out of range");
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return batteryTimeLeft;
        }

        private static List<Wheel> getWheelsFromUser(Vehicle.eNuberOfWheelsForVehicle i_NumberOfWheelsForVehicle, Vehicle.eMaximumAirPressure i_MaximumAirPressure)
        {
            List<Wheel> VehicleWheels = new List<Wheel>();
            string manufacturerName;
            float currentAirPressure;
            Wheel wheelForVehicle;

            for (int i = 1; i <= (int)i_NumberOfWheelsForVehicle; i++)
            {
                Console.WriteLine("enter wheel number {0} information", i);
                manufacturerName = getWheelManufacturerName();
                currentAirPressure = getcurrentAirPressure((float)i_MaximumAirPressure);
                wheelForVehicle = CreateVwhicleInGarage.CreateWheel(manufacturerName, currentAirPressure, (int)i_MaximumAirPressure);
                VehicleWheels.Add(wheelForVehicle);
            }

            return VehicleWheels;
        }

        private static string getWheelManufacturerName()
        {
            string manufacturerName;

            Console.WriteLine("Please enter the wheel manufacturerName: ");
            manufacturerName = Console.ReadLine();

            return manufacturerName;
        }

        private static float getcurrentAirPressure(float i_MaximumAirPressureForWheel)
        {
            string stringCurrentAirPressure;
            float CurrentAirPressure = 32; // default
            bool isInputValid = !true;

            while (isInputValid == !true)
            {
                Console.WriteLine("Please enter the current air pressure in the tyre : ");
                stringCurrentAirPressure = Console.ReadLine();
                try
                {
                    CurrentAirPressure = float.Parse(stringCurrentAirPressure);
                    if (CurrentAirPressure <= i_MaximumAirPressureForWheel)
                    {
                        isInputValid = true;
                    }
                    else
                    {
                        throw new ValueOutOfRangeException(0, i_MaximumAirPressureForWheel);
                    }
                }
                catch(ValueOutOfRangeException valEx)
                {
                    Console.WriteLine(valEx.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return CurrentAirPressure;
        }

        private static Motorcycle.eLicenseType getLicenseTypeFromUser()
        {
            string stringLicenseType, msg;
            int LicenseType = 0;
            bool isChoiceValid = !true;

            while (isChoiceValid == !true)
            {
                msg = string.Format(@"Please enter the license type of the motorcycle : 
press 1 for A
press 2 for A1
press 3 for B1
press 4 for B2 ");
                Console.WriteLine(msg);
                stringLicenseType = Console.ReadLine();
                try
                {
                    LicenseType = int.Parse(stringLicenseType);
                    isChoiceValid = checkChoiceValidity(LicenseType, 1, 4);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return (Motorcycle.eLicenseType)LicenseType;
        }

        private static int getEngineVolumeFromUser()
        {
            string stringEngineVolumeFromUser;
            int engineVolume = 125; // default engine volume
            bool isInputValid = !true;

            while (isInputValid == !true)
            {
                Console.WriteLine("Please enter the engine volume: ");
                stringEngineVolumeFromUser = Console.ReadLine();

                try
                {
                    engineVolume = int.Parse(stringEngineVolumeFromUser);
                    isInputValid = true;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return engineVolume;
        }

        private static string getVehicleModelName()
        {
            string ModelName;

            Console.WriteLine("Please enter the vehicle model name: ");
            ModelName = Console.ReadLine();

            return ModelName;
        }

        private static void displayWheelsDetails(List<Wheel> i_WheelList)
        {
            Console.WriteLine("Wheels details:");

            foreach (Wheel wheel in i_WheelList)
            {
                Console.WriteLine(
                    @"Current air pressure: {0}
Manufacturer name: {1}",
wheel.CurrentAirPressure,
wheel.ManufacturerName);
            }
        }

        private static void displayAllDetailsOfVehicle(string i_LicensePlateNumber, Garage i_Garage)
        {
            VehicleInGarage requestedVehicle = i_Garage.SearchForVehicleInGarage(i_LicensePlateNumber);

            if (requestedVehicle != null)
            {
                string status = requestedVehicle.GetVehicleStatusInString();
                bool isFuelEngine = requestedVehicle.TheVehicle.VehicleEngine is FuelEngine;
                bool isCar = requestedVehicle.TheVehicle is Car;
                bool isMotorCycle = requestedVehicle.TheVehicle is Motorcycle;

                Console.WriteLine(
                       @"License plate number is: {0}
Model name: {1}
Owners name: {2}
Owners Phone number: {3}
Vehicle status: {4}",
requestedVehicle.TheVehicle.LicensePlateNumber,
requestedVehicle.TheVehicle.ModelName,
requestedVehicle.OwnersName, 
requestedVehicle.OwnnersPhoneNumber,
status);

                displayWheelsDetails(requestedVehicle.TheVehicle.VehicleWheels);
                if (isFuelEngine)
                {
                    FuelEngine vehicleEngine = requestedVehicle.TheVehicle.VehicleEngine as FuelEngine;
                    Console.WriteLine(
                        @"Current Amount of fuel: {0}
Fuel Type: {1}",
requestedVehicle.TheVehicle.VehicleEngine.CurrentAmountOfEnergy,
vehicleEngine.GetFuelTypeInString());
                }
                else
                {
                    ElectricEngine vehicleEngine = requestedVehicle.TheVehicle.VehicleEngine as ElectricEngine;
                    if (vehicleEngine != null)
                    {
                        Console.WriteLine(
                            @"Time left in battery: {0}",
vehicleEngine.CurrentAmountOfEnergy);
                    }
                }

                if (isCar)
                {
                    Car vehicleType = requestedVehicle.TheVehicle as Car;
                    if (vehicleType != null)
                    {
                        Console.WriteLine(
                               @"Color: {0}
Number Of Doors: {1}",
vehicleType.GetColorInString(),
(int)vehicleType.NumbersOfDoors);
                    }
                }
                else if (isMotorCycle)
                {
                    Motorcycle vehicleType = requestedVehicle.TheVehicle as Motorcycle;
                    if (vehicleType != null)
                    {
                        Console.WriteLine(
                            @"License Type: {0}
Engine volume: {1}",
vehicleType.GetLicenseTypeInString(),
vehicleType.EngineVolume);
                    }
                }
                else
                {
                    Truck vehicleType = requestedVehicle.TheVehicle as Truck;
                    if (vehicleType != null)
                    {
                        string isCooled = "No";
                        if (vehicleType.IsTrankCooled)
                        {
                            isCooled = "YES";
                        }

                        Console.WriteLine(
                               @"Is trunk cooled: {0}
Trunk volume: {1}", 
isCooled, 
vehicleType.TrankVolume);
                    }
                }
            }
            else
            {
                Console.WriteLine("vehicle not found");
            }
        }

        private static Car.eNumbersOfDoors getNumberOfDoorsInCar()
        {
            string stringNumberOfDoorsInCar;
            int NumberOfDoors = 4; // default
            bool isChoiceValid = !true;

            while (isChoiceValid == !true)
            {
                Console.WriteLine("Please enter the numbers of doors in the car: ");
                stringNumberOfDoorsInCar = Console.ReadLine();

                try
                {
                    NumberOfDoors = int.Parse(stringNumberOfDoorsInCar);
                    isChoiceValid = checkChoiceValidity(NumberOfDoors, 2, 5);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return (Car.eNumbersOfDoors)NumberOfDoors;
        }

        private static Car.eColor getCarColor()
        {
            string stringCarColor, msg;
            int userChoiceForCarColor = 1; // default
            bool isChoiceValid = !true;

            while (isChoiceValid == !true)
            {
                msg = string.Format(@"Please enter the color of the car : 
press 1 for Gray
press 2 for Blue
press 3 for White
press 4 for Black");
                Console.WriteLine(msg);
                stringCarColor = Console.ReadLine();

                try
                {
                    userChoiceForCarColor = int.Parse(stringCarColor);
                    isChoiceValid = checkChoiceValidity(userChoiceForCarColor, 1, 4);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return (Car.eColor)userChoiceForCarColor;
        }

        private static float getTruckTrunkVolumeFromUser()
        {
            string stringTrunkVolume;
            float TrunkVolume = 100; // default
            bool isInputValid = !true;

            while (isInputValid == !true)
            {
                Console.WriteLine("Please enter the trunk's volume: ");
                stringTrunkVolume = Console.ReadLine();

                try
                {
                    TrunkVolume = float.Parse(stringTrunkVolume);
                    isInputValid = true;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return TrunkVolume;
        }

        private static bool askUserIfTruckTrunkCooled()
        {
            string stringUserInput;
            bool isTrunkCooled = !true;
            bool isChoiceValid = !true;

            while (isChoiceValid == !true)
            {
                Console.WriteLine("is the truck trunk cooled? (please answer by Yes or No): ");
                stringUserInput = Console.ReadLine();

                if (string.Equals(stringUserInput, "Yes"))
                {
                    isTrunkCooled = true;
                    isChoiceValid = true;
                }
                else if (string.Equals(stringUserInput, "No"))
                {
                    isTrunkCooled = !true;
                    isChoiceValid = true;
                }
                else
                {
                    Console.WriteLine("Invalid Choice! ");
                }
            }

            return isTrunkCooled;
        }

        private static void displayLicensePlatesFunction(Garage i_Garage)
        {
            string userChoiceForDisplay, msg;

            msg = string.Format(@"Press 1 to display the licence plates of all the vehicle in the garage 
Press 2 to display by requested status");
            Console.WriteLine(msg);
            userChoiceForDisplay = Console.ReadLine();
            if (userChoiceForDisplay == "1")
            {
                displayLicensePlatesOfAllVehiclesInGarage(i_Garage);
            }
            else if (userChoiceForDisplay == "2")
            {
                displayLicensePlatesOfVehiclesInRequestedStatus(i_Garage, getStatusOfVehicle());
            }
            else
            {
                Console.WriteLine("InValid status!");
            }
        }

        private static VehicleInGarage.eVehicleStatus getStatusOfVehicle()
        {
            string msg, userChoiceForStatus;
            int requestedStatus = 1;
            bool isChoiceValid = !true;

            while (isChoiceValid == !true)
            {
                msg = string.Format(@"press 1 for InRepair 
press 2 for Fix
press 3 for Paid");
                Console.WriteLine(msg);
                userChoiceForStatus = Console.ReadLine();

                try
                {
                    requestedStatus = int.Parse(userChoiceForStatus);
                    isChoiceValid = checkChoiceValidity(requestedStatus, 1, 3);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return (VehicleInGarage.eVehicleStatus)requestedStatus;
        }

        private static void refuelRequestedVehicle(Garage i_Garage)
        {
            try
            {
                i_Garage.RefuleVechileWithFuelEngine(getLicensePlate(), getFuelTypeFromUser(), getAmountOfFuelToFillFromUser());
                Console.WriteLine("Vehicle refuled Successfully");
            }
            catch (ValueOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static float getAmountOfFuelToFillFromUser()
        {
            string stringAmountOfFuelToFill;
            float AmountOfFuelToFill = 0;
            bool isInputValid = !true;

            while (isInputValid == !true)
            {
                Console.WriteLine("Please enter the amount of fuel to fill in the vehicle(in liters): ");
                stringAmountOfFuelToFill = Console.ReadLine();

                try
                {
                    AmountOfFuelToFill = float.Parse(stringAmountOfFuelToFill);
                    isInputValid = true;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return AmountOfFuelToFill;
        }

        private static FuelEngine.eFuelType getFuelTypeFromUser()
        {
            string msg, FuelTypeFromUser;
            int requestedFuelType = 1; // default
            bool isInputValid = !true;

            while (isInputValid == !true)
            {
                msg = string.Format(@"press 1 for Octan95 
press 2 for Octan96
press 3 for Octan98
press 4 for Soler");

                Console.WriteLine(msg);
                FuelTypeFromUser = Console.ReadLine();
                try
                {
                    requestedFuelType = int.Parse(FuelTypeFromUser);
                    isInputValid = true;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return (FuelEngine.eFuelType)requestedFuelType;
        }

        private static void chargeBatteryInVehicle(Garage i_Garage)
        {
            try
            {
                i_Garage.ChargeElectricVehicle(getLicensePlate(), getMinutesToCharge());
                Console.WriteLine("Vehicle charged Successfully");
            }
            catch (ValueOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static float getMinutesToCharge()
        {
            string stringMinutesToCharge;
            float MinutesToCharge = 0; // default
            bool isInputValid = !true;

            while (isInputValid == !true)
            {
                Console.WriteLine("Please enter how many minutes to charge: ");
                stringMinutesToCharge = Console.ReadLine();

                try
                {
                    MinutesToCharge = float.Parse(stringMinutesToCharge);
                    isInputValid = true;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return MinutesToCharge;
        }
    }
}