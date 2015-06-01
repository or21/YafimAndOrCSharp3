//----------------------------------------------------------------------
// <copyright file="Car.cs" company="B15_Ex03">
// Yafim Vodkov 308973882 Or Brand 302521034
// </copyright>
//----------------------------------------------------------------------
using System;

namespace Ex03.GarageLogic
{
    /// <summary>
    /// Car class.
    /// </summary>
    public class Car : Vehicle
    {
        /// <summary>
        /// Unique property string.
        /// </summary>
        private readonly string r_colorQuestion = "Color";

        /// <summary>
        /// Unique property string.
        /// </summary>
        private readonly string r_numberOfDoorsQuestion = "Number Of Doors";

        /// <summary>
        /// Color of the car.
        /// </summary>
        private eColor m_color;

        /// <summary>
        /// Number of doors.
        /// </summary>
        private eDoors m_numberOfDoors;

        /// <summary>
        /// Initializes a new instance of the Car class.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the number of doors.
        /// </summary>
        public eDoors Doors
        {
            get { return this.m_NumberOfDoors; }
            set { this.m_NumberOfDoors = value; }
        }

        /// <summary>
        /// Gets or sets the color of the car.
        /// </summary>
        public eColor Color
        {
            get { return this.m_Color; }
            set { this.m_Color = value; }
        }

        /// <summary>
        /// Set general and unique properties of this vehicle.
        /// </summary>
        public override void SetProperties()
        {
            base.SetProperties();
            Color = (eColor)Enum.Parse(typeof(eColor), (string)VehicleDictionary[r_ColorQuestion]);
            Doors = (eDoors)Enum.Parse(typeof(eDoors), (string)VehicleDictionary[r_NumberOfDoorsQuestion]);
        }

        /// <summary>
        /// Gets the string output vehicle properties.
        /// </summary>
        /// <returns>Vehicle properties.</returns>
        public override string VehicleToString()
        {
            string carData = base.VehicleToString();

            if (!this.m_IsElectric)
            {
                carData += string.Format("Fuel type is {0}\n", FuelType);
            }

            carData += string.Format(
@"Number of doors: {0}
Car color is: {1}", 
                  this.m_NumberOfDoors, 
                  this.m_Color);

            return carData;
        }
    }

    /// <summary>
    /// Color type.
    /// </summary>
    public enum eColor
    {
        /// <summary>
        /// Green color.
        /// </summary>
        Green = 1,

        /// <summary>
        /// Black color.
        /// </summary>
        Black,

        /// <summary>
        /// Red color.
        /// </summary>
        Red,

        /// <summary>
        /// White color.
        /// </summary>
        White
    }

    /// <summary>
    /// Number of the doors.
    /// </summary>
    public enum eDoors
    {
        /// <summary>
        /// Two doors.
        /// </summary>
        Two = 2,

        /// <summary>
        /// Three doors.
        /// </summary>
        Three,

        /// <summary>
        /// Four doors.
        /// </summary>
        Four,

        /// <summary>
        /// Five doors.
        /// </summary>
        Five
    }
}
