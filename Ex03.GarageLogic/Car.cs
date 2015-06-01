using System;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private readonly string r_ColorQuestion = "Color";
        private readonly string r_NumberOfDoorsQuestion = "Number Of Doors";
        private eColor m_Color;
        private eDoors m_NumberOfDoors;

        public Car()
        {
            NumberOfWheels = 4;
            ElectricMaxAir = 31;
            FuelMaxAir = 31;
            MaxEnergy = (float)2.2;
            MaxFuel = (float)35;
            FuelType = Fuel.eFuelType.Octan96;

            r_ColorQuestion += " <";
            int i;
            for (i = 1; i < Enum.GetNames(typeof(eColor)).Length; i++)
            {
                r_ColorQuestion += (eColor)i + ", ";
            }

            r_ColorQuestion += (eColor)i + ">";

            r_NumberOfDoorsQuestion += " <";
            int j;
            for (j = 2; j < Enum.GetNames(typeof(eDoors)).Length + 1; j++)
            {
                r_NumberOfDoorsQuestion += (eDoors)j + ", ";
            }

            r_NumberOfDoorsQuestion += (eDoors)j + ">";

            m_VehicleDictionary.Add(r_ColorQuestion, null);
            m_VehicleDictionary.Add(r_NumberOfDoorsQuestion, null);
        }

        // Some setters and getters
        public eDoors Doors
        {
            get { return this.m_NumberOfDoors; }
            set { this.m_NumberOfDoors = value; }
        }

        public eColor Color
        {
            get { return this.m_Color; }
            set { this.m_Color = value; }
        }

        public override void SetProperties()
        {
            base.SetProperties();
            Color = (eColor)Enum.Parse(typeof(eColor), (string)VehicleDictionary[r_ColorQuestion]);
            Doors = (eDoors)Enum.Parse(typeof(eDoors), (string)VehicleDictionary[r_NumberOfDoorsQuestion]);
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
                  this.m_NumberOfDoors, 
                  this.m_Color);

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
