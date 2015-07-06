namespace Mathematics.LinearAlgebra.Data
{
    public class Matrix : IMatrix
    {
        public double[,] _matrixArray;

        public Matrix(double[,] matrixArray)
        {
            _matrixArray = matrixArray;
        }
    }
}