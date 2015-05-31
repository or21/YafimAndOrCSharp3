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
            base.m_vehicleDictionary.Add("Is Carrying Dangerous", false);
            base.m_vehicleDictionary.Add("Current Carry Weight", -1);
        }

        public override void SetProperties()
        {
            base.SetProperties();

            CurretCarryWeight = int.Parse((string)base.VehicleDictionary["Current Carry Weight"]);
            IsCarryingDangerous = bool.Parse((string) base.VehicleDictionary["Is Carrying Dangerous"]);
        }

        // Some getters and setters
        public float CurretCarryWeight
        {
            get { return this.m_currentCarryWeight; }
            set { this.m_currentCarryWeight = value; }
        }

        public bool IsCarryingDangerous
        {
            get { return this.m_isCarryingDangerous; }
            set { this.m_isCarryingDangerous = value; }
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
