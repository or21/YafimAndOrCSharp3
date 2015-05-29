using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    class Truk : Vehicle
    {
        private readonly bool m_IsCarryingDangerous;
        private readonly float m_currentCarryWeight;

        private static readonly int m_numberOfWheels = 16;
        private static readonly float m_electricMaxAir = 0;
        private static readonly float m_fuelMaxAir = 31;

        private static readonly float m_energy = 0;
        private static readonly float m_fuel = (float)170;
        private static readonly Fuel.eFuelType m_fuelType = Fuel.eFuelType.Solar;

        public Truk(string i_VehicleManufacturer, string i_Id, bool i_IsElectric, float i_CurrentAmountOfPowerSource, float i_CurrentAmountOfAir, string i_WheelManufacturer, Color i_Color, int i_NumberOfDoors, bool i_isCarryingDanerous, float currentCarryWeight)
           // : base(i_VehicleManufacturer, i_Id, i_CurrentAmountOfPowerSource, m_numberOfWheels, i_IsElectric, m_electricMaxAir, m_fuelMaxAir, i_WheelManufacturer, m_energy, m_fuel, m_fuelType)
             : base(i_VehicleManufacturer, i_Id, i_CurrentAmountOfPowerSource, m_numberOfWheels, i_IsElectric, (i_IsElectric) ? m_electricMaxAir : m_fuelMaxAir, i_WheelManufacturer, (i_IsElectric) ? m_energy : m_fuel, m_fuelType)
        {

            // Set additional unique properties
            this.m_IsCarryingDangerous = i_isCarryingDanerous;
            this.m_currentCarryWeight = currentCarryWeight;
        }

        public float CurretCarryWeight
        {
            get { return this.m_currentCarryWeight; }
        }

        public bool IsCarryingDangerous
        {
            get { return this.m_IsCarryingDangerous; }
        }
    }
}
