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

        public Vector Sole() => Vector.From(GaussSole(Repr));

        public double Det()
        {
            return Determinant(Repr);
        }


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


        public override string ToString()
        {
            var builder = new StringBuilder();


            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    builder.Append($"{Repr[i, j]:0.000} ");
                }

                builder.Append('\n');
            }

            return builder.ToString();
        }

        /// <summary>
        /// Concats two matrices horizontally.
        /// </summary>
        public static double[,] ConcatHorizontally(double[,] matrix1, double[,] matrix2)
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
        /// Метод Гаусса (Решение СЛАУ)
        /// </summary>
        /// <param name="matrix">Начальная матрица</param>
        /// <returns></returns>
        private static double[] GaussSole(double[,] matrix)
        {
            int n = matrix.GetLength(0); //Размерность начальной матрицы (строки)
            double[,] matrixClone = new double[n, n + 1]; //Матрица-дублер
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n + 1; j++)
                {
                    matrixClone[i, j] = matrix[i, j];
                }
            }

            //Прямой ход (Зануление нижнего левого угла)
            for (int k = 0; k < n; k++) //k-номер строки
            {
                for (int i = 0; i < n + 1; i++) //i-номер столбца
                    matrixClone[k, i] /=
                        matrix[k, k]; //Деление k-строки на первый член !=0 для преобразования его в единицу
                for (int i = k + 1; i < n; i++) //i-номер следующей строки после k
                {
                    double K = matrixClone[i, k] / matrixClone[k, k]; //Коэффициент
                    for (int j = 0; j < n + 1; j++) //j-номер столбца следующей строки после k
                    {
                        matrixClone[i, j] -= matrixClone[k, j] *
                                             K; //Зануление элементов матрицы ниже первого члена, преобразованного в единицу
                    }
                }

                for (int i = 0; i < n; i++) //Обновление, внесение изменений в начальную матрицу
                {
                    for (int j = 0; j < n + 1; j++)
                    {
                        matrix[i, j] = matrixClone[i, j];
                    }
                }
            }

            //Обратный ход (Зануление верхнего правого угла)
            for (int k = n - 1; k > -1; k--) //k-номер строки
            {
                for (int i = n; i > -1; i--) //i-номер столбца
                {
                    matrixClone[k, i] /= matrix[k, k];
                }

                for (int i = k - 1; i > -1; i--) //i-номер следующей строки после k
                {
                    double K = matrixClone[i, k] / matrixClone[k, k];
                    for (int j = n; j > -1; j--) //j-номер столбца следующей строки после k
                    {
                        matrixClone[i, j] -= matrixClone[k, j] * K;
                    }
                }
            }

            //Отделяем от общей матрицы ответы
            double[] answer = new double[n];
            for (int i = 0; i < n; i++)
                answer[i] = matrixClone[i, n];

            return answer;
        }

        private static double Determinant(double[,] input)
        {
            var results = CrossProduct(input);

            return results.Sum();
        }

        private static double[] CrossProduct(double[,] input)
        {
            int rowCount = input.GetLength(0);
            int colCount = input.GetLength(1);

            if (rowCount == 0)
                return new double[] { 1 };

            if (rowCount == 1)
                return new[] { input[0, 0] };

            if (rowCount == 2)
                return new[] { input[0, 0] * input[1, 1] - input[0, 1] * input[1, 0] };

            double[] results = new double[colCount];

            for (int col = 0; col < colCount; col++)
            {
                // checkerboard pattern, even col  = 1, odd col = -1
                var checkerboardFactor = col % 2.0 == 0 ? 1 : -1;
                var coefficient = input[0, col];

                var crossMatrix = GetCrossMatrix(input, 0, col);
                results[col] = checkerboardFactor * (coefficient * Determinant(crossMatrix));
            }

            return results;
        }

        private static double[,] GetCrossMatrix(double[,] input, int skipRow, int skipCol)
        {
            int rowCount = input.GetLength(0);
            int colCount = input.GetLength(1);

            var output = new double[rowCount - 1, colCount - 1];
            int outputRow = 0;

            for (int row = 0; row < rowCount; row++)
            {
                if (row == skipRow)
                    continue;

                int outputCol = 0;

                for (int col = 0; col < colCount; col++)
                {
                    if (col == skipCol)
                        continue;

                    output[outputRow, outputCol] = input[row, col];

                    outputCol++;
                }

                outputRow++;
            }

            return output;
        }

        public Matrix Inv()
        {
            return new Matrix(Invert(Repr));
        }

        private static double[,] Invert(double[,] matrix)
        {
            var rowCount = matrix.GetLength(0);
            var colCount = matrix.GetLength(1);


            var newMatrix = ConcatHorizontally(matrix, Matrix.Identity(rowCount).Repr);

            var result = Eliminate(newMatrix, MatrixReductionForm.ReducedRowEchelonForm, rowCount);
            if (result.Rank != colCount)
                return null;

            return result.AugmentedColumns;
        }
        
        public static double[,] CreateCopy(double[,] input) {
            var rowCount = input.GetLength(0);
            var colCount = input.GetLength(1);

            double[,] output = new double[rowCount,colCount ];
      
            for (int row = 0; row < rowCount ; row++) {
                for (int col = 0; col < colCount; col++) {
                    output[row, col] = input[row, col];
                }
            }

            return output;
        }
        
        private static int? FindPivot(double[,] input, int startRow, int col, int rowCount) {
            for (int i = startRow; i < rowCount; i++) {
                if (input[i, col] != 0)
                    return i;
            }

            return null;
        }
        
        private static void ReduceRow(double[,] input, int row, int col, int colCount) {
            var coeffecient = 1.0 / input[row, col];

            if (coeffecient == 1)
                return;

            for (; col < colCount; col++)
                input[row, col] *= coeffecient;
        }
        
        private static void EliminateRow(double[,] input, int row, int pivotRow, int pivotCol, int colCount) {
            if (pivotRow == row)
                return;

            if (input[row, pivotCol] == 0)
                return;

            double coeffecient = input[row, pivotCol];

            for (int col = pivotCol; col < colCount; col++) {
                input[row, col] -= input[pivotRow, col] * coeffecient;
            }
        }
        
        private static void SwitchRows(double[,] input, int row1, int row2, int colCount) {
            if (row1 == row2)
                return;

            for (int col = 0; col < colCount; col++) {
                (input[row1, col], input[row2, col]) = (input[row2, col], input[row1, col]);
            }
        }

        /// <summary>
        /// Reduces matrix to row-echelon (REF/Gauss) or reduced row-echelon (RREF/Gauss-Jordan) form and solves for augmented columns (if any.)
        /// </summary>
        public static MatrixEliminationResult Eliminate(double[,] input, MatrixReductionForm form,
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
            result.UnknownsCount = totalColCount / 2;
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
        
        private static MatrixEliminationResult FindSolution(MatrixEliminationResult result) {

            double?[] solution = null;
            MatrixSolutionState solutionState = MatrixSolutionState.None;


            if (result.AugmentedColumnCount == 1) {
                if (result.UnknownsCount > result.TotalRowCount)
                    solutionState = MatrixSolutionState.Infinite;
                else
                    solutionState = MatrixSolutionState.Unique; // default value

                solution = new double?[result.UnknownsCount];

                int pivotRow = 0;
                for (int col = 0; col < result.UnknownsCount; col++) {
                    double unknownValue = result.FullMatrix[pivotRow, col];
                    double solutionValue = result.FullMatrix[pivotRow, result.TotalColumnCount - 1];

                    if (unknownValue == 1) {
                        solution[col] = solutionValue;

                        pivotRow++;
                    } else {
                        if (solutionState == MatrixSolutionState.Unique) { // still on default value
                            if (solutionValue == 0)
                                solutionState = MatrixSolutionState.Infinite;
                            else
                                solutionState = MatrixSolutionState.None;
                        }
                    }
                }
            }

            if (solution != null)
                result.Rank = solution.Where(s => s != null).Count();
            else
                result.Rank = result.TotalColumnCount - result.AugmentedColumnCount;

            result.Solution = solution;
            result.SolutionState = solutionState;

            return result;
        }
        public static double[,] ExtractColumns(double[,] input, int startCol, int endCol) {
            return ExtractColumns(input, Enumerable.Range(startCol, endCol - startCol + 1).ToArray());
        }
        
        public static double[,] ExtractColumns(double[,] input, int[] cols) {
            // cols = cols.Distinct().ToArray();
            int rowCount = input.GetLength(0);
            int colCount = input.GetLength(1);
            double[,] output = new double[rowCount, cols.Length];

            for (int row = 0; row < rowCount; row++) {
                int i = 0;
                for (int col = 0; col < colCount; col++) {
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
            this.Repr = (double[,])values.Clone();
        }

        private Matrix(int n, int m)
        {
            Repr = new double[n, m];
        }
    }
}