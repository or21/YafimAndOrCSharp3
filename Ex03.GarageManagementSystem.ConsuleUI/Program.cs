using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageManagementSystem.ConsuleUI
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Welcome to the garage");
            Console.WriteLine(@"Please choose the desired option (number between 1 to 7):
1. Insert a vehicle to the garage
2. Show all the vehicles that now in the garage
3. Change vehicle state
4. Blow up tires
5. Load a vehicle in fuel(To Max)
6. Load a vehicle with energy
7. Show data on specific vehicle");
            string chosenOption = Console.ReadLine();
            int inputNumber = checkValidInput(chosenOption);
            makeOperation(inputNumber);
        }

        private static void makeOperation(int i_InputNumber)
        {
            switch (i_InputNumber)
            {
                case ((int) eOperation.Insert):
                    insertVehicleToGarage();
                    break;
                case ((int) eOperation.ShowByLicence):
                    showVehicleByLicense();
                    break;
                case ((int) eOperation.ChangeState):
                    changeVehicleState();
                    break;
                case ((int) eOperation.BlowUp):
                    blowAirForVehicle();
                    break;
                case ((int) eOperation.LoadFuel):
                    loadFuelForVehicle();
                    break;
                case ((int) eOperation.LoadEnergy):
                    loadEnergyForVehicle();
                    break;
                case ((int) eOperation.ShowData):
                    showDataForVehicle();
                    break;
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