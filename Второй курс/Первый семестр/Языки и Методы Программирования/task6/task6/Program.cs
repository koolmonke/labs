using System;

namespace task6
{
    class MainClass
    {
        static bool CompareArrays(Char[] a, Char[] b)
        {
            if (a.Length != b.Length)
            {
                return false;
            }
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                {
                    return false;
                }
            }
            return true;
        }
        public static void Main(string[] args)
        {
            string a = Console.ReadLine();
            var ar = a.ToCharArray();
            Array.Reverse(ar);
            if (CompareArrays(ar, a.ToCharArray())) Console.WriteLine("Полиндром");
            else Console.WriteLine("Не");
            //int n = 0;
            //Console.WriteLine("Введите размерность матрицы N");
            //try
            //{
            //    n = int.Parse(Console.ReadLine());
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    Environment.Exit(0);
            // }
            //int[,] ar = new int[n, n];
            //for (int i = 0; i != ar.GetLength(0); i++)
            //{
            //    ar[i, i] = i + 1;
            //    ar[i, ar.GetLength(1) - 1 - i] = n - i;
            //}
            //for (int i = 0; i != ar.GetLength(0); i++)
            //{
            //    for (int j = 0; j != ar.GetLength(1); j++)
            //    {
            //        Console.Write(ar[i, j] + " ");
            //    }
            //    Console.WriteLine();
            //}
        }
    }
}
