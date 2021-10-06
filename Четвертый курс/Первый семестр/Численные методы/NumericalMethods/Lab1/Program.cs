using System;
using System.Globalization;
using MatrixArithmetic;

namespace Lab1
{
    internal static class Program
    {
        private static void Main()
        {
            var a = Matrix.From(new[,]
            {
                { -2, 3.01, .12, -.11 },
                { 2.92, -.17, .11, .22 },
                { .66, .52, 3.17, 2.11 },
                { 3.01, .42, -.27, .15 }
            });

            var f = Vector.From(new[]
            {
                4.13,
                3.46,
                2.79,
                1.01
            });

            Console.WriteLine("Матрица A");
            Console.WriteLine(a);

            Console.WriteLine("Вектор f");
            Console.WriteLine(f);

            Console.WriteLine("её детерминант");
            Console.WriteLine(a.Det().ToString(CultureInfo.InvariantCulture));

            Console.WriteLine("решение ax=f");
            var solution = a.Solve(f);
            Console.WriteLine(solution);

            Console.WriteLine("Вектор невязки");
            Console.WriteLine(
                a.Multiply(solution.ToMatrix()).ToVectorByColumn().Sub(f)
                    .ToString(" #0.000000000000;-#0.000000000000;0.000000000000"));

            var matrixInv = a.Inv();
            Console.WriteLine("обратная матрица a");
            Console.WriteLine(matrixInv);

            Console.WriteLine("матрица а умноженный на её обратную матрицу");
            Console.WriteLine(matrixInv.Multiply(a));
        }
    }
}