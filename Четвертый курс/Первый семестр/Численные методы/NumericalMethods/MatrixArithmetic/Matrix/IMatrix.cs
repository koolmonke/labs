using System;

namespace MatrixArithmetic
{
    public interface IMatrix<T>: IOperable<T>
    {
        int N { get; }
        int M { get; }

        T this[int i, int j] { get; set; }

        public static T operator +(IMatrix<T> left, IMatrix<T> right)
        {
            throw new NotImplementedException();
        }

        IVector<T> Solve(IVector<T> fVector);
        T Det();
        IMatrix<T> Copy();
        IMatrix<T> Inv();
        string ToString();
        string ToString(string format);
    }
}