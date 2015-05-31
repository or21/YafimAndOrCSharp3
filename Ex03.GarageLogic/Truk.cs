using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Truk : Vehicle
    {
        private readonly bool m_isCarryingDangerous;
        private readonly float m_currentCarryWeight;

        private static readonly int m_numberOfWheels = 16;
        private static readonly float m_electricMaxAir = 0;
        private static readonly float m_fuelMaxAir = 31;

        private static readonly float m_energy = 0;
        private static readonly float m_fuel = (float)170;
        private static readonly Fuel.eFuelType m_fuelType = Fuel.eFuelType.Solar;

        public Truk()
        {
            base.m_vehicleDictionary.Add("Is Carrying Dangerous", new bool());
            base.m_vehicleDictionary.Add("Current Carry Weight", new float());
        }

        // Some getters and setters

        public float CurretCarryWeight
        {
            get { return this.m_currentCarryWeight; }
        }

        public bool IsCarryingDangerous
        {
            get { return this.m_isCarryingDangerous; }
        }

        public override string VehicleToString()
        {
            string trukData = base.VehicleToString();

            trukData += string.Format("Fuel type is {0}\n", Fuel.eFuelType.Solar);
            trukData += string.Format("Is carring dangerous materials: {0}\n", this.m_isCarryingDangerous);
            trukData += string.Format("Truk current cargo weight: {0}\n", this.m_currentCarryWeight);

            return trukData;
        }
    }
}
