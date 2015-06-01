using System;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_Manufacturer;
        private float m_CurrentTirePressure;
        private float m_MaxTirePressure;

        public void Inflate(float i_AirToAdd)
        {
            // TODO: Exception...
            try
            {
                this.m_CurrentTirePressure += i_AirToAdd;
            }
            catch (ValueOutOfRangeException vore)
            {
            }
        }

        public string Manufacturer
        {
            get { return m_Manufacturer; }
            set { this.m_Manufacturer = value; }
        }

        public float CurrentTirePressure
        {
            get { return this.m_CurrentTirePressure; }
            set
            {
                if (value < this.m_MaxTirePressure)
                {
                    this.m_CurrentTirePressure = value;
                }
                else
                {
                    throw new ValueOutOfRangeException(new IndexOutOfRangeException(), this.m_MaxTirePressure, 0);
                }
            }
        }

        public float MaxTirePressure
        {
            get { return this.m_MaxTirePressure; }
            set { this.m_MaxTirePressure = value; }
        }
    }
}
