using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, VehicleInGarage> m_VehiclesInGarage;
        private Builder m_Builder;

        public Garage()
        {
            m_VehiclesInGarage = new Dictionary<string, VehicleInGarage>();
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
            foreach (Wheel wheel in i_CurrentVehicle.m_Wheels)
            {
                wheel.Inflate(wheel.MaxTirePressure - wheel.CurrentTirePressure);
            }
        }

        public static void LoadPowerSourceForVehicle(Vehicle i_CurrentVehicle, float i_AmountInFloat, string i_FuelType)
        {
            if (!i_CurrentVehicle.IsElectric)
            {
                Fuel.eFuelType fuelType = (Fuel.eFuelType)Enum.Parse(typeof(Fuel.eFuelType), i_FuelType);
                ((Fuel)i_CurrentVehicle.m_PowerSource).Load(i_AmountInFloat, fuelType);
            }
            else
            {
                i_CurrentVehicle.m_PowerSource.Load(i_AmountInFloat);
            }
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

        public VehicleInGarage CreateVehicle(string i_Vehicle, string i_Id, string i_OwnerName, string i_PhoneNumber)
        {
            Builder.eVehicle vehicle = (Builder.eVehicle)Enum.Parse(typeof(Builder.eVehicle), i_Vehicle);
            m_Builder = new Builder(vehicle);
            VehicleInGarage newVehicleInGarage = new VehicleInGarage
            {
                CurrVehicle = m_Builder.Vehicle,
                State = eStateInGarage.InProcess,
                OwnerName = i_OwnerName,
                PhoneNumber = i_PhoneNumber
            };

            return newVehicleInGarage;
        }

        public void AddVehicle(VehicleInGarage i_NewVehicleInGarage)
        {
            i_NewVehicleInGarage.CurrVehicle.SetProperties();
            if (!m_VehiclesInGarage.ContainsKey(i_NewVehicleInGarage.CurrVehicle.m_Id))
            {
                m_VehiclesInGarage.Add(i_NewVehicleInGarage.CurrVehicle.m_Id, i_NewVehicleInGarage);
            }
        }

        public VehicleInGarage FindVehicleByLicense(string i_LicenseNumber)
        {
            VehicleInGarage currVehicle = new VehicleInGarage();
            bool isVehicleInGarage = m_VehiclesInGarage.ContainsKey(i_LicenseNumber);

            if (isVehicleInGarage)
            {
                currVehicle = m_VehiclesInGarage[i_LicenseNumber];
            }

            return currVehicle;
        }

        public string FindVehicleStatus(string i_LicenseNumber)
        {
            string status = null;
            bool isVehicleInGarage = m_VehiclesInGarage.ContainsKey(i_LicenseNumber);

            if (isVehicleInGarage)
            {
                status = m_VehiclesInGarage[i_LicenseNumber].State.ToString();
            }

            return status;
        }

        public Dictionary<string, string> GetAllVehiclesByLicense(string i_FilterBy)
        {
            eStateInGarage desiredState = eStateInGarage.InProcess;
            if (i_FilterBy != null)
            {
                desiredState = (eStateInGarage)Enum.Parse(typeof(eStateInGarage), i_FilterBy);
            }

            Dictionary<string, string> resultList = new Dictionary<string, string>();
            foreach (string licenseNumber in m_VehiclesInGarage.Keys)
            {
                bool isDesiredStatus = i_FilterBy == null || m_VehiclesInGarage[licenseNumber].State == desiredState;
                if (isDesiredStatus)
                {
                    resultList.Add(licenseNumber, m_VehiclesInGarage[licenseNumber].State.ToString());
                }
            }

            return resultList;
        }

        public void ChangeVehicleStatus(string i_LicenseNumber, string i_NewStatus)
        {
            object newState = Enum.Parse(typeof(eStateInGarage), i_NewStatus);

            VehicleInGarage currVehicle = m_VehiclesInGarage[i_LicenseNumber];
            currVehicle.State = (eStateInGarage)newState;
            m_VehiclesInGarage[i_LicenseNumber] = currVehicle;
        }

        public struct VehicleInGarage
        {
            private Vehicle m_Vehicle;
            private eStateInGarage m_State;
            private string m_OwnerName;
            private string m_PhoneNumber;

            public override string ToString()
            {
                string vehicleData = string.Format(
@"Owner name: {0}
Phone number: {1}
Current state in the Garage: {2}", 
                                 m_OwnerName, 
                                 m_PhoneNumber, 
                                 m_State);

                return vehicleData;
            }

            public Vehicle CurrVehicle
            {
                get { return m_Vehicle; }
                set { m_Vehicle = value; }
            }

            public eStateInGarage State
            {
                get { return m_State; }
                set { m_State = value; }
            }

            public string OwnerName
            {
                get { return m_OwnerName; }
                set { m_OwnerName = value; }
            }

            public string PhoneNumber
            {
                get { return m_PhoneNumber; }
                set { m_PhoneNumber = value; }
            }

        }

        public enum eStateInGarage
        {
            InProcess = 1,
            Fixed,
            Paied
        }
    }
}