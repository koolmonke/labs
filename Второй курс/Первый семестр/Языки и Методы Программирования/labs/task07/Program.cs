namespace task07
{
    static class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Введите N и M");
            int n = 0, m = 0;
            try
            {
                n = int.Parse(Console.ReadLine());
                m = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }

            int[][] a = new int[n][];
            Console.WriteLine("Введите матрицу");
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = new int[m];
                for (int j = 0; j < a[i].Length; j++)
                {
                    Console.WriteLine($"Введите {i + 1}, {j + 1} элемент");
                    if (int.TryParse(Console.ReadLine(), out a[i][j]) != true)
                    {
                        Console.WriteLine("Неверный ввод");
                        j--;
                    }
                }
            }

            Console.WriteLine("Матрица:");
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a[i].Length; j++)
                {
                    Console.Write($"{a[i][j]}\t");
                }

                Console.WriteLine();
            }

            int iMax = 0, jMax = 0;
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a[i].Length; j++)
                {
                    if (Math.Abs(a[i][j]) > Math.Abs(a[iMax][jMax]))
                    {
                        iMax = i;
                        jMax = j;
                    }
                }
            }

            Console.WriteLine($"Максимальное значение a[{iMax + 1}][{jMax + 1}] = {a[iMax][jMax]}");

            Console.WriteLine("Enter k");
            int k = int.Parse(Console.ReadLine()) - 1;
            for (int i = 0; i < a.Length; i++)
            {
                (a[i][k], a[i][jMax]) = (a[i][jMax], a[i][k]);
            }

            (a[k], a[iMax]) = (a[iMax], a[k]);

            Console.WriteLine("Новая матрица:");
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a[i].Length; j++)
                {
                    Console.Write($"{a[i][j]}\t");
                }

                Console.WriteLine();
            }
        }
    }
}