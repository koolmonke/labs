using System;
using System.Collections.Generic;
using System.Linq;
using HPCsharp;

namespace Lab3
{
    public static class Search
    {
        public static int ParallelLinear<T>(T[] data, T itemToFind, int batchSize = 100) where T : IComparable<T> =>
            GenSlices(0, data.Length, batchSize)
                .AsParallel()
                .Select(item => Linear(data, itemToFind, item.Start, item.End))
                .First(item => item != -1);

        public static int ParallelBinaryUnsorted<T>(T[] data, T itemToFind, int batchSize = 100) where T : IComparable<T>
        {
            var sorted = (T[]) data.Clone();
            var indexes = Enumerable.Range(0, data.Length).ToArray();
            sorted.SortMergeInPlacePar(indexes);


            var sortedIndex = GenSlices(0, sorted.Length, batchSize)
                .AsParallel()
                .Select(item => BinarySearch(sorted, itemToFind, item.Start, item.End))
                .First(item => item != -1);

            return indexes[sortedIndex];
        }

        public static int ParallelBinary<T>(T[] data, T itemToFind, int batchSize = 100)
            where T : IComparable<T> =>
            GenSlices(0, data.Length, batchSize)
                .AsParallel()
                .Select(item => BinarySearch(data, itemToFind, item.Start, item.End))
                .First(item => item != -1);


        public static int Linear<T>(T[] data, T itemToFind) where T : IComparable<T> =>
            Linear(data, itemToFind, 0, data.Length);

        public static int Binary<T>(T[] data, T itemToFind) where T : IComparable<T>
        {
            var sorted = (T[]) data.Clone();
            var indexes = Enumerable.Range(0, data.Length).ToArray();
            Array.Sort(sorted, indexes);

            return indexes[BinarySearch(sorted, itemToFind, 0, data.Length)];
        }

        public static int BinarySearch<T>(IReadOnlyList<T> data, T itemToFind, int start, int end)
            where T : IComparable<T>
        {
            int i = start, j = end - 1;
            while (i <= j)
            {
                int k = i + (j - i) / 2;

                switch (data[k].CompareTo(itemToFind))
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

        private static int Linear<T>(IReadOnlyList<T> data, T itemToFind, int start, int end) where T : IComparable<T>
        {
            for (int i = start; i < end; i++)
            {
                if (data[i].CompareTo(itemToFind) == 0)
                {
                    return i;
                }
            }

            return -1;
        }

        private static IEnumerable<(int Start, int End)> GenSlices(int start, int end, int step)
        {
            for (; start + step < end; start += step)
            {
                yield return (start, start + step - 1);
            }

            if (start != end)
            {
                yield return (start, end - 1);
            }
        }
    }
}