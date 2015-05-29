using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string manufacturer;
        private float currentTirePressure;
        private float maxTirePressure;

        public void Inflate(float airToAdd)
        {
            if (airToAdd > this.maxTirePressure)
            {
                // TODO: handle error "to much air to add" --> ValueOutOfRangeException
            }

            this.currentTirePressure = airToAdd;
        }

        public string Manufacturer
        {
            get { return manufacturer; }
            set { this.manufacturer = value; }
        }

        public float CurrentTirePressure
        {
            get { return this.currentTirePressure; }
            set { CurrentTirePressure = value; }
        }

        public float MaxTirePressure
        {
            get { return this.maxTirePressure; }
            set { this.maxTirePressure = value; }
        }
    }
}
