using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworks.Common
{
    public static class NeuralNetworksHelpers
    {
        public static int[][] CreateTemporaryMatrix(int rows, int cols)
        {
            var temporaryMatrix = new int[rows][];
            for (var i = 0; i < temporaryMatrix.Length; i++)
            {
                temporaryMatrix[i] = new int[cols];
            }

            return temporaryMatrix;
        }

        public static int[][] AddMatrixes(int[][] firstMatrix, int[][] secondMatrix)
        {
            var resultMatrix = CreateTemporaryMatrix(firstMatrix.Length, firstMatrix.First().Length);
            for (var i = 0; i < firstMatrix.Length; i++)
            {
                for (var j = 0; j < firstMatrix[i].GetLength(0); j++)
                {
                    resultMatrix[i][j] = firstMatrix[i][j] + secondMatrix[i][j];
                }
            }

            return resultMatrix;
        }

        public static int[][] AddMatrixesWithBinaryCutout(int[][] firstMatrix, int[][] secondMatrix)
        {
            var resultMatrix = CreateTemporaryMatrix(firstMatrix.Length, firstMatrix.Length);
            for (var i = 0; i < firstMatrix.Length; i++)
            {
                for (var j = 0; j < firstMatrix.Length; j++)
                {
                    resultMatrix[i][j] = firstMatrix[i][j] + secondMatrix[i][j];
                    if (resultMatrix[i][j] > 1)
                    {
                        resultMatrix[i][j] = 1;
                    }
                }
            }

            return resultMatrix;
        }

        public static int[] MultiplyVectorWithMatrix(int[] vector, int[][] matrix, int rows, int cols)
        {
            var result = new int[1][];
            result[0] = new int[vector.Length];
            var resultMatrix = new int[1][];
            resultMatrix[0] = vector;
            for (int i = 0; i < resultMatrix.GetLength(0); i++)
            {

                for (int j = 0; j < cols; j++)
                {
                    int temp = 0;
                    for (int k = 0; k < vector.GetLength(0); k++)
                    {
                        temp += resultMatrix[i][k] * matrix[k][j];
                    }

                    result[i][j] = temp;
                }
            }

            return result[0];
        }
    }
}
