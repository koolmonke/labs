using System;
using System.Linq;
using static System.Math;

namespace MatrixArithmetic
{
    public class Matrix
    {
        public int N => Repr.Length;

        public int M => Repr[0].Length;

        public double this[Index i, Index j]
        {
            get => Repr[i][j];
            set => Repr[i][j] = value;
        }

        public double[] this[Index i]
        {
            get => Repr[i];
            set => Repr[i] = value;
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

        public double[]? GaussSole()
        {
            var m = this.Copy();

            for (int k = 0; k < m.N - 1; k++)
            {
                m.BubbleMaxRow(k);

                for (int i = k + 1; i < m.N; i++)
                {
                    var div = m[i, k] / m[k, k];

                    m[i, ^1] -= div * m[k, ^1];

                    for (int j = k; j < m.N; j++)
                    {
                        m[i, j] -= div * m[k, j];
                    }
                }
            }

            if (m.IsSingular())
            {
                return null;
            }

            var x = new double[N];

            for (int k = N - 1; k >= 0; k--)
            {
                x[k] = (m[k, ^1] - Enumerable.Range(k + 1, m.N).Select(j => m[k, j] * x[j]).Sum()) / m[k, k];
            }

            return x;
        }

        public double DetGauss()
        {
            var matrix = this.Copy();
            var det = 1d;
            var lenCol = matrix.N;

            for (int i = 0; i < lenCol; i++)
            {
                var t = i;

                for (int j = i + 1; j < lenCol; j++)
                {
                    if (Abs(matrix[j, i]) > Abs(matrix[t, i]))
                    {
                        t = j;
                    }
                }

                (matrix[i], matrix[t]) = (matrix[t], matrix[i]);

                if (i != t)
                {
                    det = -det;
                }

                det *= matrix[i][i];

                for (int j = 0; j < lenCol; j++)
                {
                    matrix[i, j] /= matrix[i, i];
                }

                for (int j = 0; j < lenCol; j++)
                {
                    if (j != i)
                    {
                        for (int k = 0; k < lenCol; k++)
                        {
                            matrix[j, k] /= matrix[i, k] * matrix[j, i];
                        }
                    }
                }
            }

            return det;
        }

        public bool IsSingular()
        {
            for (int i = 0; i < N; i++)
            {
                if (Repr[i][i] == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public Matrix Copy() => new Matrix(Repr);

        public static Matrix WithSize(int n, int m) => new Matrix(n, m);

        public static Matrix From(double[][] values) => new Matrix(values);

        private void BubbleMaxRow(int col)
        {
            var maxElement = Repr[col][col];
            var maxRow = col;

            for (int i = col + 1; i < N; i++)
            {
                if (Abs(Repr[i][col]) > Abs(maxElement))
                {
                    maxElement = Repr[i][col];
                    maxRow = i;
                }
            }

            if (maxRow != col)
            {
                (Repr[col], Repr[maxRow]) = (Repr[maxRow], Repr[col]);
            }
        }

        private double[][] Repr;

        private Matrix(double[][] values)
        {
            this.Repr = values.Select(array => array.ToArray()).ToArray();
        }

        private Matrix(int n, int m)
        {
            Repr = new double[n][];
            for (int i = 0; i < m; i++)
            {
                Repr[i] = new double[m];
            }
        }
    }
}