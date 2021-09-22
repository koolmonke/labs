using System.Collections.Generic;
using System.Linq;

namespace MatrixArithmetic
{
    public static class VectorExt
    {
        public static Vector ToVector(this IEnumerable<double> enumerable) => Vector.From(enumerable.ToArray());

        public static Matrix ToMatrix(this IEnumerable<double> enumerable)
        {
            var vector = enumerable.ToArray();

            return Matrix.From(new[] { vector });
        }
    }
}