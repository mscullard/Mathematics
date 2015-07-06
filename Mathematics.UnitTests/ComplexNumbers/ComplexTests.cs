using System;
using System.Collections.Generic;
using Mathematics.ComplexNumbers;
using Mathematics.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mathematics.UnitTests.ComplexNumbers
{
    [TestClass]
    public class ComplexTests
    {
        [TestMethod]
        public void Constructor_StandardInput_CorrectValuesStored()
        {
            double a = 3.2;
            double b = 1.4;
            Complex z = new Complex(a,b);

            Assert.IsTrue(z.Re == a);
            Assert.IsTrue(z.Im == b);
        }

        [TestMethod]
        public void Equals_CompareSameNumber_ReturnsTrue()
        {
            Complex z1 = new Complex(0, 0);
            Complex z2 = new Complex(0, 0);

            Assert.IsTrue(z1 == z2);
        }

        [TestMethod]
        public void Equals_AnswersNotEqual_ReturnsFalse()
        {
            Complex z1 = new Complex(0, 0);
            Complex z2 = new Complex(1, 3);

            Assert.IsFalse(z1 == z2);
        }

        [TestMethod]
        public void Equals_CompareDifferentRealParts_ReturnsFalse()
        {
            Complex z1 = new Complex(0, 0);
            Complex z2 = new Complex(1, 0);

            Assert.IsTrue(z1 != z2);
        }

        [TestMethod]
        public void Equals_CompareDifferentImaginaryParts_ReturnsFalse()
        {
            Complex z1 = new Complex(0, 0);
            Complex z2 = new Complex(0, 1);

            Assert.IsTrue(z1 != z2);
        }

        [TestMethod]
        public void Addition_AddTwoNumbers_ReturnsCorrectAnswer()
        {
            Complex z1 = new Complex(1, 1);
            Complex z2 = new Complex(2, 4);

            Complex computedAnswer = z1 + z2;

            Complex expectedAnswer = new Complex(3, 5);
            Assert.IsTrue(expectedAnswer == computedAnswer);
        }

        [TestMethod]
        public void Subtraction_SubtractTwoNumbers_ReturnsCorrectAnswer()
        {
            Complex z1 = new Complex(1, 1);
            Complex z2 = new Complex(2, 4);

            Complex computedAnswer = z1 - z2;

            Complex expectedAnswer = new Complex(-1, -3);
            Assert.IsTrue(expectedAnswer == computedAnswer);
        }

        [TestMethod]
        public void Division_OnlyRealParts_ReturnsCorrectAnswer()
        {
            Complex z1 = new Complex(2, 0);
            Complex z2 = new Complex(4, 0);

            Complex computedAnswer = z2/z1;

            Complex expectedAnswer = new Complex(2, 0);
            Assert.IsTrue(expectedAnswer == computedAnswer);
        }

        [TestMethod]
        public void Division_OnlyImaginaryParts_ReturnsCorrectAnswer()
        {
            Complex z1 = new Complex(0, 2);
            Complex z2 = new Complex(0, 4);

            Complex computedAnswer = z2 / z1;

            Complex expectedAnswer = new Complex(2, 0);
            Assert.IsTrue(expectedAnswer == computedAnswer);
        }

        [TestMethod]
        public void Division_RealAndImaginaryParts_ReturnsCorrectAnswer()
        {
            Complex z1 = new Complex(1, 1);
            Complex z2 = new Complex(1, -1);

            Complex computedAnswer = z2 / z1;

            Complex expectedAnswer = new Complex(0, -1);
            Assert.IsTrue(expectedAnswer == computedAnswer);
        }

        [TestMethod]
        public void NthRoots_RealNumberIdentityRoot_ReturnsCorrectAnswer()
        {
            Complex z1 = new Complex(4, 0);

            List<Complex> computedAnswer = Complex.NthRoots(z1, 1);

            Assert.AreEqual(1, computedAnswer.Count);
            Assert.IsTrue(computedAnswer[0].Re.Eq(4));
            Assert.IsTrue(computedAnswer[0].Im.Eq(0));
        }

        [TestMethod]
        public void NthRoots_RealNumberSquareRoot_ReturnsCorrectAnswer()
        {
            Complex z1 = new Complex(4, 0);

            int rootInt = 2;
            List<Complex> computedAnswer = Complex.NthRoots(z1, rootInt);

            Assert.AreEqual(rootInt, computedAnswer.Count);

            Complex root1 = new Complex(2, 0);
            Complex root2 = new Complex(-2, 0);

            Assert.AreEqual(rootInt, computedAnswer.Count);
            Assert.IsTrue(computedAnswer.Exists(x => x == root1));
            Assert.IsTrue(computedAnswer.Exists(x => x == root2));
        }

        [TestMethod]
        public void NthRoots_ImaginaryNumberCubedRoot_ReturnsCorrectAnswer()
        {
            Complex z1 = new Complex(-1, 1);

            int rootInt = 3;
            List<Complex> computedAnswer = Complex.NthRoots(z1, rootInt);

            Assert.AreEqual(rootInt, computedAnswer.Count);

            double rootR = Math.Pow(2, 1/6.0);
            double a1 = rootR*Math.Cos(Math.PI/4);
            double b1 = rootR*Math.Sin(Math.PI/4);
            double a2 = rootR * Math.Cos(11*Math.PI / 12);
            double b2 = rootR * Math.Sin(11*Math.PI / 12);
            double a3 = rootR * Math.Cos(19*Math.PI / 12);
            double b3 = rootR * Math.Sin(19*Math.PI / 12);

            Complex root1 = new Complex(a1, b1);
            Complex root2 = new Complex(a2, b2);
            Complex root3 = new Complex(a3, b3);

            Assert.AreEqual(rootInt, computedAnswer.Count);
            Assert.IsTrue(computedAnswer.Exists(x => x == root1));
            Assert.IsTrue(computedAnswer.Exists(x => x == root2));
            Assert.IsTrue(computedAnswer.Exists(x => x == root3));
        }
    }
}
