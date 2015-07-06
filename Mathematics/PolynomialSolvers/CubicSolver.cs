using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mathematics.ComplexNumbers;

namespace Mathematics.PolynomialSolvers
{
    // Solves the cubic equation ax^3 + bx^2 + cx + d using Vieta's substitution (see https://en.wikipedia.org/wiki/Cubic_function)
    public class CubicSolver
    {
        public static List<Complex> FindRoots(double a, double b, double c, double d)
        {
            if (a == 0)
            {
                return QuadraticSolver.FindRoots(b, c, d);
            }

            // Obtain the coefficients of the depressed cubic equation t^3 + pt + q = 0
            double p = (3 * a * c - b * b) / (3 * a * a);
            double q = (2 * b * b * b - 9 * a * b * c + 27 * a * a * d) / (27 * a * a * a);

            // Solve the quadratic z^2 + q*z - p^3/27 = 0 after applying Vieta's substitution
            List<Complex> quadraticVietaRoots = QuadraticSolver.FindRoots(1, q, -p * p * p / 27);
            List<Complex> cubicVietaRoots = Complex.NthRoots(quadraticVietaRoots[0], 3);

            List<Complex> depressedRoots = new List<Complex>();
            foreach (var cubicVietaRoot in cubicVietaRoots)
            {
                var depressedRoot = Complex.Zero;
                if (cubicVietaRoot != Complex.Zero)
                {
                    depressedRoot = cubicVietaRoot - p / (3 * cubicVietaRoot);
                }

                depressedRoots.Add(depressedRoot);
            }

            return ConvertDepressedRoots(depressedRoots, a, b);
        }

        private static List<Complex> ConvertDepressedRoots(List<Complex> depressedRoots, double a, double b)
        {
            List<Complex> originalRoots = new List<Complex>();
            foreach (Complex depressedRoot in depressedRoots)
            {
                var originalRoot = depressedRoot - b/(3*a);
                originalRoots.Add(originalRoot);
            }

            return originalRoots;
        }
    }
}
