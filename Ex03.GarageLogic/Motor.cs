using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Motor : Vehicle
    {
        private eLicense m_license;
        private int m_engine;

        private static readonly int m_numberOfWheels = 2;

        private static readonly float m_electricMaxAir = 31;
        private static readonly float m_fuelMaxAir = 34;

        private static readonly float m_energy = (float)1.2;
        private static readonly float m_fuel = (float)8;
        private static readonly Fuel.eFuelType m_fuelType = Fuel.eFuelType.Octan98;

        public Motor()
        {
            // TODO: ADD GENERAL PROPERTIES 

            base.m_vehicleDictionary.Add("License", new eLicense());
            base.m_vehicleDictionary.Add("Engine", new int());
        }

        // Some getter and setters

        public eLicense License
        {
            get { return this.m_license; }
        }

        public int Engine
        {
            get { return this.m_engine; }
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
