//----------------------------------------------------------------------
// <copyright file="Program.cs" company="B15_Ex03">
// Yafim Vodkov 308973882 Or Brand 302521034
// </copyright>
//----------------------------------------------------------------------
namespace Ex03.GarageManagementSystem.ConsuleUI
{
    /// <summary>
    /// Starts the program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Run garage.
        /// </summary>
        public static void Main()
        {
            GarageManager gm = new GarageManager();
            gm.RunOperations();
        }
    }
}