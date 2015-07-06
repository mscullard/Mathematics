using System;
using System.Linq;

namespace Mathematics.LinearAlgebra.Data
{
    public class Vector : IVector
    {
        private readonly double[] _array;

        public int Size
        {
            get { return _array.Count(); }
        }

        public Vector(double[] array)
        {
            _array = array;
        }

        public double this[int i]
        {
            get { return _array[i]; }
            set { _array[i] = value; }
        }

        public static Vector operator *(double a, Vector v)
        {
            double[] resultArray = new double[v.Size];
            for (int i = 0; i < v.Size; i++)
            {
                resultArray[i] = v._array[i];
            }

            return new Vector(resultArray);
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            if (v1.Size != v2.Size)
            {
                throw new Exception("Cannot add vectors of different sizes.");
            }

            double[] resultArray = new double[v1.Size];
            for (int i = 0; i < v1.Size; i++)
            {
                resultArray[i] = v1._array[i] + v2._array[i];
            }

            return new Vector(resultArray);
        }

        public static Vector operator -(Vector v1, Vector v2)
        {
            return v1 + (-1) * v2;
        }

        public double Norm()
        {
            return Math.Sqrt(_array.Sum(x => x * x));
        }

        public double[] ToArray()
        {
            return (double[])_array.Clone();
        }
    }
}
