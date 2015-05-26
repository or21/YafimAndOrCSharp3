using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Energy
    {
        private float currentAmount;
        private readonly float r_MaxAmount;

        public static  
        {
            
        }

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
            set { this.currentAmount = value; }
        }
    }
}
