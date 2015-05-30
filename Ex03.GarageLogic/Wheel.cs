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
            // TODO: Exception...
            try
            {
                this.currentTirePressure = airToAdd;
            }
            catch (ValueOutOfRangeException vore)
            {
                throw new ValueOutOfRangeException(new IndexOutOfRangeException(), this.maxTirePressure, 0);
            }
        }

        public string Manufacturer
        {
            get { return manufacturer; }
            set { this.manufacturer = value; }
        }

        public float CurrentTirePressure
        {
            get { return this.currentTirePressure; }
            set {
                if (value > this.maxTirePressure)
                {
                    this.currentTirePressure = value;
                }
                else
                {
                    throw new ValueOutOfRangeException(new IndexOutOfRangeException(), this.maxTirePressure, 0);
                }}
        }

        public float MaxTirePressure
        {
            get { return this.maxTirePressure; }
            set { this.maxTirePressure = value; }
        }
    }
}
