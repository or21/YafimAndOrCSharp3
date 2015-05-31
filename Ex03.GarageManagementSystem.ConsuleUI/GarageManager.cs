using System;
using System.Collections.Generic;
using System.Linq;
using Ex03.GarageLogic;

namespace Ex03.GarageManagementSystem.ConsuleUI
{
    public class GarageManager
    {
        private const string v_ExitCode = "exit";
        private static Garage garage;

        public GarageManager()
        {
            garage = new Garage();
        }

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

        private static void insertVehicleToGarage()
        {
            try
            {
                string licenseNumber = getLicenseNumberFromUser();
                Garage.VehicleInGarage currentVehicle = garage.FindVehicleByLicense(licenseNumber);
                if (currentVehicle.m_Vehicle != null)
                {
                    Console.WriteLine(
@"This vehicle is already in the garage.
The system will change it's state to 'In Process'");
                    string status = "InProcess";
                    garage.ChangeVehicleStatus(licenseNumber, status);
                }
                else
                {
                    string vehicleType = getTypeOfVehicleInformation();
                    string ownerName = getOwnerNameInformation();
                    string phoneNumber = getPhoneNumberInformation();
                    Garage.VehicleInGarage newVehicleInGarage = garage.CreateVehicle(vehicleType, licenseNumber,
                        ownerName, phoneNumber);
                    newVehicleInGarage.m_Vehicle.Id = licenseNumber;
                    fillParams(newVehicleInGarage);
                    garage.AddVehicle(newVehicleInGarage);
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(
@"There was an error in your input.
Try again to insert a vehicle");
                Console.ReadLine();
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
                Console.ReadLine();
        }
            catch (ValueOutOfRangeException vore)
            {
                Console.WriteLine(vore.Message);
                Console.ReadLine();
            }
            catch (NullReferenceException nre)
            {
                Console.WriteLine("Nothing was typed");
                Console.ReadLine();
            }

        }

        private static string getOwnerNameInformation()
        {
            bool waitingForInput = true;
            Console.Write("Please enter your name: ");
            string lNumber = "";

            while (waitingForInput)
            {
                lNumber = Console.ReadLine();
                if (containsOnlyChars(lNumber))
                {
                    waitingForInput = false;
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }
            return lNumber;
        }

        private static string getPhoneNumberInformation()
        {
            Console.Write("Please enter your phone number: ");
            string lNumber = Console.ReadLine();
            // TODO: some logic of phone number validity
            return lNumber;
        }

        private static void fillParams(Garage.VehicleInGarage i_NewVehicleInGarage)
        {
            for (int i = 0; i < i_NewVehicleInGarage.m_Vehicle.VehicleDictionary.Count; i++)
            {
                string key = i_NewVehicleInGarage.m_Vehicle.VehicleDictionary.ElementAt(i).Key;
                Console.Write(key + ": ");
                string input = Console.ReadLine();
                i_NewVehicleInGarage.m_Vehicle.VehicleDictionary[key] = input;
            }
        }

        private static string getTypeOfVehicleInformation()
        {
            bool isValidType = false;
            string typeOfVehicle = null;
            int numberOfVehicleTypes = sizeof(Builder.eVehicle);
            while (!isValidType)
            {
                int numberOfSupportedVechicle = Enum.GetNames(typeof (Builder.eVehicle)).Length;

                Console.WriteLine(@"Please enter the type of your vehicle (can be on of the {0} options): ",
                    numberOfSupportedVechicle);
                int i;
                for (i = 1; i < numberOfVehicleTypes - 1; i++)
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

        private static void loadPowerSourceForVehicle(eOperation i_Operation)
        {
            //TODO: add check if the load is for the real power source
            string licenseNumber = getLicenseNumberFromUser();
            Garage.VehicleInGarage currentVehicle = garage.FindVehicleByLicense(licenseNumber);
            string fuelType = null;
            bool isFuel = i_Operation == eOperation.LoadFuel;
            if (isFuel)
            {
                bool isLegalFuel = false;
                while (!isLegalFuel)
                {
                    fuelType = GetFuelFromUser();
                    isLegalFuel = Fuel.IsValidFuelType(fuelType);
                    if (!isLegalFuel)
                    {
                        Console.WriteLine("Fuel type does not exists. Please try again.");
                    }
                }
            }

            float amountInFloat = getAmountToLoad();
            Garage.LoadPowerSourceForVehicle(currentVehicle.m_Vehicle, amountInFloat, fuelType);
        }

        public static string GetFuelFromUser()
        {
            Console.Write("Please enter fuel type to load: ");
            string resultType = Console.ReadLine();

            return resultType;
        }

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

        private static void blowAirForVehicle()
        {
            string licenseNumber = getLicenseNumberFromUser();
            Garage.VehicleInGarage currentVehicle = garage.FindVehicleByLicense(licenseNumber);
            Garage.BlowAirForVehicel(currentVehicle.m_Vehicle);
            Console.WriteLine("Air blowed successfuly");
            Console.WriteLine("Press 'enter' to continue");
            Console.ReadLine();
        }

        private static void changeVehicleState()
        {
            string newStatus = null;
            bool isStatusExists = false;
            string licenseNumber = getLicenseNumberFromUser();
            string currentVehicleStatus = garage.FindVehicleStatus(licenseNumber);

            while (!isStatusExists)
            {
                Console.WriteLine(@"The current status of the vehicle is: {0}", currentVehicleStatus);
                Console.WriteLine("Please enter the new status that you want for the vehilce: ");
                Console.Write("The options are: ");
                int j;
                for (j = 1; j < sizeof(Garage.eStateInGarage) - 1; j++)
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

            garage.ChangeVehicleStatus(licenseNumber, newStatus);
            Console.WriteLine("Status changed successfuly");
        }

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

                Dictionary<string, string> licenseAndState = garage.GetAllVehiclesByLicense(status);
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

        private static string getStatusFromUser()
        {
            Console.WriteLine("Please enter status to filter by: ");
            Console.Write("The options are: ");
            int j;
            for (j = 1; j < sizeof(Garage.eStateInGarage) - 1; j++)
            {
                Console.Write("{0}, ", (Garage.eStateInGarage) j);
            }

            Console.WriteLine("{0}", (Garage.eStateInGarage) j);
            string status = Console.ReadLine();
            return status;
        }

        private static string getLicenseNumberFromUser()
        {
            Console.Write("Please enter the vehicle license number: ");
            string lNumber = Console.ReadLine();
            // TODO: some logic of license number validity
            return lNumber;
        }

        private static void showDataForVehicle()
        {
            string lNumber = getLicenseNumberFromUser();
            Garage.VehicleInGarage lookForVehicle = garage.FindVehicleByLicense(lNumber);

            if (lookForVehicle.m_Vehicle != null)
            {
                Console.WriteLine(lookForVehicle.ToString());
                Console.WriteLine(lookForVehicle.m_Vehicle.VehicleToString());
                Console.WriteLine();
                Console.WriteLine("Press 'enter' to continue");
                Console.ReadLine();
            }
        }

        private static int checkValidInput(string i_ChosenOption)
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
                isExitCode = chosenOption == v_ExitCode;
                if (!isExitCode)
                {
                    int inputNumber = checkValidInput(chosenOption);
                    makeOperation(inputNumber);
                }
            }
        }

        /// <summary>
        /// Checks if string contains only chars.
        /// </summary>
        /// <param name="i_StringToCheck">String to check</param>
        /// <returns>If valid or not</returns>
        private static bool containsOnlyChars(string i_StringToCheck)
        {
            bool isChar = false;

            for (int i = 0; i < i_StringToCheck.Length; i++)
            {
                isChar = char.IsLetter(i_StringToCheck[i]);
                if (!isChar)
                {
                    break;
                }
            }

            return isChar;
        }

        private static string parseString(string i_StringToParse)
        {
            return string.Format(char.ToUpper(i_StringToParse[0]) + i_StringToParse.Substring(1).ToLower());
        }

        public enum eOperation
        {
            Insert = 1,
            ShowByLicence,
            ChangeState,
            BlowUp,
            LoadFuel,
            LoadEnergy,
            ShowData
        }
    }
}