using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected internal string m_manufacturer;
        protected internal string m_id;

        protected internal int m_numberOfWheels;
        protected internal float m_electricMaxAir;
        protected internal float m_fuelMaxAir;

        protected internal float m_curerntAmountOfPowerSource = -1;

        protected internal float m_maxEnergy;
        protected internal float m_maxFuel;

        protected internal Dictionary<string, object> m_vehicleDictionary;


        // TODO: initialze to null...
        protected internal Fuel.eFuelType m_fuelType;

        protected internal List<Wheel> m_wheels;
        protected internal Energy m_powerSource;
        protected internal bool m_isElectric;

        // Some helper variables
        private float m_currentAmountOfAirPressure;
        private float m_maxAir;
        private bool m_ValidValue;

        // TODO: 

        protected Vehicle()
        {
            createDictionary();
        }

        private void createDictionary()
        {
            this.m_vehicleDictionary = new Dictionary<string, object>();

            // Add general properties
            this.m_vehicleDictionary.Add("Manufacturer", null);
            this.m_vehicleDictionary.Add("Electric engine?", false);
            this.m_vehicleDictionary.Add("Current Amount Of Power Source", 0);
            this.m_vehicleDictionary.Add("Wheel Manufacturer", null);
            this.m_vehicleDictionary.Add("Current Amount Of Air Pressure", 0);
        }

        public Dictionary<string, object> VehicleDictionary
        {
            get { return this.m_vehicleDictionary; }
            // TODO: Validate input here...
        }

        public void setEngine(float i_MaxAmount, Fuel.eFuelType i_FuelType)
        {
            if (m_isElectric)
            {
                this.m_powerSource = new Energy(this.m_curerntAmountOfPowerSource, i_MaxAmount);
            }
            else
            {
                this.m_powerSource = new Fuel(this.m_curerntAmountOfPowerSource, i_MaxAmount, i_FuelType);
            }
        }

        public void InitWheels(float i_CurrentAmountOfAir, float i_MaxTirePressure, string i_Manufacturer,
            int i_NumberOfWheels)
        {
            this.m_wheels = new List<Wheel>(i_NumberOfWheels);

            for (int i = 0; i < i_NumberOfWheels; i++)
            {
                Wheel wheel = new Wheel
                {
                    Manufacturer = i_Manufacturer,
                    MaxTirePressure = i_MaxTirePressure,
                    CurrentTirePressure = i_CurrentAmountOfAir
                };
                m_wheels.Add(wheel);
            }
        }

        public virtual void SetProperties()
        {
            // Initialize Manufacturer and id
            Manufacturer = (string)VehicleDictionary["Manufacturer"];

            // Set the power source
            IsElectric = bool.Parse((string)VehicleDictionary["Electric engine?"]);

            this.m_curerntAmountOfPowerSource = float.Parse((string) VehicleDictionary["Current Amount Of Power Source"]);
            setEngine(MaxFuel, FuelType);

            m_currentAmountOfAirPressure = float.Parse((string)VehicleDictionary["Current Amount Of Air Pressure"]);
            m_maxAir = (IsElectric) ? ElectricMaxAir : FuelMaxAir;

            // Set the wheels
            InitWheels(m_currentAmountOfAirPressure, m_maxAir, (string)VehicleDictionary["Wheel Manufacturer"], NumberOfWheels);
        }

        // SOME GETTERS AND SETTERS

        public string Manufacturer
        {
            get { return this.m_manufacturer; }
            set { this.m_manufacturer = value; }
        }

        public string Id
        {
            get { return this.m_id; }
            set { this.m_id = value; }
        }

        public int NumberOfWheels
        {
            get { return this.m_numberOfWheels; }
            set { this.m_numberOfWheels = value; }
        }

        public float ElectricMaxAir
        {
            get { return this.m_electricMaxAir; }
            //set { this.m_electricMaxAir = value; }
            set
            {
                m_ValidValue = value <= this.m_electricMaxAir;
                if (m_ValidValue)
                {

                }
                else
                {
                    throw new ValueOutOfRangeException(new Exception(), ElectricMaxAir, 0);
                }
            }
        }

        public float FuelMaxAir
        {
            get { return this.m_fuelMaxAir; }
            set { this.m_fuelMaxAir = value; }
        }

        public float MaxEnergy
        {
            get { return this.m_maxEnergy; }
            set { this.m_maxEnergy = value; }
        }

        public float MaxFuel
        {
            get { return this.m_maxFuel; }
            set { this.m_maxFuel = value; }
        }

        public float CurerntAmountOfPowerSource
        {
            get { return this.m_curerntAmountOfPowerSource; }
            set { this.m_curerntAmountOfPowerSource = value; }
        }

        public Fuel.eFuelType FuelType
        {
            get { return this.m_fuelType; }
            set { this.m_fuelType = value; }
        }

        public bool IsElectric
        {
            get { return this.m_isElectric; }
            set { this.m_isElectric = value; }
        }

        // To string method
        public virtual string VehicleToString()
        {
            string dataToString = String.Format("License number: {0}\n", m_id);
            int i = 1;
            foreach (Wheel wheel in m_wheels)
            {
                dataToString += string.Format("Wheel {0}: Current air pressure: {1}, manufacturer: {2}\n", i,
                    wheel.CurrentTirePressure,
                    wheel.Manufacturer);
                i++;
            }
            dataToString += string.Format("Current amount of power source {0}\n", this.m_powerSource.CurrAmount);
            return dataToString;
        }
    }
}
    
