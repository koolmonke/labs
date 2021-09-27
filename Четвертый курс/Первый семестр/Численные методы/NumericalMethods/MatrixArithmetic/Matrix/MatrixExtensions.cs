namespace MatrixArithmetic
{
    public static class MatrixExtensions
    {
        public static Vector ToVectorByColumn(this Matrix matrix, int column = 0)
        {
            if (matrix.M != 1)
            {
                throw new VectorDifferentDimException();
            }

            var vector = Vector.WithSize(matrix.N);

            for (int i = 0; i < matrix.N; i++)
            {
                vector[i] = matrix[i, column];
            }

            return vector;
        }

        public static Vector ToVectorByRow(this Matrix matrix, int row = 0)
        {
            if (matrix.M != 1)
            {
                throw new VectorDifferentDimException();
            }

            var vector = Vector.WithSize(matrix.M);

            for (int i = 0; i < matrix.M; i++)
            {
                vector[i] = matrix[row, i];
            }

            return vector;
        }
    }
}