using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    class Motor : Vehicle
    {
        private License m_License;
        private int m_Engine;

        public Motor(string manufacturer, string id, bool isElectric, License i_License, int i_Engine)
        {
            this.id = id;
            this.manufacturer = manufacturer;

            // TODO: define power source and fill
            //this.powerSource = (isElectric) new Electric() : new Fuel();
            //this.maxPower = (isElectric) ? (float)2.2 : this.fillPower(float 8, Fuel.Octan98);
            this.powerSourceLeft = maxPower;

            this.wheels = new List<Wheel>(2);
            foreach (Wheel wheel in wheels)
            {
                wheel.MaxTirePressure = (float)2;
                wheel.Inflate(2);
            }

            // Set additional unique properties
            this.m_Engine = i_Engine;
            this.m_License = i_License;
        }

        public License License
        {
            get { return this.m_License; }
        }

        public int Engine
        {
            get { return this.m_Engine; }
        }
    }

    enum License
    {
        A,
        A2,
        AB,
        B1
    }
}
