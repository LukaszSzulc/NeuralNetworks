namespace NeuralNetworks
{
    using MathNet.Numerics.LinearAlgebra;

    using NeuralNetworks.Common;

    public class BcmModel
    {

        const int Threshold = 2;

        private readonly Matrix<float> _correlationMatrix;

        public Matrix<float> CorrelationMatrix => _correlationMatrix;
         
        public BcmModel(int size)
        {
            _correlationMatrix = Matrix<float>.Build.DenseOfArray(new float[size,size]);
        }

        public void Train(Vector<float> vector)
        {
            for (int i = 0; i < vector.Count; i++)
            {
                for (var j = 0; j < vector.Count; j++)
                {
                    if ((int)vector[i] * (int)vector[j] == 1)
                    {
                        _correlationMatrix[i,j] = 1;
                    }
                }
            }
        }

        public bool Test(Vector<float> vector)
        {
            var resultVector = (vector * _correlationMatrix).Map(x => x>= Threshold ? 1.0f : 0.0f);
            return resultVector.Equals(vector);
        }
    }
}
