using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetNumerics
{
    using MathNet.Numerics.LinearAlgebra;

    public class Class1
    {
        public Vector<double> MultiplyVectorByScalar()
        {
            Vector<double> vector = Vector<double>.Build.DenseOfArray(new[] { 1.0, 2, 3, 4, 5, 6 });
            var vector1 = vector.Map(
                x =>
                    {
                        if (x > 2)
                        {
                            return 1.0;
                        }

                        return 0.0;
                    });


            return vector1;
        }


        public Matrix<double> MatrixMultiplyScalar()
        {
            var matrix = Matrix<double>.Build.DenseOfArray(new double[,] { { 1, 2, 3 }, { 1, 2, 3 }, { 1, 2, 3 } });
            return matrix * 3;
        }

        public Matrix<double> Transpose()
        {
            Vector<double> vector = Vector<double>.Build.DenseOfArray(new[] { 1.0, 2, 3, 4, 5, 6 });
            return vector.ToColumnMatrix().Transpose();
        }
    }
}
