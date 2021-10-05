using System;
using System.Linq;

namespace MatrixArithmetic
{
    internal static class CommonExtensionMethods
    {
        internal static Matrix ToMatrix(this Vector[] vectors)
        {
            var firstVectorN = vectors[0].N;
            if (vectors.Skip(1).Any(vector => vector.N != firstVectorN))
            {
                throw new Exception("Vectors have different sizes");
            }

            var result = Matrix.WithSize(firstVectorN, vectors.Length);

            for (int i = 0; i < vectors.Length; i++)
            {
                for (int j = 0; j < firstVectorN; j++)
                {
                    result[j, i] = vectors[i][j];
                }
            }

            return result;
        }

        internal static T[][] ToJaggedArray<T>(this T[,] twoDimensionalArray)
        {
            int rowsFirstIndex = twoDimensionalArray.GetLowerBound(0);
            int rowsLastIndex = twoDimensionalArray.GetUpperBound(0);
            int numberOfRows = rowsLastIndex + 1;

            int columnsFirstIndex = twoDimensionalArray.GetLowerBound(1);
            int columnsLastIndex = twoDimensionalArray.GetUpperBound(1);
            int numberOfColumns = columnsLastIndex + 1;

            T[][] jaggedArray = new T[numberOfRows][];
            for (int i = rowsFirstIndex; i <= rowsLastIndex; i++)
            {
                jaggedArray[i] = new T[numberOfColumns];

                for (int j = columnsFirstIndex; j <= columnsLastIndex; j++)
                {
                    jaggedArray[i][j] = twoDimensionalArray[i, j];
                }
            }

            return jaggedArray;
        }
    }
}