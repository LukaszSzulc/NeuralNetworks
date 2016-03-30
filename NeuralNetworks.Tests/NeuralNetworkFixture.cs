using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworks.Tests
{
    using MathNet.Numerics.LinearAlgebra;

    public class NeuralNetworkFixture
    {
        public NeuralNetworkFixture()
        {
            
        }

        public Vector<float> BuildVectorFromArray(float[] vector)
        {
            return Vector<float>.Build.DenseOfArray(vector);
        } 
    }
}
