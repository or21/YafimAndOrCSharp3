using System;

namespace Ex03.GarageLogic
{
    public class Energy
    {
        private readonly float r_MaxAmount;
        private float m_CurrentAmount;

        public Energy(float i_CurrentAmount, float i_MaxAmount)
        {
            this.m_CurrentAmount = i_CurrentAmount;
            this.r_MaxAmount = i_MaxAmount;
        }

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

        public float CurrAmount
        {
            get { return this.m_CurrentAmount; }
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
