using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Truk : Vehicle
    {
        private bool m_isCarryingDanerous;
        private float m_currentCarryWeight;

        public Truk(string manufacturer, string id, bool i_IsCarryingDanerous, float currentCarryWeight, float i_CurrentAmount)
        {
            this.manufacturer = manufacturer;
            this.id = id;

            this.wheels = new List<Wheel>(16);
            foreach (Wheel wheel in wheels)
            {
                wheel.MaxTirePressure = (float)25;
                wheel.Inflate(wheel.MaxTirePressure);
            }

            this.powerSource = new Fuel(i_CurrentAmount, 170, Fuel.eFuelType.Solar);
            this.powerSourceLeft = maxPower - i_CurrentAmount;

            // Set additional unique properties
            this.m_isCarryingDanerous = i_IsCarryingDanerous;
            this.m_currentCarryWeight = currentCarryWeight;
        }

        public float CurretCarryWeight
        {
            get { return this.m_currentCarryWeight; }
        }

        public bool IsCarryingDangerous
        {
            get { return this.m_isCarryingDanerous; }
        }
    }
}
