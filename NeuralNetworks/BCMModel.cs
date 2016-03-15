﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworks
{
    public class BcmModel
    {
        public int[][] CorrelationMatrix { get; private set; }
        public BcmModel(int matrixSize)
        {
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

        public void Test(int[] vector)
        {
            
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
            return new int[10];
        }
    }
}