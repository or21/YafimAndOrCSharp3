using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private eColor m_color;
        private int m_numberOfDoors;

        public Car(string i_Manufacturer, string i_Id, eColor i_Color, int i_NumberOfDoors, bool i_IsElectric, float i_CurrentAmount)
        {
            this.manufacturer = i_Manufacturer;
            this.id = i_Id;

            this.powerSource = i_IsElectric ? new Energy(i_CurrentAmount, (float)2.2) : new Fuel(i_CurrentAmount, 35, Fuel.eFuelType.Octan96);
            this.powerSourceLeft = maxPower - i_CurrentAmount;

            this.wheels = new List<Wheel>(4);
            foreach (Wheel wheel in wheels)
            {
                wheel.MaxTirePressure = (float)31;
                wheel.Inflate(wheel.MaxTirePressure);
            }

            // Set additional unique properties
            this.m_color = i_Color;
            this.m_numberOfDoors = i_NumberOfDoors;
        }

        public int Doors 
        {
            get { return this.m_numberOfDoors; }
        }

        public eColor Color
        {
            get { return this.m_color; }
        }
    }

    public enum eColor
    {
        Green,
        Black,
        Red,
        White
    }
}
