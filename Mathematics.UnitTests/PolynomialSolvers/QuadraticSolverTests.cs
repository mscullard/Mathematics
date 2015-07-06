using System;
using System.Collections.Generic;
using Mathematics.ComplexNumbers;
using Mathematics.PolynomialSolvers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mathematics.UnitTests.PolynomialSolvers
{
    [TestClass]
    public class QuadraticSolverTests
    {
        [TestMethod]
        public void FindRoots_FirstTermIsZero_ReturnsCorrectAnswer()
        {
            double a = 0;
            double b = 1;
            double c = 3;

            List<Complex> roots = QuadraticSolver.FindRoots(a, b, c);

            Complex root = new Complex(-3, 0);

            Assert.AreEqual(1, roots.Count);
            Assert.IsTrue(roots.Exists(x => x == root));
        }

        [TestMethod]
        public void FindRoots_DistinctRealRoots_ReturnsCorrectAnswer()
        {
            double a = 1;
            double b = -2;
            double c = -3;

            List<Complex> roots = QuadraticSolver.FindRoots(a, b, c);

            Complex root1 = new Complex(-1, 0);
            Complex root2 = new Complex(3, 0);

            Assert.AreEqual(2, roots.Count);
            Assert.IsTrue(roots.Exists(x => x == root1));
            Assert.IsTrue(roots.Exists(x => x == root2));
        }

        [TestMethod]
        public void FindRoots_IdenticalRealRoots_ReturnsCorrectAnswer()
        {
            double a = 1;
            double b = -4;
            double c = 4;

            List<Complex> roots = QuadraticSolver.FindRoots(a, b, c);

            Complex root1 = new Complex(2, 0);
            Complex root2 = new Complex(2, 0);

            Assert.AreEqual(2, roots.Count);
            Assert.IsTrue(roots.Exists(x => x == root1));
            Assert.IsTrue(roots.Exists(x => x == root2));
        }

        [TestMethod]
        public void FindRoots_ComplexRoots_ReturnsCorrectAnswer()
        {
            double a = 1;
            double b = -2;
            double c = 4;

            List<Complex> roots = QuadraticSolver.FindRoots(a, b, c);

            Complex root1 = new Complex(1, Math.Sqrt(3));
            Complex root2 = new Complex(1, -Math.Sqrt(3));

            Assert.AreEqual(2, roots.Count);
            Assert.IsTrue(roots.Exists(x => x == root1));
            Assert.IsTrue(roots.Exists(x => x == root2));
        }
    }
}
