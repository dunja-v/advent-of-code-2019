using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2019
{
    class FuelCalculator
    {
        public static int CalculateFuelNeeded(string inputFile)
        {
            int fuelNeeded = 0;

            var lines = File.ReadLines(inputFile);
            foreach (var line in lines)
            {
                int mass = Int32.Parse(line);
                fuelNeeded += FuelForMass(mass);
            }
            return fuelNeeded;
        }

        static int FuelForMass(int mass)
        {
            int fuelNeeded = (int)(Math.Floor(mass / 3.0)) - 2;

            if (fuelNeeded <= 0)
            {
                return 0;
            }
            return fuelNeeded + FuelForMass(fuelNeeded);
        }
    }
}
