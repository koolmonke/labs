using System;
using System.Globalization;
using System.Text;
using static MatrixArithmetic.MatrixFunctions;

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

        public Vector Solve(Vector fVector)
        {
            var newMatrix = this.Repr.ConcatHorizontally(fVector.ToMatrix().Repr);

            var fullMatrix = newMatrix.Eliminate(MatrixReductionForm.ReducedRowEchelonForm, 1)
                .FullMatrix;

            var result = Vector.WithSize(N);

            for (int i = 0; i < N; i++)
            {
                result[i] = fullMatrix![i, N];
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

            var newMatrix = this.Repr.ConcatHorizontally(Matrix.Identity(rowCount).Repr);

            var result = newMatrix.Eliminate(MatrixReductionForm.ReducedRowEchelonForm, rowCount);
            return new Matrix(result.AugmentedColumns!);
        }


        public override string ToString() => this.ToString(" #0.0000;-#0.0000; 0.0000");

        public string ToString(string format)
        {
            var builder = new StringBuilder();


            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    builder.Append(
                        $"{Repr[i, j].ToString(format, CultureInfo.InvariantCulture)} ");
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
            var EPS = 0.0001;
            var n = input.Length;
            double det = 1;
            double[][] b = new double[1][];
            b[0] = new double[n];
            for (int i = 0; i < n; ++i)
            {
                int k = i;
                for (int j = i + 1; j < n; ++j)
                    if (Math.Abs(input[j][i]) > Math.Abs(input[k][i]))
                        k = j;
                if (Math.Abs(input[k][i]) < EPS)
                {
                    det = 0;
                    break;
                }

                b[0] = input[i];
                input[i] = input[k];
                input[k] = b[0];
                if (i != k)
                    det = -det;
                det *= input[i][i];
                for (int j = i + 1; j < n; ++j)
                    input[i][j] /= input[i][i];
                for (int j = 0; j < n; ++j)
                    if (j != i && Math.Abs(input[j][i]) > EPS)
                        for (k = i + 1; k < n; ++k)
                            input[j][k] -= input[i][k] * input[j][i];
            }

            return det;
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