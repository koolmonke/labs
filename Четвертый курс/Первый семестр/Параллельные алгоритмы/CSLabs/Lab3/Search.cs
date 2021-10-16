using System;

namespace Lab3
{
    public static class Search
    {
        public static int MyLinearSearch<T>(this T[] array, T value) where T : IComparable<T>
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

        public static int MyBinarySearch<T>(this T[] array, T value) where T : IComparable<T>
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