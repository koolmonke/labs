using System.Collections.Generic;
using System.Linq;

namespace MatrixArithmetic
{
    public static class VectorExt
    {
        public static Vector ToVector(this IEnumerable<double> enumerable) => Vector.From(enumerable.ToArray());

        public static Matrix ToMatrix(this Vector vector)
        {
            var n = vector.N;
            var result = new double[n, 1];


            for (int i = 0; i < n; i++)
            {
                result[i, 0] = vector[i];
            }

            return Matrix.From(result);
        }
    }
}