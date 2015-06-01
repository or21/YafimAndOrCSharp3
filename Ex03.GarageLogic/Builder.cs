using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    /// <summary>
    /// Builds a complete vehicle
    /// </summary>
    public class Builder
    {
        // General fields for all viehicles
        private List<object> m_uniqueProperties;
        private eVehicle m_vehicle;
        private Vehicle vehicle;
        private Dictionary<string, object> m_vehicleDictionary;

        // Some helper variables
        private bool isElectric;
        private float m_currentAmountOfPowerSource;
        private float m_currentAmountOfAirPressure;
        private float m_maxAir;

        public Builder(eVehicle i_VehicleType)
        {
            // Generate new Vechile instance
            switch (i_VehicleType)
            {
                case eVehicle.Car:
                    this.vehicle = new Car();
                    break;
                case eVehicle.Motor:
                    this.vehicle = new Motor();
                    break;
                case eVehicle.Truk:
                    this.vehicle = new Truk();
                    break;

                // add more vehciles here
                    //TODO: DELETE
                case eVehicle.Traktor:
                    this.vehicle = new Traktor();
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
            get { return this.vehicle; }
        }
    }
}
