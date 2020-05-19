using System;
using System.Numerics;
namespace task18
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            BigInteger fact = 1;
            for (int i = 1; i <= 100; i++)
            {
                fact *= i;
            }
            Console.WriteLine(string.Format("100! + 2^100 = {0}", fact + BigInteger.Pow(2, 100)));
        }
    }
}
