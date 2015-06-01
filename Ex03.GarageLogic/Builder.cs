//----------------------------------------------------------------------
// <copyright file="Builder.cs" company="B15_Ex03">
// Yafim Vodkov 308973882 Or Brand 302521034
// </copyright>
//----------------------------------------------------------------------

namespace Ex03.GarageLogic
{
    /// <summary>
    /// Builds a complete vehicle
    /// </summary>
    public class Builder
    {
        /// <summary>
        /// Instance of vehicle.
        /// </summary>
        private readonly Vehicle r_Vehicle;

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
                case eVehicle.Truck:
                    this.r_Vehicle = new Truck();
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
            /// Vehicle Truck
            /// </summary>
            Truck,

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
