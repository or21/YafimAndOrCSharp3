using System;

namespace Ex03.GarageLogic
{
    public class Traktor : Vehicle
    {
        private readonly string r_colorQuestion = "Traktor Color";
        private readonly string r_weightQuestion = "Weight";
        private eTraktorColor m_color;
        private int m_weight;

        public Traktor()
        {
            NumberOfWheels = 4;
            ElectricMaxAir = 100;
            FuelMaxAir = 100;

            MaxFuel = (float)100;
            FuelType = Fuel.eFuelType.Solar;

            r_colorQuestion += " <";
            int i;
            for (i = 1; i < Enum.GetNames(typeof(eTraktorColor)).Length; i++)
            {
                r_colorQuestion += (eTraktorColor)i + ", ";
            }

            r_colorQuestion += (eTraktorColor)i + ">";

            
            m_VehicleDictionary.Add(r_colorQuestion, null);
            m_VehicleDictionary.Add(r_weightQuestion, null);
        }

        // Some setters and getters
        public eTraktorColor Color
        {
            get { return this.m_color; }
            set { this.m_color = value; }
        }

        public override void SetProperties()
        {
            base.SetProperties();
            Color = (eTraktorColor)Enum.Parse(typeof(eTraktorColor), (string)VehicleDictionary[r_colorQuestion]);
            Weight = int.Parse((string)VehicleDictionary[r_weightQuestion]);
        }

        public override string VehicleToString()
        {
            string traktorData = base.VehicleToString();

            if (!this.m_IsElectric)
            {
                traktorData += string.Format("Fuel type is {0}\n", Fuel.eFuelType.Solar);
            }

            traktorData += string.Format(
@"Weight is : {0}
Car color is: {1}",
                  this.m_weight,
                  this.m_color);

            return traktorData;
        }

        public int Weight
        {
            get { return this.m_weight; }
            set { this.m_weight = value; }
        }
    }


    public enum eTraktorColor
    {
        Green = 1,
        Black,
        Yellow
    }
}
