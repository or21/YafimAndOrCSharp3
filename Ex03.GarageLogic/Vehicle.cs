using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    abstract class Vehicle
    {
        protected internal string manufacturer;
        protected internal string id;
        protected internal float powerSourceLeft;
        protected internal List<Wheel> wheels;

        protected internal Object powerSource;
        protected internal int maxPower;
        
    }

    class Wheel
    {
        private string manufacturer;
        private float currentTirePressure;
        private float maxTirePressure;

        public void Inflate(float airToAdd)
        {
            if (airToAdd > this.maxTirePressure)
            {
                // TODO: handle error to much air to add --> ValueOutOfRangeException
            }
            
            currentTirePressure = airToAdd;
        }

        public string Manufacturer
        {
            get { return manufacturer;}
            set { this.manufacturer = value; }
        }

        public float CurrentTirePressure
        {
            get { return this.currentTirePressure; }
        }

        public float MaxTirePressure
        {
            get { return this.maxTirePressure; }
            set { this.maxTirePressure = value; }
        }
    }
}
