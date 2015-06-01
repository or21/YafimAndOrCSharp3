//----------------------------------------------------------------------
// <copyright file="ValueOutOfRangeException.cs" company="B15_Ex03">
// Yafim Vodkov 308973882 Or Brand 302521034
// </copyright>
//----------------------------------------------------------------------
using System;

namespace Ex03.GarageLogic
{
    /// <summary>
    /// ValueOutOfRangeException class.
    /// </summary>
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;

        public ValueOutOfRangeException(Exception i_InnerException, float i_MaxValue, float i_MinValue)
            : base(string.Format("The specified value is out of range. " + "Allowed range is [{0}-{1}]", i_MinValue, i_MaxValue), i_InnerException)
        {
            this.m_MaxValue = i_MaxValue;
            this.m_MinValue = i_MinValue;
        }

        public float MaxValue
        {
            get { return this.m_MaxValue; }
            set { m_MaxValue = value; }
        }

        public float MinValue
        {
            get { return this.m_MinValue; }
            set { m_MinValue = value; }
        }
    }
}