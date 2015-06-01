using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    /// <summary>
    /// Builds a complete vehicle
    /// </summary>
    public class Builder
    {
        private readonly Vehicle r_Vehicle;

        public Builder(eVehicle i_VehicleType)
        {
            // Generate new Vechile instance
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

                // add more vehciles here
                    //TODO: DELETE
                case eVehicle.Traktor:
                    this.r_Vehicle = new Traktor();
                    break;
            }
        }

        public enum eVehicle
        {
            Car = 1,

            Motor,

            Truk,
            // add more supported vehicles here

            Traktor
        }

        public Vehicle Vehicle
        {
            get { return this.r_Vehicle; }
        }
    }
}
