using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected internal string Manufacturer;
        protected internal string Id;
        protected internal float m_powerSourceLeft;
        protected internal List<Wheel> m_wheels;
        protected internal object m_powerSource;
        protected internal int m_maxPower;
        protected internal bool m_isElectric;

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

            float[] currentAmountOfAir = new float[i_NumberOfWheels];

            initWheels(ref currentAmountOfAir, i_MaxAir, i_WheelManufacturer, i_NumberOfWheels);
        }

        public void initWheels(ref float[] i_CurrentAmountOfAir, float i_MaxTirePressure, string i_Manufacturer,
            int numberOfWheels)
        {
            this.m_wheels = new List<Wheel>(numberOfWheels);
            int currentTire = 0;

            foreach (Wheel wheel in m_wheels)
            {
                wheel.MManufacturer = i_Manufacturer;
                wheel.MMaxTirePressure = i_MaxTirePressure;
                wheel.MCurrentTirePressure = i_CurrentAmountOfAir[currentTire];
                currentTire++;
            }
        }
    }
}
    
