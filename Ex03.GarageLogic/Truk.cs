﻿//----------------------------------------------------------------------
// <copyright file="Truk.cs" company="B15_Ex03">
// Yafim Vodkov 308973882 Or Brand 302521034
// </copyright>
//----------------------------------------------------------------------
namespace Ex03.GarageLogic
{
    /// <summary>
    /// Truk class.
    /// </summary>
    public class Truk : Vehicle
    {
        /// <summary>
        /// Unique property string.
        /// </summary>
        private const string k_dangerousQuestion = "Is Carrying Dangerous <true/false>";

        /// <summary>
        /// Unique property string.
        /// </summary>
        private const string k_weightQuestion = "Current Carry Weight";

        /// <summary>
        /// If carries dangerous stuff.
        /// </summary>
        private bool m_isCarryingDangerous;

        /// <summary>
        /// Current carry weight.
        /// </summary>
        private float m_currentCarryWeight;

        /// <summary>
        /// Initializes a new instance of the Truk class.
        /// </summary>
        public Truk()
        {
            NumberOfWheels = 16;
            FuelMaxAir = 31;
            MaxFuel = (float)170;
            FuelType = Fuel.eFuelType.Solar;

            // Set unique properties
            m_VehicleDictionary.Add(k_dangerousQuestion, false);
            m_VehicleDictionary.Add(k_weightQuestion, -1);
        }

        /// <summary>
        /// Set general and unique properties of this vehicle.
        /// </summary>
        public override void SetProperties()
        {
            base.SetProperties();

            IsCarryingDangerous = bool.Parse((string)VehicleDictionary[k_dangerousQuestion]);
            CurretCarryWeight = int.Parse((string)VehicleDictionary[k_weightQuestion]);
        }

        /// <summary>
        /// Gets or sets the current carry weight.
        /// </summary>
        public float CurretCarryWeight
        {
            get { return this.m_currentCarryWeight; }
            set { this.m_currentCarryWeight = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether carrying dangerous stuff.
        /// </summary>
        public bool IsCarryingDangerous
        {
            get { return this.m_isCarryingDangerous; }
            set { this.m_isCarryingDangerous = value; }
        }

        /// <summary>
        /// Gets the string output vehicle properties.
        /// </summary>
        /// <returns>Vehicle properties.</returns>
        public override string VehicleToString()
        {
            string trukData = base.VehicleToString();

            trukData += string.Format(
@"Fuel type is {0}
Is carring dangerous materials: {1}
Truk current cargo weight: {2}", 
                               FuelType, 
                               this.m_isCarryingDangerous, 
                               this.m_currentCarryWeight);

            return trukData;
        }
    }
}
