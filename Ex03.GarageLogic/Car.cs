namespace Ex03.GarageLogic
{
    class Car : Vehicle
    {
        private readonly Color m_color;
        private readonly int m_numberOfDoors;

        private static readonly int m_numberOfWheels = 4;
        private static readonly float m_electricMaxAir = 31;
        private static readonly float m_fuelMaxAir = 31;

        private static readonly float m_energy = (float)2.2;
        private static readonly float m_fuel = (float) 35;
        private static readonly Fuel.eFuelType m_fuelType = Fuel.eFuelType.Octan96;

        public Car(string i_VehicleManufacturer, string i_Id, bool i_IsElectric, float i_CurrentAmountOfPowerSource, float i_CurrentAmountOfAir, string i_WheelManufacturer, Color i_Color, int i_NumberOfDoors)
            : base(i_VehicleManufacturer, i_Id, i_CurrentAmountOfPowerSource, m_numberOfWheels, i_IsElectric, (i_IsElectric) ? m_electricMaxAir : m_fuelMaxAir, i_WheelManufacturer, (i_IsElectric) ? m_energy : m_fuel, m_fuelType)
        {
            // Set additional unique properties
            this.m_color = i_Color;
            this.m_numberOfDoors = i_NumberOfDoors;
        }

        public int Doors 
        {
            get { return this.m_numberOfDoors; }
        }

        public Color Color
        {
            get { return this.m_color; }
        }
    }

    internal enum Color
    {
        Green,

        Black,

        Red,

        White
    }
}
