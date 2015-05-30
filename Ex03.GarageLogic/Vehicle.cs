using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected internal string Manufacturer;
        protected internal string Id;

        protected internal float m_powerSourceLeft;
        protected internal List<Wheel> m_wheels;
        protected internal Energy m_powerSource;
        protected internal int m_maxPower;
        protected internal bool m_isElectric;
        protected internal float[] currentAmountOfAir;

        protected Vehicle(string i_Manufacturer,
                          string i_Id,
                          float i_CurrentAmountOfPowerSource,
                          int i_NumberOfWheels,
                          float i_CurrentAmountOfAir,
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

            InitWheels(i_CurrentAmountOfAir, i_MaxAir, i_WheelManufacturer, i_NumberOfWheels);
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

        public object PowerSource
        {
            get { return this.m_powerSource; }
        }

        public virtual string VehicleToString()
        {
            string dataToString = null;
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
    
