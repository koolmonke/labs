using System;
using System.Linq;
using static System.Math;

namespace Matrix
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

        public double[]? Gauss()
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

        private bool IsSingular()
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

        public Matrix Copy() => new Matrix(Repr.Select(array => array.ToArray()).ToArray());

        public static Matrix WithSize(int n, int m) => new Matrix(n, m);

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
            this.Repr = values;
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