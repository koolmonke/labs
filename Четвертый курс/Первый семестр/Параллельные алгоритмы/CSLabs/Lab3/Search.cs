using System;
using MoreLinq;
using System.Linq;

namespace Lab3
{
    public static class Search
    {
        public static int LinearSearch<T>(T[] array, T value) where T : IComparable<T>
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].CompareTo(value) == 0)
                {
                    return i;
                }
            }

            return -1;
        }

        public static int BinarySearch<T>(T[] array, T value) where T : IComparable<T>
        {
            int i = 0, j = array.Length - 1;
            while (i <= j)
            {
                int k = i + (j - i) / 2;
                switch (array[k].CompareTo(value))
                {
                    case > 0:
                        j = k - 1;
                        break;
                    case 0:
                        return k;
                    case < 0:
                        i = k + 1;
                        break;
                }
            }

            return -1;
        }

        private static int ParallelSearch<T>(T[] array, T value, int batchSize, Func<T[], T, int> searchFunc)
            where T : IComparable<T>
        {
            var batchedData = array
                .Batch(batchSize)
                .Select(item => item.ToArray())
                .Select((innerArray, index) => (innerArray, index))
                .ToArray();

            var (indexInInnerArray, arrayIndex) = batchedData.AsParallel()
                .Select(item => (IndexInInnerArray: searchFunc(array, value), ArrayIndex: item.index))
                .First(item => item.IndexInInnerArray != -1);
            return indexInInnerArray + arrayIndex * batchSize;
        }

        public static int ParallelLinearSearch<T>(T[] array, T value, int batchSize) where T : IComparable<T> =>
            ParallelSearch(array, value, batchSize, LinearSearch);

        public static int ParallelBinarySearch<T>(T[] array, T value, int batchSize) where T : IComparable<T> =>
            ParallelSearch(array, value, batchSize, BinarySearch);
    }
}