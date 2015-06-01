//----------------------------------------------------------------------
// <copyright file="Builder.cs" company="B15_Ex03">
// Yafim Vodkov 308973882 Or Brand 302521034
// </copyright>
//----------------------------------------------------------------------
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    /// <summary>
    /// Builds a complete vehicle
    /// </summary>
    public class Builder
    {
        /* General fields for all viehicles */

        /// <summary>
        /// Unique properties of the vehicle.
        /// </summary>
        private List<object> m_uniqueProperties;

        /// <summary>
        /// Vehicle type.
        /// </summary>
        private eVehicle m_vehicle;

        /// <summary>
        /// Instance of vehicle.
        /// </summary>
        private Vehicle vehicle;

        /// <summary>
        /// The form to be filled by the user.
        /// </summary>
        private Dictionary<string, object> m_vehicleDictionary;

        /* Some helper variables */

        /// <summary>
        /// If vehicle is electric.
        /// </summary>
        private bool isElectric;

        /// <summary>
        /// Current amount of power source.
        /// </summary>
        private float m_currentAmountOfPowerSource;

        /// <summary>
        /// Current amount of air pressure.
        /// </summary>
        private float m_currentAmountOfAirPressure;

        /// <summary>
        /// Max air in tires.
        /// </summary>
        private float m_maxAir;

        /// <summary>
        /// Initializes a new instance of the Builder class.
        /// </summary>
        /// <param name="i_VehicleType">Vehicle to create</param>
        public Builder(eVehicle i_VehicleType)
        {
            /* Generate new Vechile instance */
            switch (i_VehicleType)
            {
                case eVehicle.Car:
                    this.r_Vehicle = new Car();
                    break;
                case eVehicle.Motor:
                    this.r_Vehicle = new Motor();
                    break;
                case eVehicle.Truk:
                    this.r_Vehicle = new Truk();
                    break;

                /* Add more vehciles here */
            }
        }

        /// <summary>
        /// Supported vehicles in garage.
        /// </summary>
        public enum eVehicle
        {
            /// <summary>
            /// Vehicle Car
            /// </summary>
            Car = 1,

            /// <summary>
            /// Vehicle Motor
            /// </summary>
            Motor,

            /// <summary>
            /// Vehicle Truk
            /// </summary>
            Truk,

            /* add more supported vehicles here */
        }

        /// <summary>
        /// Gets current vehicle instance.
        /// </summary>
        public Vehicle Vehicle
        {
            get { return this.r_Vehicle; }
        }
    }
}
