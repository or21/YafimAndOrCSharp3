using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Truk : Vehicle
    {
        private bool m_isCarryingDangerous;
        private float m_currentCarryWeight;

        public Truk()
        {

            base.NumberOfWheels = 16;
            base.FuelMaxAir = 31;
            base.MaxFuel = (float)170;
            base.FuelType = Fuel.eFuelType.Solar;

            // Set unique properties
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
