using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Truk : Vehicle
    {
        private const string k_dangerousQuestion = "Is Carrying Dangerous <true/false>";
        private const string k_weightQuestion = "Current Carry Weight";
        private bool m_isCarryingDangerous;
        private float m_currentCarryWeight;

        public Truk()
        {
            NumberOfWheels = 16;
            FuelMaxAir = 31;
            MaxFuel = (float)170;
            FuelType = Fuel.eFuelType.Solar;

            // Set unique properties
            m_VehicleDictionary.Add(k_dangerousQuestion, false);
            m_VehicleDictionary.Add(k_weightQuestion, -1);
        }

        public override void SetProperties()
        {
            base.SetProperties();

            IsCarryingDangerous = bool.Parse((string)VehicleDictionary[k_dangerousQuestion]);
            CurretCarryWeight = int.Parse((string)VehicleDictionary[k_weightQuestion]);
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

            trukData += string.Format(
@"Fuel type is {0}
Is carring dangerous materials: {1}
Truk current cargo weight: {2}", 
                               Fuel.eFuelType.Solar, 
                               this.m_isCarryingDangerous, 
                               this.m_currentCarryWeight);

            return trukData;
        }
    }
}
