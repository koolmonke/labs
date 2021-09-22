using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MatrixArithmetic
{
    public class Vector : IEnumerable<double>
    {
        IEnumerator<double> IEnumerable<double>.GetEnumerator() => ((IEnumerable<double>)Repr).GetEnumerator();

        public IEnumerator GetEnumerator() => Repr.GetEnumerator();

        public int N => Repr.Length;

        public double this[Index i]
        {
            get => Repr[i];
            set => Repr[i] = value;
        }

        public double[] this[Range i] => Repr[i];

        public static Vector WithSize(int n) => new Vector(n);

        public static Vector From(double[] values) => new Vector(values);

        public Vector Copy() => From(Repr);

        public static Vector operator *(Vector self, Vector other)
        {
            if (self.N != other.N)
            {
                throw new VectorDifferentDimException();
            }

            return self.Zip(other).Select(pair => pair.First * pair.Second).ToVector();
        }

        public static Vector operator *(Vector self, double other) => self.Select(value => other * value).ToVector();
        public static Vector operator *(double self, Vector other) => other * self;

        public static Vector operator +(Vector self, Vector other)
        {
            if (self.N != other.N)
            {
                throw new VectorDifferentDimException();
            }

            return self.Zip(other).Select(pair => pair.First + pair.Second).ToVector();
        }

        public static Vector operator -(Vector self, Vector other)
        {
            if (self.N != other.N)
            {
                throw new VectorDifferentDimException();
            }

            return self.Zip(other).Select(pair => pair.First - pair.Second).ToVector();
        }

        public static Vector operator -(Vector self) => self.Select(value => -value).ToVector();


        private double[] Repr;

        private Vector(double[] values)
        {
            Repr = values.Select(value => value).ToArray();
        }

        private Vector(int n)
        {
            Repr = new double[n];
        }
    }
}