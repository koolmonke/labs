using System;
using System.Globalization;
using System.Linq;
using System.Text;
using MatrixArithmetic.Solvers;
using static MatrixArithmetic.MatrixFunctions;

namespace MatrixArithmetic
{
    public class Matrix : IMatrix<double>
    {
        public int N => this.Repr.GetLength(0);

        public int M => this.Repr.GetLength(1);

        public double[,] ToRepresentation() => new Matrix(this.Repr).Repr;

        public double this[int i, int j]
        {
            get => Repr[i, j];
            set => Repr[i, j] = value;
        }

        public IVector<double> ToVectorByColumn(int column = 0)
        {
            if (this.M != 1)
            {
                throw new VectorDifferentDimException();
            }

            var vector = Vector.WithSize(this.N);

            for (int i = 0; i < this.N; i++)
            {
                vector[i] = this[i, column];
            }

            return vector;
        }

        public IVector<double> ToVectorByRow(int row = 0)
        {
            if (this.M != 1)
            {
                throw new VectorDifferentDimException();
            }

            var vector = Vector.WithSize(this.M);

            for (int i = 0; i < this.M; i++)
            {
                vector[i] = this[row, i];
            }

            return vector;
        }

        public IMatrix<double> Multiply(IMatrix<double> right)
        {
            var result = Matrix.WithSize(this.N, right.M);

            for (int i = 0; i < this.N; i++)
            {
                for (int j = 0; j < right.M; j++)
                {
                    for (int k = 0; k < this.N; k++)
                    {
                        result[i, j] += this[i, k] * right[k, j];
                    }
                }
            }

            return result;
        }


        public IVector<double> Solve(IVector<double> fVector) => new GaussSolver(this, fVector).SolutionVector;

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

        public IMatrix<double> Copy() => new Matrix(Repr);

        public static Matrix WithSize(int n, int m) => new Matrix(n, m);

        public static Matrix From(double[,] values) => new Matrix(values);

        public IMatrix<double> Inv()
        {
            var vectors = ParallelEnumerable.Range(0, N).AsOrdered().Select(i =>
            {
                var tmpVector = Vector.WithSize(N);

                tmpVector[i] = 1;

                return this.Solve(tmpVector);
            }).ToArray();

            return vectors.ToMatrix();
        }

        public Matrix Select(Func<(int I, int J), double, double> f)
        {
            var result = Matrix.WithSize(N, M);

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    result[i,j] = f((i, j), this[i, j]);
                }
            }

            return result;
        }
        
        public Matrix Select(Func<double, double> f)
        {
            var result = Matrix.WithSize(N, M);

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    result[i,j] = f(this[i, j]);
                }
            }

            return result;
        }


        public override string ToString() => this.ToString(" #0.0000;-#0.0000; 0.0000");

        public string ToString(string format)
        {
            var builder = new StringBuilder(N * M + N);


            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    builder.Append(
                        $"{this[i, j].ToString(format, CultureInfo.InvariantCulture)} ");
                }

                if (i < N - 1)
                {
                    builder.AppendLine();
                }
            }

            return builder.ToString();
        }

        private static double StupidDet(double[][] input)
        {
            const double eps = 0.0001;
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
                if (Math.Abs(input[k][i]) < eps)
                {
                    return 0;
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
                    if (j != i && Math.Abs(input[j][i]) > eps)
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