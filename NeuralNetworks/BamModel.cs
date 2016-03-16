using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworks
{
    class BamModel
    {
        public int[][] CorrectionalMatrix { get; private set; }


        public BamModel(int rows, int columns)
        {
            CorrectionalMatrix = new int[rows][];

        }

    }
}
