﻿//----------------------------------------------------------------------
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
        private const string k_engineSizeQuestion = "Engine size";

        /// <summary>
        /// Unique property string.
        /// </summary>
        private readonly string r_licnseQuestion = "License type";

        /// <summary>
        /// License type.
        /// </summary>
        private eLicense m_license;

        /// <summary>
        /// Engine size.
        /// </summary>
        private int m_engine;
        
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

        /// <summary>
        /// Set general and unique properties of this vehicle.
        /// </summary>
        public override void SetProperties()
        {
            base.SetProperties();
            License = (eLicense) Enum.Parse(typeof(eLicense), (string) VehicleDictionary[r_licnseQuestion]);
            Engine = int.Parse((string)VehicleDictionary[k_engineSizeQuestion]);
        }

        /// <summary>
        /// Gets or sets the license type.
        /// </summary>
        public eLicense License
        {
            get { return this.m_license; }
            set { this.m_license = value; }
        }

        /// <summary>
        /// Gets or sets the engine size.
        /// </summary>
        public int Engine
        {
            get { return this.m_engine; }
            set { this.m_engine = value; }
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

            motorData += string.Format("Type of license: {0}\n", this.m_license);
            motorData += string.Format("Motor engine size: {0}\n", this.m_engine);

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
