using System;
using System.Collections.Generic;
using System.Text;

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
            }
        }

        public void CreateVehicle(eVehicle i_Vehicle, string i_VehicleManufacturer, string i_Id, bool i_IsElectric,
            float i_CurrentAmountOfPowerSource, float i_CurrentAmountOfAir, string i_WheelManufacturer,
            List<object> i_UniqueProperties)
        {
            List<object> m_uniqueProperties = new List<object>();
        }

        public enum eVehicle
        {

            Car = 1,

            Motor,

            Truk
            // add more supported vehicles here
        }

        public Vehicle Vehicle
        {
            get { return this.vehicle; }
        }
    }
}
