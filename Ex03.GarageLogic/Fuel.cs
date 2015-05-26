using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{

    public class Fuel : Energy
    {
        private readonly eFuelType r_FuelType;

        public Fuel(float i_CurrentAmount, float i_MaxAmount, eFuelType i_FuelType) : base(i_CurrentAmount, i_MaxAmount)
        {
            this.r_FuelType = i_FuelType;
        }

        public void Load(float i_EnergyToAdd, eFuelType i_FuelType)
        {
            bool isSameFuel = i_FuelType == this.r_FuelType;
            if (!isSameFuel)
            {
                // TODO: throw exception
            }

            base.Load(i_EnergyToAdd);
        }

        public enum eFuelType
        {
            Octan96,
            Octan95,
            Octan98,
            Solar
        }
    }
}
