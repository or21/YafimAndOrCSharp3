﻿//----------------------------------------------------------------------
// <copyright file="GarageManager.cs" company="B15_Ex03">
// Yafim Vodkov 308973882 Or Brand 302521034
// </copyright>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using Ex03.GarageLogic;

namespace Ex03.GarageManagementSystem.ConsuleUI
{
    /// <summary>
    /// Manages the garage logic
    /// </summary>
    public class GarageManager
    {
        /// <summary>
        /// Message when vehicle is already in garage.
        /// </summary>
        private const string k_VehicleAlreadyInGarage =
@"This vehicle is already in the garage.
The system will change it's state to 'In Process'";

        /// <summary>
        /// Bad input message
        /// </summary>
        private const string k_AEerror =
@"There was an error in your input: {0}
Try again to insert a vehicle";

        /// <summary>
        /// PowerSource load success message.
        /// </summary>
        private const string k_PowerSourceLoadingSuccess =
@"Power source loaded successfuly
Press 'enter' to continue";

        /// <summary>
        /// Inflate tires success message.
        /// </summary>
        private const string k_AirBlowSuccess =
@"Air blowed successfuly
Press 'enter' to continue";

        /// <summary>
        /// Vehicle not found in the garage.
        /// </summary>
        private const string k_VehicleNotFound = "Vehicle not found. Please try again. (Press 'enter' to continue).";

        /// <summary>
        /// Nothing was typed message.
        /// </summary>
        private const string k_NPEerror = "Nothing was typed. Error is: ";

        /// <summary>
        /// 'exit' to exit system.
        /// </summary>
        private const string k_ExitCode = "exit";

        /// <summary>
        /// Instance of this class.
        /// </summary>
        private static Garage s_Garage;

        /// <summary>
        /// Initializes a new instance of the GarageManager class.
        /// </summary>
        public GarageManager()
        {
            s_Garage = new Garage();
        }

        /// <summary>
        /// Make supported operation.
        /// </summary>
        /// <param name="i_InputNumber">Number of operation.</param>
        private static void makeOperation(int i_InputNumber)
        {
            switch (i_InputNumber)
            {
                case (int)eOperation.Insert:
                    insertVehicleToGarage();
                    break;
                case (int)eOperation.ShowByLicence:
                    showVehiclesByLicense();
                    break;
                case (int)eOperation.ChangeState:
                    changeVehicleState();
                    break;
                case (int)eOperation.BlowUp:
                    blowAirForVehicle();
                    break;
                case (int)eOperation.LoadFuel:
                    loadPowerSourceForVehicle(eOperation.LoadFuel);
                    break;
                case (int)eOperation.LoadEnergy:
                    loadPowerSourceForVehicle(eOperation.LoadEnergy);
                    break;
                case (int)eOperation.ShowData:
                    showDataForVehicle();
                    break;
            }
        }

        /// <summary>
        /// Insert vehicle to garage.
        /// </summary>
        private static void insertVehicleToGarage()
        {
            try
            {
                insertToGarageOpertaions();
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(k_AEerror, ae.Message);
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch (ValueOutOfRangeException vore)
            {
                Console.WriteLine(vore.Message);
            }
            catch (NullReferenceException nre)
            {
                Console.WriteLine(k_NPEerror + nre.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Insert vehicle to garage.
        /// </summary>
        private static void insertToGarageOpertaions()
        {
            string licenseNumber = getLicenseNumberFromUser();
            Garage.VehicleInGarage currentVehicle = s_Garage.FindVehicleByLicense(licenseNumber);
            if (currentVehicle.CurrVehicle != null)
            {
                Console.WriteLine(k_VehicleAlreadyInGarage);
                const string k_Status = "InProcess";
                s_Garage.ChangeVehicleStatus(licenseNumber, k_Status);
            }
            else
            {
                string vehicleType = getTypeOfVehicleInformation();
                string ownerName = getOwnerNameInformation();
                string phoneNumber = getPhoneNumberInformation();
                Garage.VehicleInGarage newVehicleInGarage = s_Garage.CreateVehicle(
                    vehicleType, licenseNumber, ownerName, phoneNumber);
                newVehicleInGarage.CurrVehicle.Id = licenseNumber;
                fillParams(newVehicleInGarage);
                s_Garage.AddVehicle(newVehicleInGarage);
                Console.WriteLine("Vehicle inserted successfully. Press 'enter' to continue");
            }
        }

        /// <summary>
        /// Get owner information.
        /// </summary>
        /// <returns>Vehicle information.</returns>
        private static string getOwnerNameInformation()
        {
            Console.Write("Please enter your name: ");
            string lNumber = Console.ReadLine();

            /* This method exists for future logic for owner name. */

            return lNumber;
        }

        /// <summary>
        /// Get the phone information.
        /// </summary>
        /// <returns>Phone information.</returns>
        private static string getPhoneNumberInformation()
        {
            Console.Write("Please enter your phone number: ");
            string lNumber = Console.ReadLine();

            /* This method exists for future logic for phone number. */

            return lNumber;
        }

        /// <summary>
        /// Fill standard form to insert vehicle to garage. 
        /// </summary>
        /// <param name="i_NewVehicleInGarage">The vehicle to insert.</param>
        private static void fillParams(Garage.VehicleInGarage i_NewVehicleInGarage)
        {
            for (int i = 0; i < i_NewVehicleInGarage.CurrVehicle.VehicleDictionary.Count; i++)
            {
                string key = i_NewVehicleInGarage.CurrVehicle.VehicleDictionary.ElementAt(i).Key;
                Console.Write(key + ": ");
                string input = Console.ReadLine();
                i_NewVehicleInGarage.CurrVehicle.VehicleDictionary[key] = input;
            }
        }

        /// <summary>
        /// Get vehicle information.
        /// </summary>
        /// <returns>Vehicle information.</returns>
        private static string getTypeOfVehicleInformation()
        {
            bool isValidType = false;
            string typeOfVehicle = null;
            int numberOfVehicleTypes = Enum.GetNames(typeof(Builder.eVehicle)).Length;
            while (!isValidType)
            {
                int numberOfSupportedVechicle = Enum.GetNames(typeof(Builder.eVehicle)).Length;
                Console.WriteLine(
@"Please enter the type of your vehicle (can be on of the {0} options): ",
                    numberOfSupportedVechicle);
                int i;
                for (i = 1; i < numberOfVehicleTypes; i++)
                {
                    Console.Write("{0}, ", (Builder.eVehicle)i);
                }

                Console.WriteLine("{0}", (Builder.eVehicle)i);
                typeOfVehicle = Console.ReadLine();
                typeOfVehicle = parseString(typeOfVehicle);

                isValidType = Garage.CheckVehicleType(typeOfVehicle);
                if (!isValidType)
                {
                    Console.WriteLine("Invalid type. Please try again.");
                }
            }

            return typeOfVehicle;
        }

        /// <summary>
        /// Load relevant power source.
        /// </summary>
        /// <param name="i_Operation">Amount of power source to add.</param>
        private static void loadPowerSourceForVehicle(eOperation i_Operation)
        {
            try
            {
                string licenseNumber = getLicenseNumberFromUser();
                Garage.VehicleInGarage currentVehicle = s_Garage.FindVehicleByLicense(licenseNumber);
                if (currentVehicle.OwnerName == null)
                {
                    Console.WriteLine(k_VehicleNotFound);
                }
                else
                {
                    bool isRelevantEngine = currentVehicle.CurrVehicle.IsElectric
                        ? i_Operation == eOperation.LoadEnergy
                        : i_Operation == eOperation.LoadFuel;
                    if (isRelevantEngine)
                    {
                        string fuelType = null;
                        bool isFuel = i_Operation == eOperation.LoadFuel;
                        if (isFuel)
                        {
                            fuelType = GetFuelFromUser();
                        }

                        Console.WriteLine("Current amount is: {0}", currentVehicle.CurrVehicle.PowerSource.CurrAmount);
                        float amountInFloat = getAmountToLoad();
                        Garage.LoadPowerSourceForVehicle(currentVehicle.CurrVehicle, amountInFloat, fuelType);
                        Console.WriteLine(k_PowerSourceLoadingSuccess);
                    }
                    else
                    {
                        Console.WriteLine("The vehicle engine doesn't match the required operation.");
                    }
                }
            }
            catch (ValueOutOfRangeException vaore)
            {
                Console.WriteLine(vaore.Message);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Load fuel.
        /// </summary>
        /// <returns>Success message.</returns>
        public static string GetFuelFromUser()
        {
            bool isLegalFuel = false;
            string fuelType = null;
            while (!isLegalFuel)
            {
                Console.Write("Please enter fuel type to load: ");
                fuelType = Console.ReadLine();
                isLegalFuel = Fuel.IsValidFuelType(fuelType);
                if (!isLegalFuel)
                {
                    Console.WriteLine("Fuel type does not exists. Please try again.");
                }
            }

            return fuelType;
        }

        /// <summary>
        /// Get the amount of power source to load.
        /// </summary>
        /// <returns>Amount to load.</returns>
        private static float getAmountToLoad()
        {
            bool isValidNumber = false;
            float amountInFloat = 0;
            while (!isValidNumber)
            {
                Console.Write("Please enter the amount you want to load: ");
                string amountToLoad = Console.ReadLine();
                isValidNumber = float.TryParse(amountToLoad, out amountInFloat);
                if (!isValidNumber)
                {
                    Console.WriteLine("This is not a number. Let's try again.");
                }
            }

            return amountInFloat;
        }

        /// <summary>
        /// Inflate all tires in vehicle.
        /// </summary>
        private static void blowAirForVehicle()
        {
            string licenseNumber = getLicenseNumberFromUser();
            Garage.VehicleInGarage currentVehicle = s_Garage.FindVehicleByLicense(licenseNumber);
            if (currentVehicle.CurrVehicle != null)
            {
                Garage.BlowAirForVehicel(currentVehicle.CurrVehicle);
                Console.WriteLine(k_AirBlowSuccess);
            }
            else
            {
                Console.WriteLine(k_VehicleNotFound);
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Change vehicle state.
        /// </summary>
        private static void changeVehicleState()
        {
            string newStatus = null;
            bool isStatusExists = false;
            string licenseNumber = getLicenseNumberFromUser();
            string currentVehicleStatus = s_Garage.FindVehicleStatus(licenseNumber);
            if (currentVehicleStatus == null)
            {
                Console.WriteLine(k_VehicleNotFound);
                Console.ReadLine();
            }
            else
            {
                while (!isStatusExists)
                {
                    Console.WriteLine(@"The current status of the vehicle is: {0}", currentVehicleStatus);
                    Console.WriteLine("Please enter the new status that you want for the vehilce: ");
                    Console.Write("The options are: ");
                    int j;
                    int numberOfstates = Enum.GetNames(typeof(Garage.eStateInGarage)).Length;
                    for (j = 1; j < numberOfstates; j++)
                    {
                        Console.Write("{0}, ", (Garage.eStateInGarage)j);
                    }

                    Console.WriteLine("{0}", (Garage.eStateInGarage)j);

                    newStatus = Console.ReadLine();
                    isStatusExists = Garage.CheckIfStatusIsExists(newStatus);
                    if (!isStatusExists)
                    {
                        Console.WriteLine("Invalid status. let's try again");
                    }
                }

                s_Garage.ChangeVehicleStatus(licenseNumber, newStatus);
                Console.WriteLine("Status changed successfuly");
            }
        }

        /// <summary>
        /// Get vehicle information by license.
        /// </summary>
        private static void showVehiclesByLicense()
        {
            try
            {
                Console.WriteLine("Do you want to filter by Status in garage? <yes/no>");
                string answer = Console.ReadLine();
                string status = null;
                if (answer == "yes")
                {
                    status = getStatusFromUser();
                    Console.WriteLine("The current vehicles in the garage (filtered by {0}) are:", status);
                }
                else
                {
                    Console.WriteLine("The current vehicles in the garage are:");
                    Console.WriteLine();
                }

                Dictionary<string, string> licenseAndState = s_Garage.GetAllVehiclesByLicense(status);
                int i = 1;
                foreach (string licenseNumber in licenseAndState.Keys)
                {
                    Console.WriteLine(@"{0}: License number: {1}. Current state: {2}", i, licenseNumber, licenseAndState[licenseNumber]);
                    i++;
                }

                Console.WriteLine();
                Console.WriteLine("Press 'enter' to continue");
                Console.ReadLine();
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                Console.WriteLine("Press any key to try again");
                Console.ReadLine();
                showVehiclesByLicense();
            }
        }

        /// <summary>
        /// Get status of the vehicle from the user.
        /// </summary>
        /// <returns>Status of the vehicle</returns>
        private static string getStatusFromUser()
        {
            Console.WriteLine("Please enter status to filter by: ");
            Console.Write("The options are: ");
            int j;
            int numberOfstates = Enum.GetNames(typeof(Garage.eStateInGarage)).Length;
            for (j = 1; j < numberOfstates; j++)
            {
                Console.Write("{0}, ", (Garage.eStateInGarage)j);
            }

            Console.WriteLine("{0}", (Garage.eStateInGarage)j);
            string status = Console.ReadLine();
            return status;
        }

        /// <summary>
        /// Get license number from the user.
        /// </summary>
        /// <returns>License number (string)</returns>
        private static string getLicenseNumberFromUser()
        {
            Console.Write("Please enter the vehicle license number: ");
            string lNumber = Console.ReadLine();

            /* this method exsits for future logic on license number */

            return lNumber;
        }

        /// <summary>
        /// Show relevant data for vehicle.
        /// </summary>
        private static void showDataForVehicle()
        {
            string lNumber = getLicenseNumberFromUser();
            Garage.VehicleInGarage lookForVehicle = s_Garage.FindVehicleByLicense(lNumber);

            if (lookForVehicle.CurrVehicle != null)
            {
                Console.WriteLine(lookForVehicle.ToString());
                Console.WriteLine(lookForVehicle.CurrVehicle.VehicleToString());
                Console.WriteLine();
                Console.WriteLine("Press 'enter' to continue");
            }
            else
            {
                Console.WriteLine(k_VehicleNotFound);
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Get valid operation from the user.
        /// </summary>
        /// <param name="i_ChosenOption">Operation to do </param>
        /// <returns>Number of operation.</returns>
        private static int getValidOperation(string i_ChosenOption)
        {
            bool isValid = false;
            int num = 0;

            while (!isValid)
            {
                bool isInputIsNumber = int.TryParse(i_ChosenOption, out num);
                if (isInputIsNumber)
                {
                    bool isNumberInRange = num <= 7 && num >= 1;
                    if (isNumberInRange)
                    {
                        isValid = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid number chosen, Please try again");
                        i_ChosenOption = Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input, Please try again");
                    i_ChosenOption = Console.ReadLine();
                }
            }

            return num;
        }

        /// <summary>
        /// Show all supported operation.
        /// </summary>
        public void RunOperations()
        {
            bool isExitCode = false;
            while (!isExitCode)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the garage");
                const string v_WelcomMessage = @"Please choose the desired option (number between 1 to 7):
1. Insert a vehicle to the garage
2. Show all the vehicles that now in the garage
3. Change vehicle state
4. Blow up tires (To Max)
5. Load a vehicle in fuel
6. Load a vehicle with energy
7. Show data on specific vehicle";
                Console.WriteLine(v_WelcomMessage);
                string chosenOption = Console.ReadLine();
                isExitCode = chosenOption == k_ExitCode;
                if (!isExitCode)
                {
                    int inputNumber = getValidOperation(chosenOption);
                    makeOperation(inputNumber);
                }
            }
        }

        /// <summary>
        /// Parse string to match eVehicle format.
        /// </summary>
        /// <param name="i_StringToParse">Input to parse</param>
        /// <returns>Valid string format</returns>
        private static string parseString(string i_StringToParse)
        {
            return (i_StringToParse == string.Empty) ? null : string.Format(char.ToUpper(i_StringToParse[0]) + i_StringToParse.Substring(1).ToLower());
        }

        /// <summary>
        /// The possible operations of the garage.
        /// </summary>
        public enum eOperation
        {
            /// <summary>
            /// Insert vehicle to garage.
            /// </summary>
            Insert = 1,

            /// <summary>
            /// Show car by license.
            /// </summary>
            ShowByLicence,

            /// <summary>
            /// Change current vehicle state.
            /// </summary>
            ChangeState,

            /// <summary>
            /// Inflate tires to max.
            /// </summary>
            BlowUp,

            /// <summary>
            /// Load fuel to vehicle.
            /// </summary>
            LoadFuel,

            /// <summary>
            /// Load energy to vehicle.
            /// </summary>
            LoadEnergy,

            /// <summary>
            /// Show all vehicles in garage.
            /// </summary>
            ShowData
        }
    }
}