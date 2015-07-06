using System;
using System.Collections.Generic;
using Mathematics.ComplexNumbers;

namespace Mathematics.PolynomialSolvers
{
    public static class QuadraticSolver
    {
        public static List<Complex> FindRoots(double a, double b, double c)
        {
            if (a == 0)
            {
                return GetLinearRoot(b, c);
            }

            double discriminant = b * b - 4 * a * c;
            if (discriminant >= 0)
            {
                return GetRealRoots(a, b, discriminant);
            }
            
            return GetComplexRoots(a, b, discriminant);
            
        }

        private static List<Complex> GetComplexRoots(double a, double b, double discriminant)
        {
            Complex complexDiscriminant = new Complex(discriminant, 0);
            List<Complex> sqrtDiscriminant = Complex.NthRoots(complexDiscriminant, 2);
            Complex complexA = new Complex(a, 0);

            List<Complex> roots = new List<Complex>();
            for (int i = 0; i < sqrtDiscriminant.Count; i++)
            {
                Complex root = (-b + sqrtDiscriminant[i])/(2*complexA);
                roots.Add(root);
            }

            return roots;
        }

        private static List<Complex> GetRealRoots(double a, double b, double discriminant)
        {
            double root1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
            double root2 = (-b - Math.Sqrt(discriminant)) / (2 * a);

            Complex complexRoot1 = new Complex(root1, 0);
            Complex complexRoot2 = new Complex(root2, 0);

            return new List<Complex>() {complexRoot1, complexRoot2};
        }

        private static List<Complex> GetLinearRoot(double b, double c)
        {
            double? linearRoot =LinearSolver.FindRoots(b, c);
            if (linearRoot == null)
            {
                return null;
            }

            Complex root = new Complex((double) linearRoot, 0);
            return new List<Complex>() {root};
        }
    }
}
