using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Car : Vehicle
    {
        private Color _iColor;
        private int m_numberOfDoors;

        public Car(string i_Manufacturer, string i_Id, Color i_Color, int i_NumberOfDoors, bool i_IsElectric)
        {
            this.manufacturer = i_Manufacturer;
            this.id = i_Id;

            this.wheels = new List<Wheel>(4);
            foreach (Wheel wheel in wheels)
            {
                wheel.MaxTirePressure = (float)31;
                wheel.Inflate(31);
            }

            //this.powerSource = (i_IsElectric) new Electric() : new Fuel();
            //this.maxPower = (i_IsElectric) ? (float)2.2 : this.fillPower(float 35, Fuel.Octan96);
            this.powerSourceLeft = maxPower;

            // Set additional unique properties
            this._iColor = i_Color;
            this.m_numberOfDoors = i_NumberOfDoors;

        }


        public int Doors 
        {
            get { return this.m_numberOfDoors; }
        }

        public Color IColor
        {
            get { return this._iColor; }
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
