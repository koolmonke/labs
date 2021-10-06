using System;

namespace MatrixArithmetic
{
    public interface IOperable<T>
    {
        public static T operator *(IOperable<T> left, IOperable<T> right)
        {
            throw new NotImplementedException();
        }

        public static T operator +(IOperable<T> left, IOperable<T> right)
        {
            throw new NotImplementedException();
        }

        public static T operator -(IOperable<T> left, IOperable<T> right)
        {
            throw new NotImplementedException();
        }
        
        public static T operator -(IOperable<T> left)
        {
            throw new NotImplementedException();
        }
    }
}