﻿using System.Collections.Generic;
using System.Linq;
using MatrixArithmetic;
using MatrixArithmetic.Norms;

namespace Lab2
{
    public class JacobiSolver
    {
        public JacobiSolver(Matrix matrix, Vector vector, double epsilon = Constants.Epsilon6)
        {
            System = matrix;
            FreeVector = vector;
            LocalEpsilon = epsilon;
        }

        public Matrix System { get; }

        public Vector FreeVector { get; }


        public Vector SolutionVector => _solutionVector ??= Solve();

        public Vector Residual =>
            System.Multiply(SolutionVector).Sub(FreeVector);

        private Vector Solve()
        {
            Vector x0 = new Vector(System.N);
            Vector x = new Vector(System.N);
            double error;

            do
            {
                for (int i = 0; i < System.N; i++)
                {
                    double sum = 0;
                    for (int j = 0; j < System.M; j++)
                    {
                        if (i != j)
                        {
                            sum += System[i, j] * x0[j] / System[i, i];
                        }

                        x[i] = FreeVector[i] / System[i, i] - sum;
                    }
                }

                error = CalcError(x, x0);
                x0 = x.Copy();
            } while (error >= LocalEpsilon);

            return x.ToVector();
        }

        private Vector? _solutionVector;

        private double LocalEpsilon { get; }

        private static double CalcError(IEnumerable<double> a, IEnumerable<double> b)
        {
            return new TaxiCabNorm().VectorNorm(a.Zip(b)
                .Select(item => item.First - item.Second).ToVector());
        }
    }
}