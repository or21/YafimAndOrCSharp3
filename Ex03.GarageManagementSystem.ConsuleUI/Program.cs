using System;
using System.Collections.Generic;
using System.Linq;
using Ex03.GarageLogic;

namespace Ex03.GarageManagementSystem.ConsuleUI
{
    public class Program
    {
        public static void Main()
        {
            GarageManager gm = new GarageManager();
            gm.RunOperations();
        }
    }
}