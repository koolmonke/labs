namespace MatrixArithmetic.Solvers
{
    public class GaussSolver : ISolver<double>
    {
        public GaussSolver(IMatrix<double> matrix, IVector<double> forVector)
        {
            this.Matrix = matrix;
            this.Vector = forVector;
        }

        public IVector<double> Vector { get; }

        public IMatrix<double> Matrix { get; }

        private IVector<double>? _solutionVector;

        public IVector<double> SolutionVector => _solutionVector ??= this.Solve();

        public IVector<double> Solve()
        {
            var newMatrix = Matrix.ToRepresentation().ConcatHorizontally(Vector.ToMatrix().ToRepresentation());

            var fullMatrix = newMatrix.Eliminate(MatrixReductionForm.ReducedRowEchelonForm, 1)
                .FullMatrix;

            Vector result = MatrixArithmetic.Vector.WithSize(Matrix.N);

            for (int i = 0; i < Matrix.N; i++)
            {
                result[i] = fullMatrix![i, Matrix.N];
            }

            return result;
        }


        public IVector<double> Residual() => Matrix.Multiply(SolutionVector.ToMatrix()).ToVectorByColumn().Sub(SolutionVector);
    }
}