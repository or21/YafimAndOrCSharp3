//----------------------------------------------------------------------
// <copyright file="Motor.cs" company="B15_Ex03">
// Yafim Vodkov 308973882 Or Brand 302521034
// </copyright>
//----------------------------------------------------------------------
using System;

namespace Ex03.GarageLogic
{
    /// <summary>
    /// Motor class.
    /// </summary>
    public class Motor : Vehicle
    {
        /// <summary>
        /// Unique property string.
        /// </summary>
        private const string k_EngineSizeQuestion = "Engine size";

        /// <summary>
        /// Unique property string.
        /// </summary>
        private readonly string r_LicnseQuestion = "License type";

        /// <summary>
        /// License type.
        /// </summary>
        private eLicense m_License;

        /// <summary>
        /// Engine size.
        /// </summary>
        private int m_Engine;
        
        /// <summary>
        /// Initializes a new instance of the Motor class.
        /// </summary>
        public Motor()
        {
            NumberOfWheels = 2;
            ElectricMaxAir = 31;
            FuelMaxAir = 34;
            MaxEnergy = (float)1.2;
            MaxFuel = (float)8;
            FuelType = Fuel.eFuelType.Octan98;
            HasFuelOption = true;
            HasElectOption = true;

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

        /// <summary>
        /// Set general and unique properties of this vehicle.
        /// </summary>
        public override void SetProperties()
        {
            base.SetProperties();
            License = (eLicense) Enum.Parse(typeof(eLicense), (string) VehicleDictionary[r_LicnseQuestion]);
            Engine = int.Parse((string)VehicleDictionary[k_EngineSizeQuestion]);
        }

        /// <summary>
        /// Gets or sets the license type.
        /// </summary>
        public eLicense License
        {
            get { return this.m_License; }
            set { this.m_License = value; }
        }

        /// <summary>
        /// Gets or sets the engine size.
        /// </summary>
        public int Engine
        {
            get { return this.m_Engine; }
            set { this.m_Engine = value; }
        }

        /// <summary>
        /// Gets the string output vehicle properties.
        /// </summary>
        /// <returns>Vehicle properties.</returns>
        public override string VehicleToString()
        {
            string motorData = base.VehicleToString();

            if (!this.m_IsElectric)
            {
                motorData += string.Format("Fuel type is {0}\n", FuelType);
            }

            motorData += string.Format("Type of license: {0}\n", this.m_License);
            motorData += string.Format("Motor engine size: {0}\n", this.m_Engine);

            return motorData;
        }
    }

    /// <summary>
    /// License type.
    /// </summary>
    public enum eLicense
    {
        /// <summary>
        /// A type.
        /// </summary>
        A = 0,

        /// <summary>
        /// A2 type.
        /// </summary>
        A2,

        /// <summary>
        /// AB type.
        /// </summary>
        AB,

        /// <summary>
        /// B1 type.
        /// </summary>
        B1
    }
}
