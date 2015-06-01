//----------------------------------------------------------------------
// <copyright file="Energy.cs" company="B15_Ex03">
// Yafim Vodkov 308973882 Or Brand 302521034
// </copyright>
//----------------------------------------------------------------------
using System;

namespace Ex03.GarageLogic
{
    /// <summary>
    /// Energy class.
    /// </summary>
    public class Energy
    {
        /// <summary>
        /// Max amount of energy.
        /// </summary>
        private readonly float r_MaxAmount;

        /// <summary>
        /// Current amount of energy.
        /// </summary>
        private float m_CurrentAmount;

        /// <summary>
        /// Initializes a new instance of the Energy class.
        /// </summary>
        /// <param name="i_CurrentAmount">Current amount of energy</param>
        /// <param name="i_MaxAmount">Max amount of energy</param>
        public Energy(float i_CurrentAmount, float i_MaxAmount)
        {
            this.m_CurrentAmount = i_CurrentAmount;
            this.r_MaxAmount = i_MaxAmount;
        }

        /// <summary>
        /// Load vehicle with energy.
        /// </summary>
        /// <param name="i_EnergyToAdd">Energy to add</param>
        public void Load(float i_EnergyToAdd)
        {
            float sumOfAmounts = m_CurrentAmount + i_EnergyToAdd;
            bool isOverMax = sumOfAmounts > r_MaxAmount;
            if (isOverMax)
            {
                throw new ValueOutOfRangeException(new Exception(), r_MaxAmount, 0);
            }

            this.m_CurrentAmount = sumOfAmounts;
        }
        
        /// <summary>
        /// Gets or sets the current amount of energy.
        /// </summary>
        public float CurrAmount
        {
            get
            {
                return this.m_CurrentAmount;
            }

            set
            {
                bool isValidValue = value <= this.r_MaxAmount;
                if (isValidValue)
                {
                    this.m_CurrentAmount = value;
                }
                else
                {
                    throw new ValueOutOfRangeException(new Exception(), r_MaxAmount, 0);
                }
            }
        }
    }
}
