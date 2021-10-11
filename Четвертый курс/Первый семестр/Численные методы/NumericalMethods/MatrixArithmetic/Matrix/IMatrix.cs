using System.Collections.Generic;

namespace MatrixArithmetic
{
    public interface IMatrix<T> : IEnumerable<T>
    {
        int N { get; }
        int M { get; }

        T[,] ToRepresentation();

        T this[int i, int j] { get; set; }

        IMatrix<T> From(IEnumerable<T> values);

        IVector<T> ToVectorByColumn(int column = 0);
        IVector<T> ToVectorByRow(int row = 0);

        IMatrix<T> Multiply(IMatrix<T> right);

        IMatrix<T> Add(IMatrix<T> right);

        IMatrix<T> Sub(IMatrix<T> right);


        IVector<T> Solve(IVector<T> fVector);

        T Det();
        IMatrix<T> Copy();
        IMatrix<T> Inv();
        string ToString();
        string ToString(string format);
    }
}