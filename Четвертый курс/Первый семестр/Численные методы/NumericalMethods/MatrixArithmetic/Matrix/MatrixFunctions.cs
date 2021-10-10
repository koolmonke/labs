using System.Linq;

namespace MatrixArithmetic
{
    public static class MatrixFunctions
    {
        public static double[,] ConcatHorizontally(this double[,] matrix1, double[,] matrix2)
        {
            var rowCount = matrix1.GetLength(0);


            var matrix1Cols = matrix1.GetLength(1);
            var matrix2Cols = matrix2.GetLength(1);

            double[,] output = new double[rowCount, matrix1Cols + matrix2Cols];
            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < matrix1Cols + matrix2Cols; col++)
                {
                    if (col < matrix1Cols)
                        output[row, col] = matrix1[row, col];
                    else
                        output[row, col] = matrix2[row, col - matrix1Cols];
                }
            }

            return output;
        }

        /// <summary>
        /// Reduces matrix to row-echelon (REF/Gauss) or reduced row-echelon (RREF/Gauss-Jordan) form and solves for augmented columns (if any.)
        /// </summary>
        public static MatrixEliminationResult Eliminate(this double[,] input, MatrixReductionForm form,
            int augmentedCols = 0)
        {
            int totalRowCount = input.GetLength(0);
            int totalColCount = input.GetLength(1);


            var result = new MatrixEliminationResult();

            double[,] output = CreateCopy(input);

            int numPivots = 0;

            for (int col = 0; col < totalColCount - augmentedCols; col++)
            {
                int? pivotRow = FindPivot(output, numPivots, col, totalRowCount);

                if (pivotRow == null)
                    continue;

                ReduceRow(output, pivotRow.Value, col, totalColCount);

                SwitchRows(output, pivotRow.Value, numPivots, totalColCount);

                pivotRow = numPivots;
                numPivots++;

                if (form == MatrixReductionForm.ReducedRowEchelonForm)
                {
                    for (int tmpRow = 0; tmpRow < pivotRow; tmpRow++)
                        EliminateRow(output, tmpRow, pivotRow.Value, col, totalColCount);
                }

                for (int tmpRow = pivotRow.Value; tmpRow < totalRowCount; tmpRow++)
                    EliminateRow(output, tmpRow, pivotRow.Value, col, totalColCount);
            }

            result.FullMatrix = Matrix.From(output);
            result.UnknownsCount = augmentedCols;
            result.TotalRowCount = totalRowCount;
            result.TotalColumnCount = totalColCount;
            result.AugmentedColumnCount = augmentedCols;

            result.AugmentedColumns = Matrix.From(ExtractColumns(output, result.UnknownsCount, totalColCount - 1));
            if (augmentedCols > 0 && form == MatrixReductionForm.ReducedRowEchelonForm)
            {
                // matrix has solution 
                result = FindSolution(result);
            }

            return result;
        }

        public static MatrixEliminationResult FindSolution(MatrixEliminationResult result)
        {
            double?[]? solution = null;


            if (result.AugmentedColumnCount == 1)
            {
                var solutionState = result.UnknownsCount > result.TotalRowCount
                    ? MatrixSolutionState.Infinite
                    : MatrixSolutionState.Unique;

                solution = new double?[result.UnknownsCount];

                int pivotRow = 0;
                for (int col = 0; col < result.UnknownsCount; col++)
                {
                    double unknownValue = result.FullMatrix![pivotRow, col];
                    double solutionValue = result.FullMatrix[pivotRow, result.TotalColumnCount - 1];

                    if (unknownValue == 1)
                    {
                        solution[col] = solutionValue;

                        pivotRow++;
                    }
                    else
                    {
                        if (solutionState == MatrixSolutionState.Unique)
                        {
                            // still on default value
                            solutionState = solutionValue == 0
                                ? MatrixSolutionState.Infinite
                                : MatrixSolutionState.None;
                        }
                    }
                }
            }

            result.Solution = solution;

            return result;
        }

        public static int? FindPivot(double[,] input, int startRow, int col, int rowCount)
        {
            for (int i = startRow; i < rowCount; i++)
            {
                if (input[i, col] != 0)
                    return i;
            }

            return null;
        }

        public static void ReduceRow(this double[,] input, int row, int col, int colCount)
        {
            var coefficient = 1.0 / input[row, col];

            if (coefficient == 1)
                return;

            for (; col < colCount; col++)
                input[row, col] *= coefficient;
        }

        public static void EliminateRow(this double[,] input, int row, int pivotRow, int pivotCol, int colCount)
        {
            if (pivotRow == row)
                return;

            if (input[row, pivotCol] == 0)
                return;

            double coefficient = input[row, pivotCol];

            for (int col = pivotCol; col < colCount; col++)
            {
                input[row, col] -= input[pivotRow, col] * coefficient;
            }
        }

        public static void SwitchRows(this double[,] input, int row1, int row2, int colCount)
        {
            if (row1 == row2)
                return;

            for (int col = 0; col < colCount; col++)
            {
                (input[row1, col], input[row2, col]) = (input[row2, col], input[row1, col]);
            }
        }

        public static double[,] CreateCopy(double[,] input)
        {
            var rowCount = input.GetLength(0);
            var colCount = input.GetLength(1);

            double[,] output = new double[rowCount, colCount];

            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < colCount; col++)
                {
                    output[row, col] = input[row, col];
                }
            }

            return output;
        }


        public static double[,] ExtractColumns(this double[,] input, int startCol, int endCol)
        {
            return ExtractColumns(input, Enumerable.Range(startCol, endCol - startCol + 1).ToArray());
        }

        public static double[,] ExtractColumns(this double[,] input, int[] cols)
        {
            cols = cols.Distinct().ToArray();
            int rowCount = input.GetLength(0);
            int colCount = input.GetLength(1);
            double[,] output = new double[rowCount, cols.Length];

            for (int row = 0; row < rowCount; row++)
            {
                int i = 0;
                for (int col = 0; col < colCount; col++)
                {
                    if (cols.Contains(col) == false)
                        continue;
                    output[row, i] = input[row, col];
                    i++;
                }
            }

            return output;
        }
    }
}