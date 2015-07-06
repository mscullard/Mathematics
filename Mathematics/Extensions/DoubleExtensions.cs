using System;

namespace Mathematics.Extensions
{
    public static class DoubleExtensions
    {
        private static double MachineEpsilon = 1e-15;

        public static bool Eq(this double a, double b)
        {
            return Math.Abs(a - b) < MachineEpsilon;
        }
    }
}
