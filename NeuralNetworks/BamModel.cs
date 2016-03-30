namespace NeuralNetworks
{
    using MathNet.Numerics.LinearAlgebra;

    public class BamModel
    {
        private readonly Matrix<float> correlationMatrix;

        public Matrix<float> CorrectionalMatrix => correlationMatrix;


        public BamModel(int rows, int columns)
        {
            correlationMatrix = Matrix<float>.Build.DenseOfArray(new float[rows, columns]);
        }

        public void Train(Vector<float> image, Vector<float> name)
        {
            for (var i = 0; i < image.Count; i++)
            {
                for (var j = 0; j < name.Count; j++)
                {
                    if ((int)image[i] == (int)name[j])
                    {
                        correlationMatrix[i, j] += 1.0f;
                    }
                    else
                    {
                        correlationMatrix[i, j] += -1.0f;
                    }
                }
            }

        }

        public Matrix<float> TestName(Vector<float> firstImage, Vector<float> secondImage)
        {
            var imageMatrix = CreateMatrixFromVector(firstImage, secondImage);
            var namesMatrix = imageMatrix * correlationMatrix;

            var previousNames = namesMatrix;
            var previousImage = imageMatrix;

            while (true)
            {
                imageMatrix = (correlationMatrix * namesMatrix.Map(NormalizeMatrix).Transpose()).Map(NormalizeMatrix);
                namesMatrix = (imageMatrix.Transpose() * correlationMatrix).Map(NormalizeMatrix);
                if (!namesMatrix.Equals(previousNames) && !imageMatrix.Equals(previousImage))
                {
                    previousImage = imageMatrix;
                    previousNames = namesMatrix;                    
                }
                else
                {
                    break;
                }
            }

            return namesMatrix;
        }

        public Matrix<float> TestImage(Vector<float> firstName, Vector<float> secondName)
        {
            var namesMatrix = CreateMatrixFromVector(firstName, secondName);

            var imageMatrix = correlationMatrix * namesMatrix.Transpose();
            var previousNames = namesMatrix;
            var previousImage = imageMatrix;

            while (true)
            {
                imageMatrix = (correlationMatrix * namesMatrix.Map(NormalizeMatrix).Transpose()).Map(NormalizeMatrix);
                namesMatrix = (imageMatrix.Transpose() * correlationMatrix).Map(NormalizeMatrix);
                if (!namesMatrix.Equals(previousNames) && !imageMatrix.Equals(previousImage))
                {
                    previousImage = imageMatrix;
                    previousNames = namesMatrix;
                }
                else
                {
                    break;
                }
            }

            return imageMatrix.Transpose();
        } 

        private Matrix<float> CreateMatrixFromVector(params Vector<float>[] vector)
        {
            return Matrix<float>.Build.DenseOfRowVectors(vector);
        }

   

        private float NormalizeMatrix(float value)
        {
            return value > 0.0f ? 1.0f : 0.0f;
        }
    }
}
