using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Motor : Vehicle
    {
        private License license;
        private int engine;

        public Motor(string manufacturer, string id, bool isElectric, License license, int engine)
        {
            this.id = id;
            this.manufacturer = manufacturer;
            
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
            this.engine = engine;
            this.license = license;
        }

        public License License
        {
            get { return this.license; }
        }

        public int Engine
        {
            get { return this.engine; }
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
