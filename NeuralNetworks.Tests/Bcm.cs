namespace NeuralNetworks.Tests
{
	using System;
	using System.Data;

	using MathNet.Numerics.LinearAlgebra;

	using Xunit;

	public class Bcm : IClassFixture<NeuralNetworkFixture>
	{
		private readonly NeuralNetworkFixture fixture;

		public Bcm(NeuralNetworkFixture fixture)
		{
			this.fixture = fixture;
		}

		const int Size = 5;
		[Fact]
		public void MatrixTrainedWithVectorShouldContainsTwoNotZeroRows()
		{
			var vector = fixture.BuildVectorFromArray(new[] { 1.0f, 1, 0, 0, 0 });
		  
			var bcmModel = new BcmModel(Size);

			bcmModel.Train(vector);

			Assert.Equal(fixture.BuildVectorFromArray(new [] {1.0f,1,0,0,0}),bcmModel.CorrelationMatrix.Row(0));
		}

		[Fact]
		public void TraningMatrixWithSecondVectorShouldNotChangeFirstRow()
		{
			var firstVector = fixture.BuildVectorFromArray(new[] { 1.0f, 1, 0, 0, 0 });
			var secondVector = fixture.BuildVectorFromArray(new[] { 0.0f, 1, 0, 0, 1 });
			var bcmModel = new BcmModel(Size);

			bcmModel.Train(firstVector);
			bcmModel.Train(secondVector);

			Assert.Equal(fixture.BuildVectorFromArray(new[] { 1.0f, 1, 0, 0, 0 }), bcmModel.CorrelationMatrix.Row(0));
			Assert.Equal(fixture.BuildVectorFromArray(new[] { 1.0f, 1, 0, 0, 1 }), bcmModel.CorrelationMatrix.Row(1));

		}

		[Fact]
		public void TrainedMatrixShouldKnowProvidedVector()
		{
			var firstVector = fixture.BuildVectorFromArray(new[] { 1.0f, 1, 0, 0, 0 });
			var secondVector = fixture.BuildVectorFromArray(new[] { 0.0f, 1, 0, 0, 1 });
			var bcmModel = new BcmModel(Size);
			bcmModel.Train(firstVector);
			bcmModel.Train(secondVector);

			var resultOfTest = bcmModel.Test(fixture.BuildVectorFromArray(new[] { 0.0f, 1, 0, 0, 1 }));

			Assert.True(resultOfTest);
		}


		[Fact]
		public void TrainedMatrixShouldNotKnowProvidedVector()
		{
			var firstVector = fixture.BuildVectorFromArray(new[] { 1.0f, 1, 0, 0, 0 });
			var secondVector = fixture.BuildVectorFromArray(new[] { 0.0f, 1, 0, 0, 1 });
			var bcmModel = new BcmModel(Size);
			bcmModel.Train(firstVector);
			bcmModel.Train(secondVector);

			var resultOfTest = bcmModel.Test(fixture.BuildVectorFromArray(new[] { 0.0f, 0, 0, 0, 1 }));

			Assert.False(resultOfTest);
		}
	}
}
