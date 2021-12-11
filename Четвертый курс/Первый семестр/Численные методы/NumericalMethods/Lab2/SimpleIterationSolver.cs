﻿using System.Linq;
using MatrixArithmetic;
using MatrixArithmetic.Norms;
using static System.Math;

namespace Lab2
{
    public class SimpleIterationSolver
    {
        public SimpleIterationSolver(INorma norma, Matrix matrix, Vector vector)
        {
            Norma = norma;
            System = matrix;
            FreeVector = vector;
            _tau = 2 / Norma.MatrixNorm(System);
        }

        public INorma Norma { get; }
        public Matrix System { get; }
        public Vector FreeVector { get; }

        public Vector SolutionVector => _solution ??= Solve();

        public Vector Residual =>
            System.Multiply(SolutionVector).Sub(FreeVector);

        private Vector Solve()
        {
            var guess = new GivensMethod(System, FreeVector).SolutionVector.Select(Truncate).ToVector();

            Vector xk = guess;
            Vector xkp;
            do
            {
                xkp = xk;
                xk = FreeVector.Sub(System.Multiply(xk)).Multiply(_tau).Add(xk);
            } while (Norma.VectorNorm(xkp.Sub(xk)) > Constants.Epsilon6);

            return xk;
        }

        private Vector? _solution;

        private readonly double _tau;
    }
}