using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mathematics.ComplexNumbers;
using Mathematics.PolynomialSolvers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mathematics.UnitTests.PolynomialSolvers
{
    [TestClass]
    public class CubicSolverTests
    {
        [TestMethod]
        public void FindRoots_QuadraticEquation_ReturnsCorrectAnswer()
        {
            double a = 0;
            double b = 1;
            double c = -4;
            double d = 4;

            List<Complex> roots = CubicSolver.FindRoots(a, b, c, d);

            Complex root1 = new Complex(2, 0);
            Complex root2 = new Complex(2, 0);

            Assert.AreEqual(2, roots.Count);
            Assert.IsTrue(roots.Exists(x => x == root1));
            Assert.IsTrue(roots.Exists(x => x == root2));
        }

        [TestMethod]
        public void FindRoots_ThreeDistinctRealRoots_ReturnsCorrectAnswer()
        {
            double a = 1;
            double b = -6;
            double c = 11;
            double d = -6;

            List<Complex> roots = CubicSolver.FindRoots(a, b, c, d);

            Complex root1 = new Complex(1, 0);
            Complex root2 = new Complex(2, 0);
            Complex root3 = new Complex(3, 0);

            Assert.AreEqual(3, roots.Count);
            Assert.IsTrue(roots.Exists(x => x == root1));
            Assert.IsTrue(roots.Exists(x => x == root2));
            Assert.IsTrue(roots.Exists(x => x == root3));
        }

        [TestMethod]
        public void FindRoots_RealRootsTwoIdentical_ReturnsCorrectAnswer()
        {
            double a = 1;
            double b = -5;
            double c = 8;
            double d = -4;

            List<Complex> roots = CubicSolver.FindRoots(a, b, c, d);

            Complex root1 = new Complex(1, 0);
            Complex root2 = new Complex(2, 0);

            Assert.AreEqual(3, roots.Count);
            Assert.IsTrue(roots.Exists(x => x == root1));
            Assert.AreEqual(2, roots.Count(x => x == root2));
        }

        [TestMethod]
        public void FindRoots_RealRootsAllIdentical_ReturnsCorrectAnswer()
        {
            double a = 1;
            double b = -3;
            double c = 3;
            double d = -1;

            List<Complex> roots = CubicSolver.FindRoots(a, b, c, d);

            Complex root = new Complex(1, 0);            

            Assert.AreEqual(3, roots.Count);
            Assert.AreEqual(3, roots.Count(x => x == root));
        }

        [TestMethod]
        public void FindRoots_TwoComplexRoots_ReturnsCorrectAnswer()
        {
            double a = 1;
            double b = 3;
            double c = 1;
            double d = 3;

            List<Complex> roots = CubicSolver.FindRoots(a, b, c, d);

            Complex root1 = new Complex(-3, 0);
            Complex root2 = new Complex(0, 1);
            Complex root3 = new Complex(0, -1);

            Assert.AreEqual(3, roots.Count);
            Assert.IsTrue(roots.Exists(x => x == root1));
            Assert.IsTrue(roots.Exists(x => x == root2));
            Assert.IsTrue(roots.Exists(x => x == root3));
        }
    }
}
