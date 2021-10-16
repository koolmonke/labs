using System;
using System.Linq;
using MoreLinq;

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
            const int batchSize = 100;
            Random random = new Random();

            var data = GenData(n);
            var itemToFind = data[random.Next(data.Length)];
            Console.WriteLine($"Найти: {itemToFind}");

            Array.Sort(data);

            var chunks = data.Batch(batchSize).Select(item => item.ToArray()).Select((array, index) => (array, index))
                .ToArray();
            var found = chunks.AsParallel()
                .Select(item => (IndexInInnerArray: item.array.MyBinarySearch(itemToFind), ArrayIndex: item.index))
                .Where(item => item.IndexInInnerArray != -1)
                .Select(item => item.IndexInInnerArray + item.ArrayIndex * batchSize)
                .First();

            Console.WriteLine($"Индекс в изначальном массиве: {(found)}");
            Console.WriteLine($"Нашло: {data[found]}");
        }
    }
}