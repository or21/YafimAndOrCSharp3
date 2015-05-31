using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Motor : Vehicle
    {
        private eLicense m_license;
        private int m_engine;

        public Motor()
        {
            // TODO: ADD GENERAL PROPERTIES 
            base.NumberOfWheels = 2;
            base.ElectricMaxAir = 31;
            base.FuelMaxAir = 34;
            base.MaxEnergy = (float)1.2;
            base.MaxFuel = (float)8;
            base.FuelType = Fuel.eFuelType.Octan98;

            base.m_vehicleDictionary.Add("License", new eLicense());
            base.m_vehicleDictionary.Add("Engine", new int());
        }

        public override void setProperties()
        {
            base.setProperties();
            License = (eLicense) Enum.Parse(typeof (eLicense), (string) base.VehicleDictionary["License"]);
 //           Engine = (int)int.Parse(typeof (string), (string) base.VehicleDictionary["Engine"]);
        }

        // Some getter and setters

        public eLicense License
        {
            get { return this.m_license; }
            set { this.m_license = value; }
        }

        public int Engine
        {
            get { return this.m_engine; }
            set { this.m_engine = value; }
        }

        public override string VehicleToString()
        {
            string motorData = base.VehicleToString();

            if (!this.m_isElectric)
            {
                motorData += string.Format("Fuel type is {0}\n", Fuel.eFuelType.Octan98);
            }
            motorData += string.Format("Type of license: {0}\n", this.m_license);
            motorData += string.Format("Motor engine size: {0}\n", this.m_engine);

            return motorData;
        }
    }

    public enum eLicense
    {
        A,
        A2,
        AB,
        B1
    }
}
