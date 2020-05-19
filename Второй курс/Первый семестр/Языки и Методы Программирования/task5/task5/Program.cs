using System;

namespace task5
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double prod = 1;
            string result = "";
            for (Decimal i = 0; i <= 10; i += (Decimal) 0.1)
            {
                prod *= (1 + Math.Sin((double)i));
                result += String.Format("(1 + sin({0})", i);
            }
            Console.WriteLine(prod);
            Console.WriteLine(result);
        }
    }
}
