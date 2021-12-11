namespace task05
{
    static class MainClass
    {
        public static void Main(string[] args)
        {
            double prod = 1;
            string result = "";
            for (decimal i = 0; i <= 10; i += (decimal) 0.1)
            {
                prod *= 1 + Math.Sin((double)i);
                result += $"(1 + sin({i})";
            }
            Console.WriteLine(prod);
            Console.WriteLine(result);
        }
    }
}