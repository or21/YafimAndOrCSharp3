using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Motor : Vehicle
    {
        private License m_license;
        private int m_engine;

        public Motor(string manufacturer, string id, bool i_IsElectric, License i_License, int i_Engine, float i_CurrentAmount)
        {
            this.id = id;
            this.manufacturer = manufacturer;

            this.powerSource = i_IsElectric ? new Energy(i_CurrentAmount, (float)1.2) : new Fuel(i_CurrentAmount, 8, Fuel.eFuelType.Octan98);
            this.powerSourceLeft = maxPower - i_CurrentAmount;

            this.wheels = new List<Wheel>(2);
            foreach (Wheel wheel in wheels)
            {
                if (i_IsElectric)
                {
                    wheel.MaxTirePressure = (float) 31;
                    wheel.Inflate(wheel.MaxTirePressure);
                }
                else
                {
                    wheel.MaxTirePressure = (float)34;
                    wheel.Inflate(wheel.MaxTirePressure);
                }
            }

            // Set additional unique properties
            this.m_engine = i_Engine;
            this.m_license = i_License;
        }

        public License License
        {
            get { return this.m_license; }
        }

        public int Engine
        {
            get { return this.m_engine; }
        }
    }

    public enum License
    {
        A,
        A2,
        AB,
        B1
    }
}
