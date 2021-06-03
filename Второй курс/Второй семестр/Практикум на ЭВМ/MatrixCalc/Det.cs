using System;

namespace MatrixCalc
{
    class Det
    {
        
        public static double SafeDet(double[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                throw new Exception("Only for square matrices");
            }

            return det(matrix.GetLength(0), matrix);
        }

        public static double det(int n, double[,] mat)
        {
            double d = 0;
            int k, i, j, subi, subj;
            double[,] subMat = new double[n, n];

            if (n == 2)
            {
                return ((mat[0, 0] * mat[1, 1]) - (mat[1, 0] * mat[0, 1]));
            }

            else
            {
                for (k = 0; k < n; k++)
                {
                    subi = 0;
                    for (i = 1; i < n; i++)
                    {
                        subj = 0;
                        for (j = 0; j < n; j++)
                        {
                            if (j == k)
                            {
                                continue;
                            }
                            subMat[subi, subj] = mat[i, j];
                            subj++;
                        }
                        subi++;
                    }
                    d = d + (Math.Pow(-1, k) * mat[0, k] * det(n - 1, subMat));
                }
            }
            return d;
        }

    }
}
