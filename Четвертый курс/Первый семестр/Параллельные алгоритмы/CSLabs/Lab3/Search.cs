namespace Lab3
{

    public static class Search
    {

        public static int MyLinearSearch(this int[] array, int value)
        {

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == value)
                {
                    return i;
                }

            }
            return -1;
        }

        public static int MyBinarySearch(this int[] array, int value)
        {
            int i = 0, j = array.Length - 1;
            while (i <= j)
            {
                int k = i + ((j - i) / 2);
                if (array[k] == value)
                {
                    return k;
                }
                else if (array[k] < value)
                {
                    i = k + 1;
                }
                else
                {
                    j = k - 1;
                }
            }
            return -1;
        }
    }
}