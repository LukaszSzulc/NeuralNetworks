namespace NeuralNetworks.Tests
{
	using Xunit;

	public class Bcm : IClassFixture<BcmNeuralFixture>
	{
		private readonly BcmNeuralFixture fixture;

		public Bcm(BcmNeuralFixture fixture)
		{
			this.fixture = fixture;
		}

	    [Fact]
		public void MatrixTrainedWithVectorShouldContainsTwoNotZeroRows()
		{
            fixture.TrainNeuralNetworkWithSingleVector();

			Assert.Equal(NeuralNetworkTestHelper.BuildVectorFromArray(new [] {1.0f,1,0,0,0}),fixture.GetFirstRowOfCorrelationMatrix());
		}

		[Fact]
		public void TraningMatrixWithSecondVectorShouldNotChangeFirstRow()
		{
            fixture.TrainNeuralNetworkWithTwoVectors();

			Assert.Equal(NeuralNetworkTestHelper.BuildVectorFromArray(new[] { 1.0f, 1, 0, 0, 0 }), fixture.GetFirstRowOfCorrelationMatrix());
			Assert.Equal(NeuralNetworkTestHelper.BuildVectorFromArray(new[] { 1.0f, 1, 0, 0, 1 }), fixture.GetSecondRowOfCorrelationMatrix());
		}

		[Fact]
		public void TrainedMatrixShouldKnowProvidedVector()
        { 
            fixture.TrainNeuralNetworkWithTwoVectors();

		    var resultOfTest = fixture.VerifyKnownVector();

			Assert.True(resultOfTest);
		}


		[Fact]
		public void TrainedMatrixShouldNotKnowProvidedVector()
		{
			fixture.TrainNeuralNetworkWithTwoVectors();

		    var resultOfTest = fixture.VerifyUnknownVector();

			Assert.False(resultOfTest);
		}
	}
}
