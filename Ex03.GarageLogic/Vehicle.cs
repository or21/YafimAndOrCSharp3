//----------------------------------------------------------------------
// <copyright file="Vehicle.cs" company="B15_Ex03">
// Yafim Vodkov 308973882 Or Brand 302521034
// </copyright>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    /// <summary>
    /// Vehicle class
    /// </summary>
    public abstract class Vehicle
    {
        /// <summary>
        /// Property string.
        /// </summary>
        private const string k_ManufacQuestion = "Manufacturer";

        /// <summary>
        /// Property string.
        /// </summary>
        private const string k_IsElecQuestion = "Electric engine? <true/false>";

        /// <summary>
        /// Property string.
        /// </summary>
        private const string k_AmountPSQuestion = "Current Amount Of Power Source";

        /// <summary>
        /// Property string.
        /// </summary>
        private const string k_WheelManufacQuestion = "Wheel Manufacturer";

        /// <summary>
        /// Property string.
        /// </summary>
        private const string k_CurrAmounAirQuestion = "Current Amount Of Air Pressure";

        /// <summary>
        /// Vehicle's manufacturer.
        /// </summary>
        protected internal string m_Manufacturer;

        /// <summary>
        /// Vehicle's id number.
        /// </summary>
        protected internal string m_Id;

        /// <summary>
        /// Vehicle's number of wheel
        /// </summary>
        protected internal int m_NumberOfWheels;

        /// <summary>
        /// Electric vehicle max air pressure.
        /// </summary>
        protected internal float m_ElectricMaxAir;

        /// <summary>
        /// Fuel vehicle max air pressure.
        /// </summary>
        protected internal float m_FuelMaxAir;

        /// <summary>
        /// Electric vehicle max energy
        /// </summary>
        protected internal float m_MaxEnergy;

        /// <summary>
        /// Fuel vehicle max fuel
        /// </summary>
        protected internal float m_MaxFuel;

        /// <summary>
        /// Vehicle's properties.
        /// </summary>
        protected internal Dictionary<string, object> m_VehicleDictionary;

        /// <summary>
        /// Vehicle's fuel type.
        /// </summary>
        protected internal Fuel.eFuelType m_FuelType;

        /// <summary>
        /// Vehicle's wheels.
        /// </summary>
        protected internal List<Wheel> m_Wheels;

        /// <summary>
        /// Vehicle's power source
        /// </summary>
        protected internal Energy m_PowerSource;

        /// <summary>
        /// Engine type
        /// </summary>
        protected internal bool m_IsElectric;

        /// <summary>
        /// Vehicle can have elctric engine
        /// </summary>
        protected internal bool m_HasElectricEngineOption;

        /// <summary>
        /// Vehicle can have fuel engine
        /// </summary>
        protected internal bool m_HasFuelEngineOption;

        /// <summary>
        /// Current vehicle max air pressure.
        /// </summary>
        private float m_MaxAir;

        /// <summary>
        /// Initializes a new instance of the Vehicle class
        /// </summary>
        protected Vehicle()
        {
            createDictionary();
        }

        /// <summary>
        /// Create general properties for vehicle.
        /// </summary>
        private void createDictionary()
        {
            this.m_VehicleDictionary = new Dictionary<string, object>();

            // Add general properties
            this.m_VehicleDictionary.Add(k_ManufacQuestion, null);
            this.m_VehicleDictionary.Add(k_IsElecQuestion, false);
            this.m_VehicleDictionary.Add(k_AmountPSQuestion, 0);
            this.m_VehicleDictionary.Add(k_WheelManufacQuestion, null);
            this.m_VehicleDictionary.Add(k_CurrAmounAirQuestion, 0);
        }

        /// <summary>
        /// Gets vehicle's properties.
        /// </summary>
        public Dictionary<string, object> VehicleDictionary
        {
            get { return this.m_VehicleDictionary; }
        }

        /// <summary>
        /// Sets engine.
        /// </summary>
        /// <param name="i_MaxAmount">Max amount of power source</param>
        /// <param name="i_FuelType">Fuel type</param>
        public void SetEngine(float i_MaxAmount, Fuel.eFuelType i_FuelType)
        {
            PowerSource = m_IsElectric ? new Energy(0, i_MaxAmount) : new Fuel(0, i_MaxAmount, i_FuelType);
        }

        /// <summary>
        /// Initialize wheels of the vehicle
        /// </summary>
        /// <param name="i_CurrentAmountOfAir">Current amount of air pressure</param>
        /// <param name="i_MaxTirePressure">Max air pressure</param>
        /// <param name="i_Manufacturer">Wheel manufacturer</param>
        /// <param name="i_NumberOfWheels">Number of wheels</param>
        public void InitWheels(float i_CurrentAmountOfAir, float i_MaxTirePressure, string i_Manufacturer, int i_NumberOfWheels)
        {
            this.m_Wheels = new List<Wheel>(i_NumberOfWheels);

            for (int i = 0; i < i_NumberOfWheels; i++)
            {
                Wheel wheel = new Wheel
                {
                    Manufacturer = i_Manufacturer,
                    MaxTirePressure = i_MaxTirePressure,
                    CurrentTirePressure = i_CurrentAmountOfAir
                };
                m_Wheels.Add(wheel);
            }
        }

        /// <summary>
        /// Set vehicle's properties.
        /// </summary>
        public virtual void SetProperties()
        {
            // Initialize Manufacturer and id
            Manufacturer = (string)VehicleDictionary[k_ManufacQuestion];

            // Set the power source
            IsElectric = bool.Parse((string)VehicleDictionary[k_IsElecQuestion]);
            float maxPowerSource = IsElectric ? MaxEnergy : MaxFuel;

            bool checkAvailableEngines = (HasElectOption && IsElectric) || (HasFuelOption && !IsElectric);
            if (checkAvailableEngines)
            {
                SetEngine(maxPowerSource, FuelType);
                PowerSource.CurrAmount = float.Parse((string) VehicleDictionary[k_AmountPSQuestion]);
            }
            else
            {
                throw new ArgumentException("Required engine is not supported by this vehicle.");
            }

            float currentAmountOfAirPressure = float.Parse((string)VehicleDictionary[k_CurrAmounAirQuestion]);
            m_MaxAir = IsElectric ? ElectricMaxAir : FuelMaxAir;

            // Set the wheels
            InitWheels(currentAmountOfAirPressure, m_MaxAir, (string)VehicleDictionary[k_WheelManufacQuestion], NumberOfWheels);
        }

        /// <summary>
        /// Gets or sets manufacturer
        /// </summary>
        public string Manufacturer
        {
            get { return this.m_Manufacturer; }
            set { this.m_Manufacturer = value; }
        }

        /// <summary>
        /// Gets or sets id.
        /// </summary>
        public string Id
        {
            get { return this.m_Id; }
            set { this.m_Id = value; }
        }

        /// <summary>
        /// Gets or sets number of wheels.
        /// </summary>
        public int NumberOfWheels
        {
            get { return this.m_NumberOfWheels; }
            set { this.m_NumberOfWheels = value; }
        }

        /// <summary>
        /// Gets or sets electric vehicle max air pressure.
        /// </summary>
        public float ElectricMaxAir
        {
            get { return this.m_ElectricMaxAir; }
            set { this.m_ElectricMaxAir = value; }
        }

        /// <summary>
        /// Gets or sets Fuel vehicle max air pressure.
        /// </summary>
        public float FuelMaxAir
        {
            get { return this.m_FuelMaxAir; }
            set { this.m_FuelMaxAir = value; }
        }

        /// <summary>
        /// Gets or sets max energy
        /// </summary>
        public float MaxEnergy
        {
            get { return this.m_MaxEnergy; }
            set { this.m_MaxEnergy = value; }
        }
        
        /// <summary>
        /// Gets or sets max fuel.
        /// </summary>
        public float MaxFuel
        {
            get { return this.m_MaxFuel; }
            set { this.m_MaxFuel = value; }
        }

        /// <summary>
        /// Gets or sets fuel type
        /// </summary>
        public Fuel.eFuelType FuelType
        {
            get { return this.m_FuelType; }
            set { this.m_FuelType = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether electric vehicle.
        /// </summary>
        public bool IsElectric
        {
            get { return this.m_IsElectric; }
            set { this.m_IsElectric = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether has electric engine option.
        /// </summary>
        public bool HasElectOption
        {
            get { return this.m_HasElectricEngineOption; }
            set { this.m_HasElectricEngineOption = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether has fuel engine option.
        /// </summary>
        public bool HasFuelOption
        {
            get { return this.m_HasFuelEngineOption; }
            set { this.m_HasFuelEngineOption = value; }
        }

        /// <summary>
        /// Gets or sets a the power source of the vehicle.
        /// </summary>
        public Energy PowerSource
        {
            get { return m_PowerSource; }
            set { m_PowerSource = value; }
        }

        /// <summary>
        /// Gets the string output vehicle properties.
        /// </summary>
        /// <returns>Vehicle properties.</returns>
        public virtual string VehicleToString()
        {
            string dataToString = string.Format("License number: {0}\n", m_Id);
            int i = 1;
            foreach (Wheel wheel in m_Wheels)
            {
                dataToString += string.Format(
"Wheel {0}: Current air pressure: {1}, manufacturer: {2}\n",
                    i,
                    wheel.CurrentTirePressure,
                    wheel.Manufacturer);
                i++;
            }

            dataToString += string.Format("Current amount of power source {0}\n", PowerSource.CurrAmount);

            return dataToString;
        }
    }
}
