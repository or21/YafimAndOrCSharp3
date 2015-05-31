using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private const string k_manufacQuestion = "Manufacturer";
        private const string k_isElecQuestion = "Electric engine? <true/false>";
        private const string k_amountPSQuestion = "Current Amount Of Power Source";
        private const string k_wheelManufacQuestion = "Wheel Manufacturer";
        private const string k_currAmounAirQuestion = "Current Amount Of Air Pressure";
        protected internal string m_Manufacturer;
        protected internal string m_Id;
        protected internal int m_NumberOfWheels;
        protected internal float m_ElectricMaxAir;
        protected internal float m_FuelMaxAir;
        protected internal float m_MaxEnergy;
        protected internal float m_MaxFuel;
        protected internal Dictionary<string, object> m_VehicleDictionary;
        protected internal Fuel.eFuelType m_FuelType;
        protected internal List<Wheel> m_Wheels;
        protected internal Energy m_PowerSource;
        protected internal bool m_IsElectric;
        private float m_maxAir;

        protected Vehicle()
        {
            createDictionary();
        }

        private void createDictionary()
        {
            this.m_VehicleDictionary = new Dictionary<string, object>();

            // Add general properties
            this.m_VehicleDictionary.Add(k_manufacQuestion, null);
            this.m_VehicleDictionary.Add(k_isElecQuestion, false);
            this.m_VehicleDictionary.Add(k_amountPSQuestion, 0);
            this.m_VehicleDictionary.Add(k_wheelManufacQuestion, null);
            this.m_VehicleDictionary.Add(k_currAmounAirQuestion, 0);
        }

        public Dictionary<string, object> VehicleDictionary
        {
            get { return this.m_VehicleDictionary; }
            // TODO: Validate input here...
        }

        public void setEngine(float i_MaxAmount, Fuel.eFuelType i_FuelType)
        {
            if (m_IsElectric)
            {
                this.m_PowerSource = new Energy(0, i_MaxAmount);
            }
            else
            {
                this.m_PowerSource = new Fuel(0, i_MaxAmount, i_FuelType);
            }
        }

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

        public virtual void SetProperties()
        {
            // Initialize Manufacturer and id
            Manufacturer = (string)VehicleDictionary[k_manufacQuestion];

            // Set the power source
            IsElectric = bool.Parse((string)VehicleDictionary[k_isElecQuestion]);

            setEngine(MaxFuel, FuelType);
            this.m_PowerSource.CurrAmount = float.Parse((string)VehicleDictionary[k_amountPSQuestion]);

            float currentAmountOfAirPressure = float.Parse((string)VehicleDictionary[k_currAmounAirQuestion]);
            m_maxAir = IsElectric ? ElectricMaxAir : FuelMaxAir;

            // Set the wheels
            InitWheels(currentAmountOfAirPressure, m_maxAir, (string)VehicleDictionary[k_wheelManufacQuestion], NumberOfWheels);
        }

        // SOME GETTERS AND SETTERS
        public string Manufacturer
        {
            get { return this.m_Manufacturer; }
            set { this.m_Manufacturer = value; }
        }

        public string Id
        {
            get { return this.m_Id; }
            set { this.m_Id = value; }
        }

        public int NumberOfWheels
        {
            get { return this.m_NumberOfWheels; }
            set { this.m_NumberOfWheels = value; }
        }

        public float ElectricMaxAir
        {
            get { return this.m_ElectricMaxAir; }
            set { this.m_ElectricMaxAir = value; }
        }

        public float FuelMaxAir
        {
            get { return this.m_FuelMaxAir; }
            set { this.m_FuelMaxAir = value; }
        }

        public float MaxEnergy
        {
            get { return this.m_MaxEnergy; }
            set { this.m_MaxEnergy = value; }
        }

        public float MaxFuel
        {
            get { return this.m_MaxFuel; }
            set { this.m_MaxFuel = value; }
        }

        public Fuel.eFuelType FuelType
        {
            get { return this.m_FuelType; }
            set { this.m_FuelType = value; }
        }

        public bool IsElectric
        {
            get { return this.m_IsElectric; }
            set { this.m_IsElectric = value; }
        }

        // To string method
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

            dataToString += string.Format("Current amount of power source {0}\n", this.m_PowerSource.CurrAmount);

            return dataToString;
        }
    }
}
