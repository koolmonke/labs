using System;
using System.Linq;

namespace Calculator
{
    public static class MathExt
    {
        public static double Factorial(string x)
        {
            try
            {
                var t = int.Parse(x);
                if (t >= 20)
                {
                    return double.NaN;
                }
                if (t == 0)
                    return 1d;
                return Enumerable
                    .Range(1, t)
                    .Aggregate((acc, i) => acc * i);
            }
            catch (Exception)
            {
                return double.NaN;
            }
        }


        public static double Tan(string x, bool isRad)
        {
            try
            {
                var value = double.Parse(x);
                var radians = isRad ? value : ToRadians(value);
                var angle = isRad ? ToAngles(value) : value;
                if (Math.Round(angle, 2) % 180 != 0 && Math.Round(angle, 2) % 90 == 0)
                    return double.NaN;
                return Math.Tan(radians);
            }
            catch (Exception)
            {
                return double.NaN;
            }

        }


        public static double ToAngles(double x) => x * 180 / Math.PI;

        public static double ToRadians(double x) => x * Math.PI / 180;
    }
}
