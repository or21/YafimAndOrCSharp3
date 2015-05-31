using System;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private readonly string r_colorQuestion = "Color";
        private readonly string r_numberOfDoorsQuestion = "Number Of Doors";
        private eColor m_color;
        private eDoors m_numberOfDoors;

        public Car()
        {
            NumberOfWheels = 4;
            ElectricMaxAir = 31;
            FuelMaxAir = 31;
            MaxEnergy = (float)2.2;
            MaxFuel = (float)35;
            FuelType = Fuel.eFuelType.Octan96;

            r_colorQuestion += " <";
            int i;
            for (i = 1; i < Enum.GetNames(typeof(eColor)).Length; i++)
            {
                r_colorQuestion += (eColor)i + ", ";
            }

            r_colorQuestion += (eColor)i + ">";

            r_numberOfDoorsQuestion += " <";
            int j;
            for (j = 2; j < Enum.GetNames(typeof(eDoors)).Length + 1; j++)
            {
                r_numberOfDoorsQuestion += (eDoors)j + ", ";
            }

            r_numberOfDoorsQuestion += (eDoors)j + ">";

            m_VehicleDictionary.Add(r_colorQuestion, null);
            m_VehicleDictionary.Add(r_numberOfDoorsQuestion, null);
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
            Color = (eColor)Enum.Parse(typeof(eColor), (string)VehicleDictionary[r_colorQuestion]);
            Doors = (eDoors)Enum.Parse(typeof(eDoors), (string)VehicleDictionary[r_numberOfDoorsQuestion]);
        }

        public override string VehicleToString()
        {
            string carData = base.VehicleToString();

            if (!this.m_IsElectric)
            {
                carData += string.Format("Fuel type is {0}\n", Fuel.eFuelType.Octan96);
            }

            carData += string.Format(
@"Number of doors: {0}
Car color is: {1}", 
                  this.m_numberOfDoors, 
                  this.m_color);

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
