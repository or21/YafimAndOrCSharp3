//----------------------------------------------------------------------
// <copyright file="Fuel.cs" company="B15_Ex03">
// Yafim Vodkov 308973882 Or Brand 302521034
// </copyright>
//----------------------------------------------------------------------
using System;

namespace Ex03.GarageLogic
{
    /// <summary>
    /// Fuel class.
    /// </summary>
    public class Fuel : Energy
    {
        /// <summary>
        /// Fuel type.
        /// </summary>
        private readonly eFuelType r_FuelType;

        /// <summary>
        /// Initializes a new instance of the Fuel class.
        /// </summary>
        /// <param name="i_CurrentAmount">Current amount of fuel</param>
        /// <param name="i_MaxAmount">Max amount of fuel</param>
        /// <param name="i_FuelType">Fuel type</param>
        public Fuel(float i_CurrentAmount, float i_MaxAmount, eFuelType i_FuelType) : base(i_CurrentAmount, i_MaxAmount)
        {
            this.r_FuelType = i_FuelType;
        }

        /// <summary>
        /// Checks if valid fuel type was given.
        /// </summary>
        /// <param name="i_FuelType">Fuel type</param>
        /// <returns>If valid fuel type</returns>
        public static bool IsValidFuelType(string i_FuelType)
        {
            object currentFuel = false;
            bool isEnumValue = true;
            try
            {
                currentFuel = Enum.Parse(typeof(eFuelType), i_FuelType);
            }
            catch (ArgumentException ae)
            {
                isEnumValue = false;
            }

            return isEnumValue;
        }

        /// <summary>
        /// Load vehicle with fuel.
        /// </summary>
        /// <param name="i_FuelToAdd">Fuel to add</param>
        /// <param name="i_FuelType">Fuel type</param>
        public void Load(float i_FuelToAdd, eFuelType i_FuelType)
        {
            bool isSameFuel = i_FuelType == this.r_FuelType;
            if (!isSameFuel)
            {
                throw new ArgumentException("Fuel type is not the same as vehicle fuel type.");
            }

            base.Load(i_FuelToAdd);
        }
        
        /// <summary>
        /// Fuel type.
        /// </summary>
        public enum eFuelType
        {
            /// <summary>
            /// Fuel type
            /// </summary>
            Octan96,

            /// <summary>
            /// Fuel type
            /// </summary>
            Octan95,

            /// <summary>
            /// Fuel type
            /// </summary>
            Octan98,

            /// <summary>
            /// Soler type
            /// </summary>
            Soler
        }
    }
}
