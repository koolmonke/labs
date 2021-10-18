using System;

namespace Lab3
{
    public static class Program
    {
        public static int[] GenData(int n)
        {
            int[] result = new int[n];

            var random = new Random();

            for (int i = 0; i < n; i++)
            {
                result[i] = random.Next();
            }

            return result;
        }

        private static void Main()
        {
            const int n = 10000;
            Random random = new Random();

            var data = GenData(n);
            var itemToFind = data[random.Next(data.Length)];
            Console.WriteLine($"Найти: {itemToFind}");

            Array.Sort(data);

            var foundBinary = Search.ParallelBinary(data, itemToFind);

            var foundLinear = Search.ParallelLinear(data, itemToFind);

            Console.WriteLine($"Нашло бинарно: {data[foundBinary]}");
            Console.WriteLine($"Нашло линейно: {data[foundLinear]}");
        }
    }
}