namespace NeuralNetworks
{
    using NeuralNetworks.Common;

    public class BcmModel
    {
        private readonly int matrixSize;

        const int Threshold = 2;
        public int[][] CorrelationMatrix { get; private set; }
        public BcmModel(int matrixSize)
        {
            this.matrixSize = matrixSize;
            InitializeMatrix();
        }

        public void Train(int[] vector)
        {

            var temporaryArray = NeuralNetworksHelpers.CreateTemporaryMatrix(matrixSize, matrixSize);
            for (int i = 0; i < vector.Length; i++)
            {
                for (var j = 0; j < vector.Length; j++)
                {
                    if (vector[i] * vector[j] == 1)
                    {
                        temporaryArray[i][j]++;
                    }
                }
            }

            CorrelationMatrix = NeuralNetworksHelpers.AddMatrixesWithBinaryCutout(temporaryArray, CorrelationMatrix);
        }

        public bool Test(int[] vector)
        {
            var resultVector = NeuralNetworksHelpers.MultiplyVectorWithMatrix(vector,CorrelationMatrix,matrixSize,matrixSize);
            NormalizeWithThreshold(resultVector);
            return VerifyVectors(vector, resultVector);
        }

        private bool VerifyVectors(int[] vector, int[] resultVector)
        {
            for (var i = 0; i < vector.Length; i++)
            {
                if (vector[i] != resultVector[i])
                {
                    return false;
                }
            }

            return true;
        }

        private void NormalizeWithThreshold(int[] vector)
        {
            for (var i = 0; i < vector.Length; i++)
            {

                vector[i] /= Threshold;
            }
        }

        private void InitializeMatrix()
        {
            CorrelationMatrix = new int[matrixSize][];
            for (var i = 0; i < matrixSize; i++)
            {
                CorrelationMatrix[i] = new int[matrixSize];
            }
        }
    }
}
