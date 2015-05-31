using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, VehicleInGarage> m_vehiclesInGarage;
        private Builder builder;

        public Garage()
        {
            m_vehiclesInGarage = new Dictionary<string, VehicleInGarage>();
        }

        public VehicleInGarage CreateVehicle(string i_Vehicle, string i_Id, string i_OwnerName, string i_PhoneNumber)
        {
            Builder.eVehicle vehicle = (Builder.eVehicle) Enum.Parse(typeof(Builder.eVehicle), i_Vehicle);
            builder = new Builder(vehicle);
            VehicleInGarage newVehicleInGarage = new VehicleInGarage
            {
                m_Vehicle = builder.Vehicle,
                m_State = eStateInGarage.InProcess,
                m_OwnerName = i_OwnerName,
                m_PhoneNumber = i_PhoneNumber
            };

            return newVehicleInGarage;
        }

        public void AddVehicle(VehicleInGarage i_NewVehicleInGarage)
        {
            i_NewVehicleInGarage.m_Vehicle.SetProperties();
            if (!m_vehiclesInGarage.ContainsKey(i_NewVehicleInGarage.m_Vehicle.m_id))
            {
                m_vehiclesInGarage.Add(i_NewVehicleInGarage.m_Vehicle.m_id, i_NewVehicleInGarage);
            }
        }

        public VehicleInGarage FindVehicleByLicense(string i_LicenseNumber)
        {
            VehicleInGarage currVehicle = new VehicleInGarage();
            bool isVehicleInGarage = m_vehiclesInGarage.ContainsKey(i_LicenseNumber);

            if (isVehicleInGarage)
            {
                currVehicle = m_vehiclesInGarage[i_LicenseNumber];
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
            if (!i_CurrentVehicle.IsElectric)
            {
                Fuel.eFuelType fuelType = (Fuel.eFuelType)Enum.Parse(typeof(Fuel.eFuelType), i_FuelType);
                ((Fuel)i_CurrentVehicle.m_powerSource).Load(i_AmountInFloat, fuelType);
            }
            else
            {
                (i_CurrentVehicle.m_powerSource).Load(i_AmountInFloat);
            }
        }

        public struct VehicleInGarage
        {
            public Vehicle m_Vehicle;
            public eStateInGarage m_State;
            public string m_OwnerName;
            public string m_PhoneNumber;

            public override string ToString()
            {
                string vehicleData = string.Format("Owner name: {0}\n", m_OwnerName);
                vehicleData += string.Format("Phone number: {0}", m_PhoneNumber);
                return vehicleData;
            }
        }

        public enum eStateInGarage
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
