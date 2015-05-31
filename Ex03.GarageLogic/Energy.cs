using System;

namespace Ex03.GarageLogic
{
    public class Energy
    {
        private readonly float r_MaxAmount;
        private float currentAmount;

        public Energy(float i_CurrentAmount, float i_MaxAmount)
        {
            this.currentAmount = i_CurrentAmount;
            this.r_MaxAmount = i_MaxAmount;
        }

        public void Load(float i_EnergyToAdd)
        {
            float sumOfAmounts = currentAmount + i_EnergyToAdd;
            bool isOverMax = sumOfAmounts > r_MaxAmount;
            if (isOverMax)
            {
                throw new ArgumentException();
            }
            else
            {
                this.currentAmount = sumOfAmounts;
            }
        }

        public float CurrAmount
        {
            get { return this.currentAmount; }
            set { this.currentAmount = value; }
        }
    }
}
