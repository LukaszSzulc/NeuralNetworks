namespace NeuralNetworks.Tests
{
    using System.Data;

    using MathNet.Numerics.LinearAlgebra;

    public class BamNeuralNetworkFixture
    {
        const int Rows = 6;

        const int Cols = 4;

        internal BamModel Bam { get;}

        public BamNeuralNetworkFixture()
        {
            Bam = new BamModel(Rows, Cols);
        }

        
        public float[,] CreateBamCorrelationResultMatrix()
        {
           return new float[,]
                             {
                                 { 0, -2, 2, 0 }, { 0, 2, -2, 0 }, { 0, 2, -2, 0 }, { 2, 0, 0, -2 }, { -2, 0, 0, 2 }, { 0, 2, -2, 0 }
                             };
        }

        public float[,] CreateBamNamesResult()
        {
            return new[,] { { 1.0f, 1, 0, 0 }, { 1, 0, 1, 0 } };
        }

        public float[,] CreateBamImageResult()
        {
            return new[,] { {0.0f,1,1,1,0,1}, {1,0,0,1,0,0} };
        }

        public void TrainNetwork()
        {
            Bam.Train(
                NeuralNetworkTestHelper.BuildVectorFromArray(new[] { 0.0f, 1, 1, 1, 0, 1 }),
                NeuralNetworkTestHelper.BuildVectorFromArray(new[] { 1.0f, 1, 0, 0 }));
            Bam.Train(
                NeuralNetworkTestHelper.BuildVectorFromArray(new[] { 1.0f, 0, 0, 1, 0, 0 }),
                NeuralNetworkTestHelper.BuildVectorFromArray(new[] { 1.0f, 0, 1, 0 }));
        }

        public Matrix<float> GetName()
        {
            var firstImage = NeuralNetworkTestHelper.BuildVectorFromArray(new[] { 0.0f, 1, 1, 1, 0, 0 });
            var secondImage = NeuralNetworkTestHelper.BuildVectorFromArray(new[] { 1.0f, 0, 0, 1, 0, 0 });
            var knownName = Bam.TestName(firstImage, secondImage);
            return knownName;
        }

        public Matrix<float> GetImage()
        {
            var firstImage = NeuralNetworkTestHelper.BuildVectorFromArray(new[] { 1.0f, 1, 0, 0 });
            var secondImage = NeuralNetworkTestHelper.BuildVectorFromArray(new[] { 1.0f, 0, 1, 0 });

            var knownImage = Bam.TestImage(firstImage, secondImage);

            return knownImage;
        } 

    }
}
