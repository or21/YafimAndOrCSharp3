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

        /// <summary>
        /// Gets or sets the number of doors.
        /// </summary>
        public eDoors Doors
        {
            get { return this.m_numberOfDoors; }
            set { this.m_numberOfDoors = value; }
        }

        /// <summary>
        /// Gets or sets the color of the car.
        /// </summary>
        public eColor Color
        {
            get { return this.m_color; }
            set { this.m_color = value; }
        }

        /// <summary>
        /// Set general and unique properties of this vehicle.
        /// </summary>
        public override void SetProperties()
        {
            base.SetProperties();
            Color = (eColor)Enum.Parse(typeof(eColor), (string)VehicleDictionary[r_colorQuestion]);
            Doors = (eDoors)Enum.Parse(typeof(eDoors), (string)VehicleDictionary[r_numberOfDoorsQuestion]);
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
                  this.m_numberOfDoors, 
                  this.m_color);

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
