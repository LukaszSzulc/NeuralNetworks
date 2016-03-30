using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworks.Tests
{
    using System.Globalization;

    using NetNumerics;

    using Xunit;
    using Xunit.Abstractions;

    public class NumericsTests
    {

        private readonly ITestOutputHelper output;

        public NumericsTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void Execute()
        {
            var math = new Class1();
            var multiplyByVector = math.MultiplyVectorByScalar();

            foreach (var d in multiplyByVector)
            {
                output.WriteLine(d.ToString());
            }
        }
    }
}
