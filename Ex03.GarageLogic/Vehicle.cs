using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected internal string Manufacturer;
        protected internal string Id;

        protected internal float m_powerSourceLeft;
        protected internal object m_powerSource;
        protected internal int m_maxPower;
        protected internal bool m_isElectric;

        /// <summary>
        /// Wheels
        /// </summary>
        protected internal List<Wheel> m_wheels;

        /// <summary>
        /// Current amount of air
        /// </summary>
        protected internal float[] currentAmountOfAir;


        protected Vehicle(string i_Manufacturer,
                          string i_Id,
                          float i_CurrentAmountOfPowerSource,
                          int i_NumberOfWheels,
                          bool i_IsElectric,
                          float i_MaxAir,
                          string i_WheelManufacturer,
                          float i_PowerSourceType,
                          Fuel.eFuelType i_FuelType)
        {
            this.m_powerSource = i_IsElectric
                ? new Energy(i_CurrentAmountOfPowerSource, i_PowerSourceType)
                : new Fuel(i_CurrentAmountOfPowerSource, i_PowerSourceType, i_FuelType);

            this.m_isElectric = i_IsElectric;
            this.Manufacturer = i_Manufacturer;
            this.Id = i_Id;
            this.m_powerSourceLeft = m_maxPower - i_CurrentAmountOfPowerSource;

            currentAmountOfAir = new float[i_NumberOfWheels];

            InitWheels(ref currentAmountOfAir, i_MaxAir, i_WheelManufacturer, i_NumberOfWheels);
        }

        public void InitWheels(ref float[] i_CurrentAmountOfAir, float i_MaxTirePressure, string i_Manufacturer,
            int i_NumberOfWheels)
        {
            this.m_wheels = new List<Wheel>(i_NumberOfWheels);
            int currentTire = 0;

            // For each wheel set the relevant properties
            foreach (Wheel wheel in m_wheels)
            {
                wheel.Manufacturer = i_Manufacturer;
                wheel.MaxTirePressure = i_MaxTirePressure;
                wheel.CurrentTirePressure = i_CurrentAmountOfAir[currentTire];
                currentTire++;
            }
        }

        public object PowerSource
        {
            get { return this.m_powerSource; }
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
    
