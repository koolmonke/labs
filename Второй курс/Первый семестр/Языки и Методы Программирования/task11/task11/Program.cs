using System;

namespace task11
{
    class MainClass
    {
        static void FindAndReplace(int[] array)
        {
            int min = Math.Abs(array[0]);
            for (int i = 0; i < array.Length; i++)
                if (min > Math.Abs(array[i]))
                    min = Math.Abs(array[i]);
            for (int i = 0; i < array.Length; i += 2)
            {
                array[i] = min;
            }
        }
        public static void Main(string[] args)
        {
            // int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            Console.WriteLine("Введите кол-во элементов в массиве");
            int n = 0;
            try
            {
                n = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            var arr = new int[n];
            var temp = 0;
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введите элемент {i}");
                if (int.TryParse(Console.ReadLine(), out temp)) {
                    arr[i] = temp;
                }
                else
                {
                    Console.WriteLine("Неверный ввод");
                    i--;
                };
            }
            Array.ForEach(arr, item => Console.Write($"{item} "));
            Console.WriteLine();
            FindAndReplace(arr);
            Array.ForEach(arr, item => Console.Write($"{item} "));
            Console.WriteLine();
        }
    }
}
