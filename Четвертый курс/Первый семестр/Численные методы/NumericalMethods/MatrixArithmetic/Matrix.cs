using System;
using System.Collections.Generic;
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

        public Matrix this[Range i, Range j] => new Matrix(Repr[i][j]);
        public Matrix this[Range i] => new Matrix(Repr[i]);

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

        public Matrix InverseGauss()
        {
            if (this.N != this.M)
            {
                throw new MatrixDifferentDimException();
            }

            var order = this.N;


            // Create the augmented matrix
            // Add the identity matrix
            // of order at the end of original matrix.
            var matrix = this.AugmentMatrixWith(Matrix.Identity(order));

            // Interchange the row of matrix,
            // interchanging of row will start from the last row
            for (int i = order - 1; i > 0; i--)
            {
                if (matrix[i - 1][0] < matrix[i][0])
                {
                    (matrix[i], matrix[i - 1]) = (matrix[i - 1], matrix[i]);
                }
            }

            // Print matrix after interchange operations.

            // Replace a row by sum of itself and a
            // constant multiple of another row of the matrix
            for (int i = 0; i < order; i++)
            {
                for (int j = 0; j < order; j++)
                {
                    if (j != i)
                    {
                        double temp = matrix[j][i] / matrix[i][i];
                        for (int k = 0; k < 2 * order; k++)
                        {
                            matrix[j][k] -= matrix[i][k] * temp;
                        }
                    }
                }
            }

            // Multiply each row by a nonzero integer.
            // Divide row element by the diagonal element
            for (int i = 0; i < order; i++)
            {
                double temp = matrix[i][i];
                for (int j = 0; j < 2 * order; j++)
                {
                    matrix[i][j] /= temp;
                }
            }

            return matrix;
        }

        public Matrix AugmentMatrixWith(Matrix other)
        {
            IEnumerable<double[]> Iter(Matrix matrix)
            {
                for (int i = 0; i < matrix.N; i++)
                {
                    yield return matrix[i];
                }
            }

            return new Matrix(this.Repr.Concat(Iter(other)).ToArray()).Transpose();
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

        public Matrix Transpose()
        {
            var result = Matrix.WithSize(M, N);

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    result[j, i] = Repr[i][j];
                }
            }

            return result;
        }

        public Matrix T => Transpose();

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