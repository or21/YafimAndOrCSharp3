using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Truk : Vehicle
    {
        private readonly bool m_isCarryingDangerous;
        private readonly float m_currentCarryWeight;

        private static readonly int m_numberOfWheels = 16;
        private static readonly float m_electricMaxAir = 0;
        private static readonly float m_fuelMaxAir = 31;

        private static readonly float m_energy = 0;
        private static readonly float m_fuel = (float)170;
        private static readonly Fuel.eFuelType m_fuelType = Fuel.eFuelType.Solar;

        public Truk(string iVehicleManufacturer, string iId, bool i_IsElectric, float i_CurrentAmountOfPowerSource, float i_CurrentAmountOfAir, string i_WheelManufacturer, bool i_IsCarryingDanerous, float i_CurrentCarryWeight)
            : base(iVehicleManufacturer, iId, i_CurrentAmountOfPowerSource, m_numberOfWheels, i_IsElectric, (i_IsElectric) ? m_electricMaxAir : m_fuelMaxAir, i_WheelManufacturer, (i_IsElectric) ? m_energy : m_fuel, m_fuelType)
        {
            // Set additional unique properties
            m_isCarryingDangerous = i_IsCarryingDanerous;
            m_currentCarryWeight = i_CurrentCarryWeight;
        }

        public float CurretCarryWeight
        {
            get { return this.m_currentCarryWeight; }
        }

        public bool IsCarryingDangerous
        {
            get { return this.m_isCarryingDangerous; }
        }
    }
}
