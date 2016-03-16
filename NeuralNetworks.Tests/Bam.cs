namespace NeuralNetworks.Tests
{
    using Xunit;

    public class Bam
    {
        [Fact]
        public void Execute()
        {
            var bam = new BamModel(6, 4);
            bam.Train(new[] { 0, 1, 1, 1, 0, 1 }, new[] { 1, 1, 0, 0 });
            bam.Train(new[] { 1, 0, 0, 1, 0, 0 }, new[] { 1, 0, 1, 0 });

        }
    }
}
