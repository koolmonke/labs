using System;
using MatrixArithmetic;

namespace Lab1
{
    internal static class Program
    {
        private static void Main()
        {
            var a = Matrix.From(new[,]
            {
                { 0.34, 1.17, 0.2, 8.13 },
                { 3.52, 4.73, 4.37, 5.89 },
                { -6.25, 2.54, 6.91, -5.43 },
                { -2.13, 2.21, 4.17, 6.11 }
            });

            var f = Vector.From(new[] { 4.15, 2.92, -3.14, 7.65 });

            Console.WriteLine("Матрица A");
            Console.WriteLine(a);

            Console.WriteLine("её детерминант");
            Console.WriteLine(a.Det());

            Console.WriteLine("решение ax=f");
            var solution = a.Sole(f);
            Console.WriteLine(solution);

            Console.WriteLine("Вектор невязки");
            Console.WriteLine((a * solution.ToMatrix()).ToVector() - f);

            var matrixInv = a.Inv();
            Console.WriteLine("обратная матрица a");
            Console.WriteLine(matrixInv);

            Console.WriteLine("матрица а умноженный на её обратную матрицу");
            Console.WriteLine(matrixInv * a);
        }
    }
}