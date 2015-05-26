using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Car : Vehicle
    {
        private Color m_Color;
        private int m_numberOfDoors;

        public Car(string i_Manufacturer, string i_Id, Color i_Color, int i_NumberOfDoors, bool i_IsElectric, float i_CurrentAmount)
        {
            this.manufacturer = i_Manufacturer;
            this.id = i_Id;

            this.powerSource = (i_IsElectric) ? new Energy(i_CurrentAmount, (float)2.2) : new Fuel(i_CurrentAmount, 35, Fuel.eFuelType.Octan96);
            this.powerSourceLeft = maxPower - i_CurrentAmount;

            this.wheels = new List<Wheel>(4);
            foreach (Wheel wheel in wheels)
            {
                wheel.MaxTirePressure = (float)31;
                wheel.Inflate(wheel.MaxTirePressure);
            }

            // Set additional unique properties
            this.m_Color = i_Color;
            this.m_numberOfDoors = i_NumberOfDoors;

        }


        public int Doors 
        {
            get { return this.m_numberOfDoors; }
        }

        public Color Color
        {
            get { return this.m_Color; }
        }


    }

    internal enum Color
    {
        Green,

        Black,

        Red,

        White
    };
}
