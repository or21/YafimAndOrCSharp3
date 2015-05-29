using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, VehicleInGarage> vehiclesInGarage;

        public Garage()
        {
            vehiclesInGarage = new Dictionary<string, VehicleInGarage>();
        }

        public void AddVehicle(Vehicle i_Vehicle)
        {
            VehicleInGarage newVehicleInGarage = new VehicleInGarage();
            newVehicleInGarage.m_Vehicle = i_Vehicle;
            newVehicleInGarage.m_State = eStateInGarage.InProcess;
        
            if (!vehiclesInGarage.ContainsKey(i_Vehicle.Id))
            {
                vehiclesInGarage.Add(i_Vehicle.Id, newVehicleInGarage);
            }
        }

        public Vehicle FindVehicleByLicense(string i_LicenseNumber)
        {
            VehicleInGarage currVehicle = vehiclesInGarage[i_LicenseNumber];
            return currVehicle.m_Vehicle;
        }

        public string FindVehicleStatus(string i_LicenseNumber)
        {
            VehicleInGarage currVehicle = vehiclesInGarage[i_LicenseNumber];
            return currVehicle.m_State.ToString();
        }

        public Dictionary<string, string> GetAllVehiclesByLicense()
        {
            Dictionary<string, string> resultList = new Dictionary<string, string>();
            foreach (string licenseNumber in vehiclesInGarage.Keys)
            {
                resultList.Add(licenseNumber, vehiclesInGarage[licenseNumber].m_State.ToString());
            }

            return resultList;
        }

        public static bool CheckIfStatusIsExists(string i_Status)
        {
            object currentState = Enum.Parse(typeof(eStateInGarage), i_Status);
            bool isEnumValue = currentState is eStateInGarage;
            return isEnumValue;
        }

        public static void BlowAirForVehicel(Vehicle i_CurrentVehicle)
        {
            foreach (Wheel wheel in i_CurrentVehicle.m_wheels)
            {
                wheel.Inflate(wheel.MaxTirePressure - wheel.CurrentTirePressure);
            }
        }

        public static void LoadPowerSourceForVehicle(Vehicle i_CurrentVehicle, float i_AmountInFloat, string i_FuelType)
        {
            bool isFuel = i_CurrentVehicle.PowerSource is Fuel;
            if (isFuel)
            {
                Fuel.eFuelType fuelType = (Fuel.eFuelType) Enum.Parse(typeof(Fuel.eFuelType), i_FuelType);
                ((Fuel)i_CurrentVehicle.PowerSource).Load(i_AmountInFloat, fuelType);
            }
            else
            {
                ((Energy)i_CurrentVehicle.PowerSource).Load(i_AmountInFloat);
            }
        }

        internal struct VehicleInGarage
        {
            internal Vehicle m_Vehicle;
            internal eStateInGarage m_State;
        }

        internal enum eStateInGarage
        {
            InProcess,
            Fixed,
            Paied
        }
    }
}
