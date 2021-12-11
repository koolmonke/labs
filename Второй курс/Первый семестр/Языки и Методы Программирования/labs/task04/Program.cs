namespace task04
{
    static class MainClass
    {
        public static void Main(string[] args)
        {
            int n = 0;
            double x = 0;
            try
            {
                x = double.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }

            double arth = 1;
            double res = 1;
            if (Math.Abs(x) >= 1)
            {
                while (Math.Abs(arth) > double.Epsilon)
                {
                    arth *= (2 * n + 1) / ((2 * n + 3) * x * x);
                    res += arth;
                    n++;
                }

                Console.WriteLine($"arth {x} = {res}");
            }
            else
            {
                Console.WriteLine("Невозможно для |x|<1");
            }

            Console.WriteLine(0.5 * Math.Log(Math.Abs((1 + x) / (1 - x))));
        }
    }
}