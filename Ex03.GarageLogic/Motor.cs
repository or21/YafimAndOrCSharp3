using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Motor : Vehicle
    {
        private eLicense m_license;
        private int m_engine;

        private static readonly int m_numberOfWheels = 2;

        private static readonly float m_electricMaxAir = 31;
        private static readonly float m_fuelMaxAir = 34;

        private static readonly float m_energy = (float)1.2;
        private static readonly float m_fuel = (float)8;
        private static readonly Fuel.eFuelType m_fuelType = Fuel.eFuelType.Octan98;

        public Motor(string i_VehicleManufacturer, string i_Id, bool i_IsElectric, float i_CurrentAmountOfPowerSource, float i_CurrentAmountOfAir, string i_WheelManufacturer, eLicense i_License, int i_Engine)
            : base(i_VehicleManufacturer, i_Id, i_CurrentAmountOfPowerSource, m_numberOfWheels, i_IsElectric, (i_IsElectric) ? m_electricMaxAir : m_fuelMaxAir, i_WheelManufacturer, (i_IsElectric) ? m_energy : m_fuel, m_fuelType)
                {
            // Set additional unique properties
            this.m_engine = i_Engine;
            this.m_license = i_License;
        }

        public eLicense License
        {
            get { return this.m_license; }
        }

        public int Engine
        {
            get { return this.m_engine; }
        }
    }

    public enum eLicense
    {
        A,
        A2,
        AB,
        B1
    }
}
