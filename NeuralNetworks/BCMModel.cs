namespace NeuralNetworks
{
    using MathNet.Numerics.LinearAlgebra;

    public class BcmModel
    {

        const int Threshold = 2;

        private readonly Matrix<float> correlationMatrix;

        public Matrix<float> CorrelationMatrix => correlationMatrix;
         
        public BcmModel(int size)
        {
            correlationMatrix = Matrix<float>.Build.DenseOfArray(new float[size,size]);
        }

        public void Train(Vector<float> vector)
        {
            for (int i = 0; i < vector.Count; i++)
            {
                for (var j = 0; j < vector.Count; j++)
                {
                    if ((int)vector[i] * (int)vector[j] == 1)
                    {
                        correlationMatrix[i,j] = 1;
                    }
                }
            }
        }

        public bool Test(Vector<float> vector)
        {
            var resultVector = (vector * correlationMatrix).Map(x => x>= Threshold ? 1.0f : 0.0f);
            return resultVector.Equals(vector);
        }
    }
}
