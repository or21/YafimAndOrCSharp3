using System;
using System.Collections.Generic;

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
        protected internal bool m_isElectric;

 //       protected Vehicle(string i_Manufacturer, string i_Id, float i_CurrentAmountOfPowerSource, int numberOfWheels, bool i_IsElectric, float i_ElectricCarMaxAir, float i_FuelCarMaxAir, string i_WheelManufacturer, float i_Energy, float i_Fuel, Fuel.eFuelType i_FuelType)
        protected Vehicle(string i_Manufacturer, string i_Id, float i_CurrentAmountOfPowerSource, int numberOfWheels, bool i_IsElectric, float i_MaxAir, string i_WheelManufacturer, float i_PowerSourceType, Fuel.eFuelType i_FuelType)
 
        {
            this.powerSource = (i_IsElectric) ? new Energy(i_CurrentAmountOfPowerSource, i_PowerSourceType) : new Fuel(i_CurrentAmountOfPowerSource, i_PowerSourceType, i_FuelType);
            
            this.m_isElectric = i_IsElectric;
            this.manufacturer = i_Manufacturer;
            this.id = i_Id;
            this.powerSourceLeft = maxPower - i_CurrentAmountOfPowerSource;

            float[] currentAmountOfAir = new float[numberOfWheels];

            initWheels(ref currentAmountOfAir, i_MaxAir, i_WheelManufacturer, numberOfWheels);


        }

        public void initWheels(ref float[] i_CurrentAmountOfAir, float i_MaxTirePressure, string i_Manufacturer, int numberOfWheels)
        {
            this.wheels = new List<Wheel>(numberOfWheels);
            int currentTire = 0;

            foreach (Wheel wheel in wheels)
            {
                wheel.Manufacturer = i_Manufacturer;
                wheel.MaxTirePressure = i_MaxTirePressure;
                wheel.CurrentTirePressure = i_CurrentAmountOfAir[currentTire];
                currentTire++;
            }
        }
    }

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
            
            this.currentTirePressure += airToAdd;
            if (this.CurrentTirePressure > this.MaxTirePressure)
            {
                this.CurrentTirePressure = this.MaxTirePressure;
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
            set { this.CurrentTirePressure = value; }
        }

        public float MaxTirePressure
        {
            get { return this.maxTirePressure; }
            set { this.maxTirePressure = value; }
        }
    }
}
