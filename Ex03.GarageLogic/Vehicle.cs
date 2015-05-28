using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        internal string manufacturer;
        internal string id;
        internal float powerSourceLeft;
        internal List<Wheel> wheels;

        internal object powerSource;
        internal int maxPower;

        public object PowerSource
        {
            get { return powerSource; }
        }

        public string Id
        {
            get { return id; }
        }
    }
}
