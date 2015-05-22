using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    class Truk : Vehicle
    {
        private bool i_isCarryingDanerous;
        private float m_currentCarryWeight;

        public Truk(string manufacturer, string id, bool i_IsCarryingDanerous, float currentCarryWeight)
        {
            this.manufacturer = manufacturer;
            this.id = id;

            this.wheels = new List<Wheel>(16);
            foreach (Wheel wheel in wheels)
            {
                wheel.MaxTirePressure = (float)25;
                wheel.Inflate(25);
            }

            // TODO: define power source and fill
            //this.powerSource = new Fuel();
            //this.maxPower = this.fillPower(float 170, Fuel.Solar);
            this.powerSourceLeft = maxPower;

            // Set additional unique properties
            this.i_isCarryingDanerous = i_isCarryingDanerous;
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
