namespace NeuralNetworks.Tests
{
    using System;
    using System.Data;

	using Xunit;

	public class Bcm
	{
		const int Size = 5;
		[Fact]
		public void MatrixTrainedWithVectorShouldContainsTwoNotZeroRows()
		{
			var vector = new[] { 1,1,0,0,0};
			var bcmModel = new BcmModel(Size);

			bcmModel.Train(vector);

			Assert.Equal(new [] {1,1,0,0,0},bcmModel.CorrelationMatrix[0]);
		}

		[Fact]
		public void TraningMatrixWithSecondVectorShouldNotChangeFirstRow()
		{
			var firstVector = new[] { 1, 1, 0, 0, 0 };
			var secondVector = new[] { 0, 1, 0, 0, 1 };
			var bcmModel = new BcmModel(Size);

			bcmModel.Train(firstVector);
			bcmModel.Train(secondVector);

			Assert.Equal(new[] { 1, 1, 0, 0, 0 }, bcmModel.CorrelationMatrix[0]);
			Assert.Equal(new[] { 1, 1, 0, 0, 1 }, bcmModel.CorrelationMatrix[1]);

		}

		[Fact]
		public void TrainedMatrixShouldKnowProvidedVector()
		{
			var firstVector = new[] { 1, 1, 0, 0, 0 };
			var secondVector = new[] { 0, 1, 0, 0, 1 };
			var bcmModel = new BcmModel(Size);
			bcmModel.Train(firstVector);
			bcmModel.Train(secondVector);

			var resultOfTest = bcmModel.Test(new[] { 0, 1, 0, 0, 1 });

			Assert.True(resultOfTest);
		}


		[Fact]
		public void TrainedMatrixShouldNotKnowProvidedVector()
		{
			var firstVector = new[] { 1, 1, 0, 0, 0 };
			var secondVector = new[] { 0, 1, 0, 0, 1 };
			var bcmModel = new BcmModel(Size);
			bcmModel.Train(firstVector);
			bcmModel.Train(secondVector);

			var resultOfTest = bcmModel.Test(new[] { 0, 0, 0, 0, 1 });

			Assert.False(resultOfTest);
		}
    }
}
