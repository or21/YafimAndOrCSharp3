using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_manufacturer;
        private float _currentTirePressure;
        private float m_maxTirePressure;

        public void Inflate(float i_AirToAdd)
        {
            // TODO: Exception...
            try
            {
                this._currentTirePressure = i_AirToAdd;
            }
            catch (ValueOutOfRangeException vore)
            {
                throw new ValueOutOfRangeException(new IndexOutOfRangeException(), this.m_maxTirePressure, 0);
        }
        }

        public string Manufacturer
        {
            get { return m_manufacturer; }
            set { this.m_manufacturer = value; }
        }

        public float CurrentTirePressure
        {
            get { return this._currentTirePressure; }
            set {
                if (value > this.m_maxTirePressure)
                {
                    this._currentTirePressure = value;
                }
                else
        {
                    throw new ValueOutOfRangeException(new IndexOutOfRangeException(), this.m_maxTirePressure, 0);
                }}
        }

        public float MaxTirePressure
        {
            get { return this.m_maxTirePressure; }
            set { this.m_maxTirePressure = value; }
        }
    }
}
