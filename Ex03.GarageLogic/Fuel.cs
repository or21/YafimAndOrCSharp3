using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Fuel : Energy
    {
        private readonly eFuelType r_FuelType;

        public Fuel(float i_CurrentAmount, float i_MaxAmount, eFuelType i_FuelType) : base(i_CurrentAmount, i_MaxAmount)
        {
            this.r_FuelType = i_FuelType;
        }

        public static bool IsValidFuelType(string i_FuelType)
        {
            object currentFuel = Enum.Parse(typeof(eFuelType), i_FuelType);
            bool isEnumValue = currentFuel is eFuelType;

            return isEnumValue;
        }

        public void Load(float i_EnergyToAdd, eFuelType i_FuelType)
        {
            bool isSameFuel = i_FuelType == this.r_FuelType;
            if (!isSameFuel)
            {
                throw new ArgumentException();
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
