namespace NeuralNetworks.Tests
{
	using System.Data;

	using Xunit;

	public class Bcm
	{
		[Fact]
		public void MatrixTrainedWithVectorShouldContainsTwoNotZeroRows()
		{
			int size = 5;
			var vector = new[] { 1,1,0,0,0};
			var bcmModel = new BcmModel(size);

			bcmModel.Train(vector);

			Assert.Equal(new [] {1,1,0,0,0},bcmModel.CorrelationMatrix[0]);
		}

	    [Fact]
	    public void TraningMatrixWithSecondVectorShouldNotChangeFirstRow()
	    {
            int size = 5;
            var firstVector = new[] { 1, 1, 0, 0, 0 };
            var secondVector = new[] { 0, 1, 0, 0, 1 };
            var bcmModel = new BcmModel(size);

            bcmModel.Train(firstVector);
			bcmModel.Train(secondVector);

            Assert.Equal(new[] { 1, 1, 0, 0, 0 }, bcmModel.CorrelationMatrix[0]);
            Assert.Equal(new[] { 1, 1, 0, 0, 1 }, bcmModel.CorrelationMatrix[1]);

        }
    }
}
