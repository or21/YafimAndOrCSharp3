using System;
using System.CodeDom;
using System.Collections.Generic;

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
                // TODO: Throw exception ;
            }
            else
            {
                this.currentAmount = sumOfAmounts;
            }
        }

        public float CurrAmount
        {
            get { return this.currentAmount; }
            //set { this.currentAmount = value; }
            set
            {
                bool isValidValue = value <= this.currentAmount;
                if (isValidValue)
                {
                    this.currentAmount = value;
                }
                else
                {
                    throw new ValueOutOfRangeException(new Exception(), r_MaxAmount, 0);
                }
            }
        }
    }
}
