using System;
using MatrixArithmetic;

namespace Lab1
{
    internal static class Program
    {
        private static void Main()
        {
            var aF = Matrix.From(new[,]
            {
                { 0.34, 1.17, 0.2, 8.13, 4.15 },
                { 3.52, 4.73, 4.37, 5.89, 2.92 },
                { -6.25, 2.54, 6.91, -5.43, -3.14 },
                { -2.13, 2.21, 4.17, 6.11, 7.65 }
            });

            var a = Matrix.From(new[,]
            {
                { 0.34, 1.17, 0.2, 8.13 },
                { 3.52, 4.73, 4.37, 5.89 },
                { -6.25, 2.54, 6.91, -5.43 },
                { -2.13, 2.21, 4.17, 6.11 }
            });

            Console.WriteLine(a);
            Console.WriteLine(a.Det());
            Console.WriteLine(aF.Sole());
            var matrixInv = a.Inv();
            
            Console.WriteLine(matrixInv);
            Console.WriteLine(matrixInv*a);
        }
    }
}