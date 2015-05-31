using System;
using System.Collections.Generic;
using System.Net;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, VehicleInGarage> m_vehiclesInGarage;
        private Builder builder;

        public Garage()
        {
            m_vehiclesInGarage = new Dictionary<string, VehicleInGarage>();
            builder = new Builder();
        }

        public void AddVehicle(string i_Vehicle, string i_VehicleManufacturer, string i_Id, bool i_IsElectric, float i_CurrentAmountOfPowerSource, float i_CurrentAmountOfAir, string i_WheelManufacturer, List<object> i_UniqueProperties)
        {
            object vehicle = Enum.Parse(typeof(Builder.eVehicle), i_Vehicle);
            VehicleInGarage newVehicleInGarage = new VehicleInGarage
            {
                m_Vehicle = builder.CreateVehicle((Builder.eVehicle)vehicle, i_VehicleManufacturer, i_Id, i_IsElectric, i_CurrentAmountOfPowerSource, i_CurrentAmountOfAir, i_WheelManufacturer, i_UniqueProperties),
                m_State = eStateInGarage.InProcess
            };

            if (!m_vehiclesInGarage.ContainsKey(newVehicleInGarage.m_Vehicle.m_id))
            {
                m_vehiclesInGarage.Add(newVehicleInGarage.m_Vehicle.m_id, newVehicleInGarage);
            }
        }

        public Vehicle FindVehicleByLicense(string i_LicenseNumber)
        {
            Vehicle currVehicle = null;
            bool isVehicleInGarage = m_vehiclesInGarage.ContainsKey(i_LicenseNumber);
            
            if (isVehicleInGarage)
            {
                currVehicle = m_vehiclesInGarage[i_LicenseNumber].m_Vehicle;
            }

            return currVehicle;
        }

        public string FindVehicleStatus(string i_LicenseNumber)
        {
            string status = null;
            bool isVehicleInGarage = m_vehiclesInGarage.ContainsKey(i_LicenseNumber);

            if (isVehicleInGarage)
            {
                status = m_vehiclesInGarage[i_LicenseNumber].m_State.ToString();
            }

            return status;
        }

        public Dictionary<string, string> GetAllVehiclesByLicense()
        {
            Dictionary<string, string> resultList = new Dictionary<string, string>();
            foreach (string licenseNumber in m_vehiclesInGarage.Keys)
            {
                resultList.Add(licenseNumber, m_vehiclesInGarage[licenseNumber].m_State.ToString());
            }

            return resultList;
        }

        public void ChangeVehicleStatus(string i_LicenseNumber, string i_NewStatus)
        {
            object newState = Enum.Parse(typeof(eStateInGarage), i_NewStatus);

            VehicleInGarage currVehicle = m_vehiclesInGarage[i_LicenseNumber];
            currVehicle.m_State = (eStateInGarage)newState;
            m_vehiclesInGarage[i_LicenseNumber] = currVehicle;
        }

        public static bool CheckIfStatusIsExists(string i_Status)
        {
            object currentState = false;
            bool isEnumValue = true;
            try
            {
                currentState = Enum.Parse(typeof(eStateInGarage), i_Status);
            }
            catch (ArgumentException ae)
            {
                isEnumValue = false;
            }

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
                Fuel.eFuelType fuelType = (Fuel.eFuelType)Enum.Parse(typeof(Fuel.eFuelType), i_FuelType);
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

        public static bool CheckVehicleType(string i_TypeOfVehicle)
        {
            object currentVehicle = false;
            bool isEnumValue = true;
            try
            {
                currentVehicle = Enum.Parse(typeof(Builder.eVehicle), i_TypeOfVehicle);
            }
            catch (ArgumentException ae)
            {
                isEnumValue = false;
            }

            return isEnumValue;
        }
    }
}
