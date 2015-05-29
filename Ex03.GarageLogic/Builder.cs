using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Builder
    {
        // General fields for all viehicles
        private List<object> m_uniqueProperties;
        private eVehicle m_vehicle;
        private Vehicle vehicle;

        public void createVehicle(eVehicle i_Vehicle, string i_VehicleManufacturer, string i_Id, bool i_IsElectric, float i_CurrentAmountOfPowerSource, float i_CurrentAmountOfAir, string i_WheelManufacturer, List<object> i_UniqueProperties)
        {
            // Build specific vehecile
            switch (i_Vehicle)
            {
                case eVehicle.CAR:
                    eColor color = (eColor) i_UniqueProperties[0];
                    int numberOfDoors = (int) i_UniqueProperties[1];
                    vehicle = new Car(i_VehicleManufacturer, i_Id, i_IsElectric, i_CurrentAmountOfPowerSource, i_CurrentAmountOfAir, i_WheelManufacturer, color, numberOfDoors);
                    break;
                case eVehicle.MOTOR:
                    eLicense license = (eLicense)i_UniqueProperties[0];
                    int egine = (int) i_UniqueProperties[1];
                    vehicle = new Motor(i_VehicleManufacturer, i_Id, i_IsElectric, i_CurrentAmountOfPowerSource, i_CurrentAmountOfAir, i_WheelManufacturer, license, egine);
                    break;
                case eVehicle.TRUK:
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
        CAR,
        MOTOR,
        TRUK
        // add more supported vehicles here
    }
}
