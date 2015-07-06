using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Mathematics.PolynomialSolvers
{
    // Solves ax + b = 0.  Note if a = 0 then b must equal 0.
    public static class LinearSolver
    {
        public static double? FindRoots(double a, double b)
        {
            if (a == 0 & b == 0)
            {
                return 0;
            }

            if (a == 0 & b != 0)
            {
                return null;
            }

            return -b/a;
        }
    }
}
