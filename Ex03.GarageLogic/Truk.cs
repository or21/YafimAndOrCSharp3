using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Truk : Vehicle
    {
        private bool isCarryingDangerous;
        private float currentCarryWeight;

        public Truk(string manufacturer, string id, bool isCarryingDanerous, float currentCarryWeight)
        {
            this.manufacturer = manufacturer;
            this.id = id;

            this.wheels = new List<Wheel>(16);
            foreach (Wheel wheel in wheels)
            {
                wheel.MaxTirePressure = (float)25;
                wheel.Inflate(25);
            }

            //this.powerSource = new Fuel();
            //this.maxPower = this.fillPower(float 170, Fuel.Solar);
            this.powerSourceLeft = maxPower;

            // Set additional unique properties
            this.isCarryingDangerous = isCarryingDanerous;
            this.currentCarryWeight = currentCarryWeight;
        }

        public float CurretCarryWeight
        {
            get { return this.currentCarryWeight; }
        }

        public bool IsCarryingDangerous
        {
            get { return this.isCarryingDangerous; }
        }
    }
}
