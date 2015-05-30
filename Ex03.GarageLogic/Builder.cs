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
        // expected input format from user
   //     private string generalFormat = string.Format("Vehicle type, Vehicle Manufacturer, Id, Is Electric, Current Amount Of PowerSource, Current Amount Of Air, Wheel Manufacturer");
        private List<object> generalFormat = new List<object>();


        // General fields for all viehicles
        private List<object> m_uniqueProperties;
        private eVehicle m_vehicle;
        private Vehicle vehicle;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i_Vehicle">Current supported vehicle</param>
        /// <param name="i_VehicleManufacturer">Vehicle's manufacturer</param>
        /// <param name="i_Id">Vehicle's id</param>
        /// <param name="i_IsElectric">If electric</param>
        /// <param name="i_CurrentAmountOfPowerSource">Vehicle's current amount of powersource</param>
        /// <param name="i_CurrentAmountOfAir">Vehicle's current amount of air</param>
        /// <param name="i_WheelManufacturer">Vehicle's wheel manufactorer</param>
        /// <param name="i_UniqueProperties">Vehicle's unique properties</param>
        public void createVehicle(eVehicle i_Vehicle, string i_VehicleManufacturer, string i_Id, bool i_IsElectric, float i_CurrentAmountOfPowerSource, float i_CurrentAmountOfAir, string i_WheelManufacturer, List<object> i_UniqueProperties)
        {
            // Build specific vehecile
            switch (i_Vehicle)
            {
                case eVehicle.Car:
                    eColor color = (eColor) i_UniqueProperties[0];
                    int numberOfDoors = (int) i_UniqueProperties[1];
                    vehicle = new Car(i_VehicleManufacturer, i_Id, i_IsElectric, i_CurrentAmountOfPowerSource, i_CurrentAmountOfAir, i_WheelManufacturer, color, numberOfDoors);
                    break;
                case eVehicle.Motor:
                    eLicense license = (eLicense)i_UniqueProperties[0];
                    int egine = (int) i_UniqueProperties[1];
                    vehicle = new Motor(i_VehicleManufacturer, i_Id, i_IsElectric, i_CurrentAmountOfPowerSource, i_CurrentAmountOfAir, i_WheelManufacturer, license, egine);
                    break;
                case eVehicle.Truk:
                    bool isCarryingDangerous = (bool)i_UniqueProperties[0];
                    int currentCarryWeight = (int) i_UniqueProperties[1];
                    vehicle = new Truk(i_VehicleManufacturer, i_Id, i_IsElectric, i_CurrentAmountOfPowerSource, i_CurrentAmountOfAir, i_WheelManufacturer, isCarryingDangerous, currentCarryWeight);
                    break;

                // Add more vehicles here...
            }
        }

    }

    public enum eVehicle
    {
        Car,
        Motor,
        Truk
        // add more supported vehicles here
    }
}
