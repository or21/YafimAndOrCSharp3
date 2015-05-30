using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class ValueOutOfRangeException : Exception
    {
        private float m_maxValue;
        private float m_minValue;

        public ValueOutOfRangeException(Exception i_InnerException, float i_MaxValue, float i_MinValue)
            : base(string.Format("The specified value is out of range. " +
                                 "Allowed range is [{0}-{1}]", i_MinValue, i_MaxValue), i_InnerException)
        {
            this.m_maxValue = i_MaxValue;
            this.m_minValue = i_MinValue;
        }

        public float MaxValue
        {
            get { return this.m_maxValue; }
            set { m_maxValue = value; }
        }

        public float MinValue
        {
            get { return this.m_minValue; }
            set { m_minValue = value; }
        }
    }
}