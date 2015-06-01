//----------------------------------------------------------------------
// <copyright file="Garage.cs" company="B15_Ex03">
// Yafim Vodkov 308973882 Or Brand 302521034
// </copyright>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    /// <summary>
    /// Garage class.
    /// </summary>
    public class Garage
    {
        /// <summary>
        /// All vehicles in garage.
        /// </summary>
        private Dictionary<string, VehicleInGarage> m_VehiclesInGarage;

        /// <summary>
        /// Instance of builder.
        /// </summary>
        private Builder m_Builder;

        /// <summary>
        /// Initializes a new instance of the Garage class.
        /// </summary>
        public Garage()
        {
            m_VehiclesInGarage = new Dictionary<string, VehicleInGarage>();
        }

        /// <summary>
        /// Check if status is exists.
        /// </summary>
        /// <param name="i_Status">Vehicle status</param>
        /// <returns>If exists or not</returns>
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

        /// <summary>
        /// Inflate tires.
        /// </summary>
        /// <param name="i_CurrentVehicle">Vehicle type</param>
        public static void BlowAirForVehicel(Vehicle i_CurrentVehicle)
        {
            foreach (Wheel wheel in i_CurrentVehicle.m_Wheels)
            {
                wheel.Inflate(wheel.MaxTirePressure - wheel.CurrentTirePressure);
            }
        }

        /// <summary>
        /// Load vehicle with specified power source.
        /// </summary>
        /// <param name="i_CurrentVehicle">Vehicle to load.</param>
        /// <param name="i_AmountInFloat">Amount of power source</param>
        /// <param name="i_FuelType">Fuel type</param>
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

        /// <summary>
        /// Check vehicle type.
        /// </summary>
        /// <param name="i_TypeOfVehicle">Type of the vehicle</param>
        /// <returns>If exists</returns>
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

        /// <summary>
        /// Create new vehicle instance.
        /// </summary>
        /// <param name="i_Vehicle">Vehicle to create</param>
        /// <param name="i_Id">Vehicle's id</param>
        /// <param name="i_OwnerName">Owner's name</param>
        /// <param name="i_PhoneNumber">Phone number</param>
        /// <returns>VehicleInGarage instance</returns>
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

        /// <summary>
        /// Add vehicle to garage.
        /// </summary>
        /// <param name="i_NewVehicleInGarage">New vehicle</param>
        public void AddVehicle(VehicleInGarage i_NewVehicleInGarage)
        {
            i_NewVehicleInGarage.CurrVehicle.SetProperties();
            if (!m_VehiclesInGarage.ContainsKey(i_NewVehicleInGarage.CurrVehicle.m_Id))
            {
                m_VehiclesInGarage.Add(i_NewVehicleInGarage.CurrVehicle.m_Id, i_NewVehicleInGarage);
            }
        }

        /// <summary>
        /// Find vehicle by license
        /// </summary>
        /// <param name="i_LicenseNumber">License number</param>
        /// <returns>VehicleInGarage instance</returns>
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

        /// <summary>
        /// Find vehicle status
        /// </summary>
        /// <param name="i_LicenseNumber">License number</param>
        /// <returns>The vehicle (string)</returns>
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

        /// <summary>
        /// Get all vehicles exist in garage and filter them
        /// </summary>
        /// <param name="i_FilterBy">Filer parameter</param>
        /// <returns>Filtered information</returns>
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

        /// <summary>
        /// Change vehicle status
        /// </summary>
        /// <param name="i_LicenseNumber">License number</param>
        /// <param name="i_NewStatus">New status to set</param>
        public void ChangeVehicleStatus(string i_LicenseNumber, string i_NewStatus)
        {
            object newState = Enum.Parse(typeof(eStateInGarage), i_NewStatus);

            VehicleInGarage currVehicle = m_VehiclesInGarage[i_LicenseNumber];
            currVehicle.State = (eStateInGarage)newState;
            m_VehiclesInGarage[i_LicenseNumber] = currVehicle;
        }

        /// <summary>
        /// Holds the vehicle's data
        /// </summary>
        public struct VehicleInGarage
        {
            /// <summary>
            /// Vehicle's type
            /// </summary>
            private Vehicle m_Vehicle;

            /// <summary>
            /// Vehicle's state
            /// </summary>
            private eStateInGarage m_State;

            /// <summary>
            /// Vehicle's owner name
            /// </summary>
            private string m_OwnerName;

            /// <summary>
            /// Owner's phone
            /// </summary>
            private string m_PhoneNumber;

            /// <summary>
            /// Get all vehicle's data
            /// </summary>
            /// <returns>Vehicle's data</returns>
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

            /// <summary>
            /// Gets or sets current vehicle
            /// </summary>
            public Vehicle CurrVehicle
            {
                get { return m_Vehicle; }
                set { m_Vehicle = value; }
            }

            /// <summary>
            /// Gets or sets vehicle's state
            /// </summary>
            public eStateInGarage State
            {
                get { return m_State; }
                set { m_State = value; }
            }

            /// <summary>
            /// Gets or sets owner name
            /// </summary>
            public string OwnerName
            {
                get { return m_OwnerName; }
                set { m_OwnerName = value; }
            }

            /// <summary>
            /// Gets or sets phone number
            /// </summary>
            public string PhoneNumber
            {
                get { return m_PhoneNumber; }
                set { m_PhoneNumber = value; }
            }
        }

        /// <summary>
        /// Vehicle's state in garage
        /// </summary>
        public enum eStateInGarage
        {
            /// <summary>
            /// Vehicle in process
            /// </summary>
            InProcess = 1,

            /// <summary>
            /// Vehicle fixed
            /// </summary>
            Fixed,

            /// <summary>
            /// Vehicle paid.
            /// </summary>
            Paid
        }
    }
}