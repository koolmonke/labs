using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace MatrixArithmetic
{
    public class Matrix
    {
        public int N => Repr.GetLength(0);

        public int M => Repr.GetLength(1);

        public double this[int i, int j]
        {
            get => Repr[i, j];
            set => Repr[i, j] = value;
        }


        public static Matrix operator *(Matrix self, Matrix other)
        {
            var result = Matrix.WithSize(self.N, other.M);

            for (int i = 0; i < self.N; i++)
            {
                for (int j = 0; j < other.M; j++)
                {
                    for (int k = 0; k < self.N; k++)
                    {
                        result[i, j] += self[i, k] * other[k, j];
                    }
                }
            }

            return result;
        }

        public Vector Sole(Vector fVector)
        {
            var newMatrix = ConcatHorizontally(this.Repr, fVector.ToMatrix().Repr);

            var fullMatrix = Eliminate(newMatrix, MatrixReductionForm.ReducedRowEchelonForm, 1).FullMatrix;

            var result = Vector.WithSize(N);

            for (int i = 0; i < N; i++)
            {
                result[i] = fullMatrix[i, N];
            }

            return result;
        }

        public double Det() => StupidDet(Repr.ToJaggedArray());


        public static Matrix Identity(int n)
        {
            var matrix = Matrix.WithSize(n, n);

            for (int i = 0; i < n; i++)
            {
                matrix[i, i] = 1;
            }

            return matrix;
        }

        public Matrix Copy() => new Matrix(Repr);

        public static Matrix WithSize(int n, int m) => new Matrix(n, m);

        public static Matrix From(double[,] values) => new Matrix(values);

        public Matrix Inv()
        {
            var rowCount = Repr.GetLength(0);


            var newMatrix = ConcatHorizontally(Repr, Matrix.Identity(rowCount).Repr);

            var result = Eliminate(newMatrix, MatrixReductionForm.ReducedRowEchelonForm, rowCount);
            return new Matrix(result.AugmentedColumns);
        }

        public Vector ToVector()
        {
            if (M != 1)
            {
                throw new VectorDifferentDimException();
            }

            var vector = Vector.WithSize(N);

            for (int i = 0; i < N; i++)
            {
                vector[i] = Repr[i, 0];
            }

            return vector;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();


            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    builder.Append(
                        $"{Repr[i, j].ToString("+#00.000;-#00.000;000.000", CultureInfo.InvariantCulture)} ");
                }

                if (i < N - 1)
                {
                    builder.Append('\n');
                }
            }

            return builder.ToString();
        }

        private static double StupidDet(double[][] input)
        {
            var n = input.Length;
            double det = 1;
            double[][] b = new double[1][];
            b[0] = new double[n];
            for (int i = 0; i < n; ++i)
            {
                //присваиваем k номер строки
                int k = i;
                //идем по строке от i+1 до конца
                for (int j = i + 1; j < n; ++j)
                    //проверяем
                    if (Math.Abs(input[j][i]) > Math.Abs(input[k][i]))
                        //если равенство выполняется то k присваиваем j
                        k = j;
                //если равенство выполняется то определитель приравниваем 0 и выходим из программы
                var EPS = 0.0001;
                if (Math.Abs(input[k][i]) < EPS)
                {
                    det = 0;
                    break;
                }

                //меняем местами a[i] и a[k]
                b[0] = input[i];
                input[i] = input[k];
                input[k] = b[0];
                //если i не равно k
                if (i != k)
                    //то меняем знак определителя
                    det = -det;
                //умножаем det на элемент a[i][i]
                det *= input[i][i];
                //идем по строке от i+1 до конца
                for (int j = i + 1; j < n; ++j)
                    //каждый элемент делим на a[i][i]
                    input[i][j] /= input[i][i];
                //идем по столбцам
                for (int j = 0; j < n; ++j)
                    //проверяем
                    if (j != i && Math.Abs(input[j][i]) > EPS)
                        //если да, то идем по k от i+1
                        for (k = i + 1; k < n; ++k)
                            input[j][k] -= input[i][k] * input[j][i];
            }

            return det;
        }

        private static double[,] ConcatHorizontally(double[,] matrix1, double[,] matrix2)
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


        private static double[,] CreateCopy(double[,] input)
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

        private static int? FindPivot(double[,] input, int startRow, int col, int rowCount)
        {
            for (int i = startRow; i < rowCount; i++)
            {
                if (input[i, col] != 0)
                    return i;
            }

            return null;
        }

        private static void ReduceRow(double[,] input, int row, int col, int colCount)
        {
            var coefficient = 1.0 / input[row, col];

            if (coefficient == 1)
                return;

            for (; col < colCount; col++)
                input[row, col] *= coefficient;
        }

        private static void EliminateRow(double[,] input, int row, int pivotRow, int pivotCol, int colCount)
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

        private static void SwitchRows(double[,] input, int row1, int row2, int colCount)
        {
            if (row1 == row2)
                return;

            for (int col = 0; col < colCount; col++)
            {
                (input[row1, col], input[row2, col]) = (input[row2, col], input[row1, col]);
            }
        }

        /// <summary>
        /// Reduces matrix to row-echelon (REF/Gauss) or reduced row-echelon (RREF/Gauss-Jordan) form and solves for augmented columns (if any.)
        /// </summary>
        private static MatrixEliminationResult Eliminate(double[,] input, MatrixReductionForm form,
            int augmentedCols = 0)
        {
            int totalRowCount = input.GetLength(0);
            int totalColCount = input.GetLength(1);


            MatrixEliminationResult result = new MatrixEliminationResult();

            double[,] output = CreateCopy(input);

            // number of pivots found
            int numPivots = 0;

            // loop through columns, exclude augmented columns
            for (int col = 0; col < totalColCount - augmentedCols; col++)
            {
                int? pivotRow = FindPivot(output, numPivots, col, totalRowCount);

                if (pivotRow == null)
                    continue; // no pivots, go to another column

                ReduceRow(output, pivotRow.Value, col, totalColCount);

                SwitchRows(output, pivotRow.Value, numPivots, totalColCount);

                pivotRow = numPivots;
                numPivots++;

                // Eliminate Previous Rows
                if (form == MatrixReductionForm.ReducedRowEchelonForm)
                {
                    for (int tmpRow = 0; tmpRow < pivotRow; tmpRow++)
                        EliminateRow(output, tmpRow, pivotRow.Value, col, totalColCount);
                }

                // Eliminate Next Rows
                for (int tmpRow = pivotRow.Value; tmpRow < totalRowCount; tmpRow++)
                    EliminateRow(output, tmpRow, pivotRow.Value, col, totalColCount);
            }

            result.FullMatrix = output;
            result.UnknownsCount = augmentedCols;
            result.TotalRowCount = totalRowCount;
            result.TotalColumnCount = totalColCount;
            result.AugmentedColumnCount = augmentedCols;

            result.AugmentedColumns = ExtractColumns(output, result.UnknownsCount, totalColCount - 1);
            if (augmentedCols > 0 && form == MatrixReductionForm.ReducedRowEchelonForm)
            {
                // matrix has solution 
                result = FindSolution(result);
            }

            return result;
        }

        private static MatrixEliminationResult FindSolution(MatrixEliminationResult result)
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
                    double unknownValue = result.FullMatrix[pivotRow, col];
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

        private static double[,] ExtractColumns(double[,] input, int startCol, int endCol)
        {
            return ExtractColumns(input, Enumerable.Range(startCol, endCol - startCol + 1).ToArray());
        }

        private static double[,] ExtractColumns(double[,] input, int[] cols)
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

        private double[,] Repr;

        private Matrix(double[,] values)
        {
            this.Repr = CreateCopy(values);
        }

        private Matrix(int n, int m)
        {
            Repr = new double[n, m];
        }
    }
}