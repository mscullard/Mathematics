using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Mathematics.Extensions;
using Mathematics.Polar;

namespace Mathematics.ComplexNumbers
{
    public class Complex
    {
        public double Re;
        public double Im;

        public Complex(double real, double imaginary)
        {
            Re = real;
            Im = imaginary;
        }

        public static Complex Zero
        {
            get
            {
                return new Complex(0,0);   
            }
        }

        public static Complex operator+(Complex z1, Complex z2)
        {
            return new Complex(z1.Re + z2.Re, z1.Im + z2.Im);
        }

        public static Complex operator +(double a, Complex z)
        {
            return new Complex(z.Re + a, z.Im);
        }

        public static Complex operator +(Complex z, double a)
        {
            return a + z;
        }

        public static Complex operator -(Complex z1, Complex z2)
        {
            return new Complex(z1.Re - z2.Re, z1.Im - z2.Im);
        }

        public static Complex operator -(double a, Complex z)
        {
            return new Complex(a - z.Re, z.Im);
        }

        public static Complex operator -(Complex z, double a)
        {
            return new Complex(z.Re - a, z.Im);
        }

        public static Complex operator *(double a, Complex z)
        {
            return new Complex(a*z.Re, a*z.Im);
        }

        public static Complex operator /(Complex z, double a)
        {
            return z / new Complex(a, 0);
        }

        public static Complex operator /(double a, Complex z)
        {
            return new Complex(a, 0) / z;
        }

        public static Complex operator /(Complex z1, Complex z2)
        {
            double realNumerator = z1.Re*z2.Re + z1.Im*z2.Im;
            double complexNumerator = z1.Im*z2.Re - z1.Re*z2.Im;
            double denominator = z2.Re*z2.Re + z2.Im*z2.Im;

            return new Complex(realNumerator/denominator, complexNumerator/denominator);
        }

        public static bool operator ==(Complex z1, Complex z2)
        {
            return z1.Re.Eq(z2.Re) && z1.Im.Eq(z2.Im);
        }

        public static bool operator !=(Complex z1, Complex z2)
        {
            return !z1.Re.Eq(z2.Re) || !z1.Im.Eq(z2.Im);
        }

        public override string ToString()
        {
            return (String.Format("{0} + {1}i", Re, Im));
        }

        public static List<Complex> NthRoots(Complex z, int n)
        {
            PolarCoordinates pc = ConvertToPolarCoordinates(z);
            double term1 = Math.Pow(pc.R, 1/(double) n);

            List<Complex> roots = new List<Complex>();
            for(int i = 0; i < n; i++)
            {
                double a = term1 * Math.Cos((pc.Theta + 2 * i * Math.PI) / n);
                double b = term1 * Math.Sin((pc.Theta + 2 * i * Math.PI) / n);

                Complex root = new Complex(a, b);

                roots.Add(root);
            }

            return roots;
        }

        public static Complex Pow(Complex z, double exponent)
        {
            PolarCoordinates pc = ConvertToPolarCoordinates(z);

            double a = Math.Pow(pc.R, exponent)*Math.Sin(exponent*pc.Theta);
            double b = Math.Pow(pc.R, exponent)*Math.Cos(exponent*pc.Theta);

            return new Complex(a, b);
        }

        public static PolarCoordinates ConvertToPolarCoordinates(Complex z)
        {
            double r = Math.Sqrt(z.Re*z.Re + z.Im*z.Im);
            double theta;
            if (z.Re > 0) 
            { 
                theta = Math.Atan(z.Im/z.Re);
            }
            else
            {
                if (z.Re < 0)
                {
                    theta = Math.Atan(z.Im/z.Re) + Math.PI;
                }
                else // Re part equals 0
                {
                    if (z.Im > 0)
                    {
                        theta = Math.PI/2;
                    }
                    else
                    {
                        theta = -Math.PI/2;
                    }

                }
            }

            return new PolarCoordinates(r, theta);
        }
    }
}
