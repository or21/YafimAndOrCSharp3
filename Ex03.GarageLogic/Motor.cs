using System;

namespace Ex03.GarageLogic
{
    public class Motor : Vehicle
    {
        private const string k_EngineSizeQuestion = "Engine size";
        private readonly string r_LicnseQuestion = "License type";
        private eLicense m_License;
        private int m_Engine;
        
        public Motor()
        {
            NumberOfWheels = 2;
            ElectricMaxAir = 31;
            FuelMaxAir = 34;
            MaxEnergy = (float)1.2;
            MaxFuel = (float)8;
            FuelType = Fuel.eFuelType.Octan98;

            r_LicnseQuestion += " <";
            int i;
            for (i = 0; i < Enum.GetNames(typeof(eLicense)).Length - 1; i++)
            {
                r_LicnseQuestion += (eLicense) i + ", ";
            }

            r_LicnseQuestion += (eLicense) i + ">";
            m_VehicleDictionary.Add(r_LicnseQuestion, new eLicense());
            m_VehicleDictionary.Add(k_EngineSizeQuestion, new int());
        }

        public override void SetProperties()
        {
            base.SetProperties();
            License = (eLicense) Enum.Parse(typeof(eLicense), (string) VehicleDictionary[r_LicnseQuestion]);
            Engine = int.Parse((string)VehicleDictionary[k_EngineSizeQuestion]);
        }

        // Some getter and setters
        public eLicense License
        {
            get { return this.m_License; }
            set { this.m_License = value; }
        }

        public int Engine
        {
            get { return this.m_Engine; }
            set { this.m_Engine = value; }
        }

        public override string VehicleToString()
        {
            string motorData = base.VehicleToString();

            if (!this.m_IsElectric)
            {
                motorData += string.Format("Fuel type is {0}\n", Fuel.eFuelType.Octan98);
            }

            motorData += string.Format("Type of license: {0}\n", this.m_License);
            motorData += string.Format("Motor engine size: {0}\n", this.m_Engine);

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
