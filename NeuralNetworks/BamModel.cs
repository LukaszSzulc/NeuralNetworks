namespace NeuralNetworks
{
    using NeuralNetworks.Common;

    public class BamModel
    {
        private readonly int rows;

        private readonly int columns;

        public int[][] CorrectionalMatrix { get; private set; }


        public BamModel(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            CorrectionalMatrix = new int[rows][];
            for (var i = 0; i < CorrectionalMatrix.Length; i++)
            {
                CorrectionalMatrix[i] = new int[columns];
            }
        }


        public void Train(int[] image, int[] name)
        {
            var temporaryArray = NeuralNetworksHelpers.CreateTemporaryMatrix(rows, columns);

            FindCorrelationBeetweanImageAndName(image, name, temporaryArray);

            CorrectionalMatrix = NeuralNetworksHelpers.AddMatrixes(CorrectionalMatrix, temporaryArray);
        }

        private static void FindCorrelationBeetweanImageAndName(int[] image, int[] name, int[][] temporaryArray)
        {
            for (var i = 0; i < image.Length; i++)
            {
                for (var j = 0; j < name.Length; j++)
                {
                    if (image[i] == name[j])
                    {
                        temporaryArray[i][j] = 1;
                    }
                    else
                    {
                        temporaryArray[i][j] = -1;
                    }
                }
            }
        }
    }
}
