using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Motor : Vehicle
    {
        private const string k_engineSizeQuestion = "Engine size";
        private readonly string r_licnseQuestion = "License type";
        private eLicense m_license;
        private int m_engine;
        
        public Motor()
        {
            NumberOfWheels = 2;
            ElectricMaxAir = 31;
            FuelMaxAir = 34;
            MaxEnergy = (float)1.2;
            MaxFuel = (float)8;
            FuelType = Fuel.eFuelType.Octan98;

            r_licnseQuestion += " <";
            int i;
            for (i = 0; i < Enum.GetNames(typeof(eLicense)).Length - 1; i++)
            {
                r_licnseQuestion += (eLicense) i + ", ";
            }

            r_licnseQuestion += (eLicense) i + ">";

            m_VehicleDictionary.Add(r_licnseQuestion, new eLicense());
            m_VehicleDictionary.Add(k_engineSizeQuestion, new int());
        }

        public override void SetProperties()
        {
            base.SetProperties();
            License = (eLicense) Enum.Parse(typeof(eLicense), (string) VehicleDictionary[r_licnseQuestion]);
            Engine = int.Parse((string)VehicleDictionary[k_engineSizeQuestion]);
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

            if (!this.m_IsElectric)
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
        A = 0,
        A2,
        AB,
        B1
    }
}
