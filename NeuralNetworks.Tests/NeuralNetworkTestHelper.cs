namespace NeuralNetworks.Tests
{
    using MathNet.Numerics.LinearAlgebra;

    public static class NeuralNetworkTestHelper
    {
        public static Vector<float> BuildVectorFromArray(float[] vector)
        {
            return Vector<float>.Build.DenseOfArray(vector);
        }

        public static Matrix<float> CreateMatrixFromFloatMatrix(float[,] matrix)
        {
            return Matrix<float>.Build.DenseOfArray(matrix);
        }

    }
}