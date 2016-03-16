namespace NeuralNetworks
{
    class BamModel
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
    }
}
