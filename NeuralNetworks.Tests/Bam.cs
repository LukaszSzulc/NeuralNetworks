namespace NeuralNetworks.Tests
{
    using Xunit;
    using Xunit.Abstractions;

    public class Bam : IClassFixture<BamNeuralNetworkFixture>
    {
        private readonly BamNeuralNetworkFixture fixture;

        private readonly ITestOutputHelper output;

        public Bam(BamNeuralNetworkFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void TrainingMethodShouldCreateCorrectCorrelationMatrix()
        {
            fixture.TrainNetwork();

            Assert.Equal(NeuralNetworkTestHelper.CreateMatrixFromFloatMatrix(fixture.CreateBamCorrelationResultMatrix()), fixture.Bam.CorrectionalMatrix);
        }

        [Fact]
        public void WhenUserAskForNameItShouldReceiveCorrectValues()
        {
            fixture.TrainNetwork();


            var knownName = fixture.GetName();


            Assert.Equal(NeuralNetworkTestHelper.CreateMatrixFromFloatMatrix(fixture.CreateBamNamesResult()), knownName);
        }
     
        
        [Fact]
        public void WhenUserAskForImageItShouldReceiveCorrectValues()
        {
            fixture.TrainNetwork();

            var knownImage = fixture.GetImage();

            Assert.Equal(NeuralNetworkTestHelper.CreateMatrixFromFloatMatrix(fixture.CreateBamImageResult()), knownImage);
        }


    }
}
