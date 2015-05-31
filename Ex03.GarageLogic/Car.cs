using System;
using System.CodeDom;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private eColor m_color;
        private eDoors m_numberOfDoors;

        public Car()
        {
            base.NumberOfWheels = 4;
            base.ElectricMaxAir = 31;
            base.FuelMaxAir = 31;
            base.MaxEnergy = (float)2.2;
            base.MaxFuel = (float)35;
            base.FuelType = Fuel.eFuelType.Octan96;

            base.m_vehicleDictionary.Add("Color", null);
            base.m_vehicleDictionary.Add("Number Of Doors", null);
        }

        // Some setters and getters

        public eDoors Doors
        {
            get { return this.m_numberOfDoors; }
            set { this.m_numberOfDoors = value; }
        }

        public eColor Color
        {
            get { return this.m_color; }
            set { this.m_color = value; }
        }

        public override void SetProperties()
        {
            base.SetProperties();
            Color = (eColor) Enum.Parse(typeof(eColor), (string) base.VehicleDictionary["Color"]);
            Doors = (eDoors) Enum.Parse(typeof(eDoors), (string) base.VehicleDictionary["Number Of Doors"]);
        }

        public override string VehicleToString()
        {
            string carData = base.VehicleToString();

            if (!this.m_isElectric)
            {
                carData += string.Format("Fuel type is {0}\n", Fuel.eFuelType.Octan96);
            }
            carData += string.Format("Number of doors: {0}\n", this.m_numberOfDoors);
            carData += string.Format("Car color is: {0}\n", this.m_color);

            return carData;
        }
    }

    public enum eColor
    {
        Green = 1,
        Black,
        Red,
        White
    }


    public enum eDoors
    {
        Two = 2,

        Three,

        Four,

        Five
    }
}
