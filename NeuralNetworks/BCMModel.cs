using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworks
{
    public class BcmModel
    {
        private readonly int matrixSize;

        const int Threshold = 2;
        public int[][] CorrelationMatrix { get; private set; }
        public BcmModel(int matrixSize)
        {
            this.matrixSize = matrixSize;
            InitializeMatrix(matrixSize);
        }

        public void Train(int[] vector)
        {
            
            var temporaryArray = CreateTemporaryArray();
            for (int i = 0; i < vector.Length; i++)
            {
                for (var j = 0; j < vector.Length; j++)
                {
                    if (vector[i] * vector[j] == 1)
                    {
                        temporaryArray[i][j]++;
                    }
                }
            }

            AddTemporaryArrayToCorrectionalMatrix(temporaryArray);
        }

        public bool Test(int[] vector)
        {
            var resultVector = MultiplyVectorWithMatrix(vector);
            NormalizeWithThreshold(resultVector);
            return VerifyVectors(vector, resultVector);
        }

        private bool VerifyVectors(int[] vector, int[] resultVector)
        {
            for (var i = 0; i < vector.Length; i++)
            {
                if (vector[i] != resultVector[i])
                {
                    return false;
                }
            }

            return true;
        }

        private void NormalizeWithThreshold(int[] vector)
        {
            for (var i = 0; i < vector.Length; i++)
            {
                vector[i] /= Threshold;
            }
        }

        private void InitializeMatrix(int matrixSize)
        {
            CorrelationMatrix = new int[matrixSize][];
            for (var i = 0; i < matrixSize; i++)
            {
                CorrelationMatrix[i] = new int[matrixSize];
            }
        }

        private int[][] CreateTemporaryArray()
        {
            var temporaryArray = new int[CorrelationMatrix.Length][];
            for (var i = 0; i < temporaryArray.Length; i++)
            {
                temporaryArray[i] = new int[temporaryArray.Length];
            }

            return temporaryArray;
        }

        private void AddTemporaryArrayToCorrectionalMatrix(IReadOnlyList<int[]> temporaryArray)
        {
            for (var i = 0; i < temporaryArray.Count; i++)
            {
                for (var j = 0; j < temporaryArray.Count; j++)
                {
                    CorrelationMatrix[i][j] += temporaryArray[i][j];
                    if (CorrelationMatrix[i][j] > 1)
                    {
                        CorrelationMatrix[i][j] = 1;
                    }
                }
            }
        }


        private int[] MultiplyVectorWithMatrix(int[] vector)
        {
            var result = new int[1][];
            result[0] = new int[vector.Length];
            var matrix = new int[1][];
            matrix[0] = vector;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                
                for (int j = 0; j < matrixSize; j++)
                {
                    int temp = 0;
                    for (int k = 0; k < matrixSize; k++)
                    {
                        temp += matrix[i][k] * CorrelationMatrix[k][j];
                    }

                    result[i][j] = temp;
                }
            }

            return result[0];
        }
    }
}
