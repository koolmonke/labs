using System;

namespace MatrixArithmetic
{
    public interface IMatrix<T>
    {
        int N { get; }
        int M { get; }

        T[,] ToRepresentation();

        T this[int i, int j] { get; set; }

        IVector<T> ToVectorByColumn(int column = 0);
        IVector<T> ToVectorByRow(int row = 0);

        IMatrix<T> Multiply(IMatrix<T> right);

        Matrix Select(Func<double, double> f);
        
        Matrix Select(Func<(int I, int J), double, double> f);

        IVector<T> Solve(IVector<T> fVector);

        T Det();
        IMatrix<T> Copy();
        IMatrix<T> Inv();
        string ToString();
        string ToString(string format);
    }
}