namespace MatrixArithmetic
{
    public interface IOperable<T>
    {
        IOperable<T> Add(IOperable<T> right);
        IOperable<T> Sub(IOperable<T> right);
        IOperable<T> Mul(IOperable<T> right);
    }
}