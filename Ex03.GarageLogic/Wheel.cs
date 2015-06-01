//----------------------------------------------------------------------
// <copyright file="Wheel.cs" company="B15_Ex03">
// Yafim Vodkov 308973882 Or Brand 302521034
// </copyright>
//----------------------------------------------------------------------
using System;

namespace Ex03.GarageLogic
{
    /// <summary>
    /// Wheel class.
    /// </summary>
    public class Wheel
    {
        /// <summary>
        /// Wheel manufacturer.
        /// </summary>
        private string m_Manufacturer;

        /// <summary>
        /// Current tire air pressure.
        /// </summary>
        private float m_CurrentTirePressure;

        /// <summary>
        /// Cure tire max air pressure.
        /// </summary>
        private float m_MaxTirePressure;

        /// <summary>
        /// Inflate wheel.
        /// </summary>
        /// <param name="i_AirToAdd">Amount of air to add</param>
        public void Inflate(float i_AirToAdd)
        {
            // TODO: Exception...
            try
            {
                this.m_CurrentTirePressure += i_AirToAdd;
            }
            catch (ValueOutOfRangeException vore)
            {
            }
        }

        /// <summary>
        /// Gets or sets wheel manufacturer.
        /// </summary>
        public string Manufacturer
        {
            get { return m_Manufacturer; }
            set { this.m_Manufacturer = value; }
        }

        /// <summary>
        /// Gets or sets current tire pressure.
        /// Throws ValueOutOfRangeException
        /// </summary>
        public float CurrentTirePressure
        {
            get
            {
                return this.m_CurrentTirePressure;
            }

            set
            {
                if (value < this.m_MaxTirePressure)
                {
                    this.m_CurrentTirePressure = value;
                }
                else
                {
                    throw new ValueOutOfRangeException(new IndexOutOfRangeException(), this.m_MaxTirePressure, 0);
                }
            }
        }

        /// <summary>
        /// Gets or sets max tire pressure.
        /// </summary>
        public float MaxTirePressure
        {
            get { return this.m_MaxTirePressure; }
            set { this.m_MaxTirePressure = value; }
        }
    }
}
