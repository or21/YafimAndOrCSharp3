using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Truk : Vehicle
    {
        private const string k_DangerousQuestion = "Is Carrying Dangerous <true/false>";
        private const string k_WeightQuestion = "Current Carry Weight";
        private bool m_IsCarryingDangerous;
        private float m_CurrentCarryWeight;

        public Truk()
        {
            NumberOfWheels = 16;
            FuelMaxAir = 31;
            MaxFuel = (float)170;
            FuelType = Fuel.eFuelType.Solar;

            // Set unique properties
            m_VehicleDictionary.Add(k_DangerousQuestion, false);
            m_VehicleDictionary.Add(k_WeightQuestion, -1);
        }

        public override void SetProperties()
        {
            base.SetProperties();

            IsCarryingDangerous = bool.Parse((string)VehicleDictionary[k_DangerousQuestion]);
            CurretCarryWeight = int.Parse((string)VehicleDictionary[k_WeightQuestion]);
        }

        // Some getters and setters
        public float CurretCarryWeight
        {
            get { return this.m_CurrentCarryWeight; }
            set { this.m_CurrentCarryWeight = value; }
        }

        public bool IsCarryingDangerous
        {
            get { return this.m_IsCarryingDangerous; }
            set { this.m_IsCarryingDangerous = value; }
        }

        public override string VehicleToString()
        {
            string trukData = base.VehicleToString();

            trukData += string.Format(
@"Fuel type is {0}
Is carring dangerous materials: {1}
Truk current cargo weight: {2}",
                               Fuel.eFuelType.Solar,
                               this.m_IsCarryingDangerous,
                               this.m_CurrentCarryWeight);

            return trukData;
        }
    }
}
