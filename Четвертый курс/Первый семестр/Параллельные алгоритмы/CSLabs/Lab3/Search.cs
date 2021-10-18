using System;
using System.Linq;
using MoreLinq;

namespace Lab3
{
    public static class Search
    {
        public static int ParallelLinear<T>(T[] data, T itemToFind, int batchSize = 100) where T : IComparable<T>
        {
            var batchedData = data
                .Batch(batchSize)
                .Select(item => item.ToArray())
                .Select((array, index) => (array, index));

            var (indexInInnerArray, arrayIndex) = batchedData.AsParallel()
                .Select(item => (IndexInInnerArray: Search.Linear(item.array, itemToFind),
                    ArrayIndex: item.index))
                .First(item => item.IndexInInnerArray != -1);
            
            return indexInInnerArray + arrayIndex * batchSize;
        }

        public static int ParallelBinary<T>(T[] data, T itemToFind, int batchSize = 100) where T : IComparable<T>
        {
            var batchedData = data
                .Batch(batchSize)
                .Select(item => item.ToArray())
                .Select((array, index) => (array, index));

            var (indexInInnerArray, arrayIndex) = batchedData.AsParallel()
                .Select(item => (IndexInInnerArray: Search.Binary(item.array, itemToFind),
                    ArrayIndex: item.index))
                .First(item => item.IndexInInnerArray != -1);
            
            return indexInInnerArray + arrayIndex * batchSize;
        }

        public static int Linear<T>(T[] array, T value) where T : IComparable<T>
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

        public static int Binary<T>(T[] array, T value) where T : IComparable<T>
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
    }
}