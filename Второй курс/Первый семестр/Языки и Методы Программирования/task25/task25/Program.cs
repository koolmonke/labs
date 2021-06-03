using System;

namespace task25
{
    struct Point
    {
        public double X, Y;
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            Point[] vectors = new Point[2];
            var minIndexes = new[] {-1, -1, -1};
            double minArea = 0;
            Console.Write("Введите количество точек: ");
            int n = 0;
            try
            {
                n = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }

            Point[] points = new Point[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Введите координаты {i + 1} точки через пробел: ");
                var str = Console.ReadLine().Split();
                points[i].X = double.Parse(str[0]);
                points[i].Y = double.Parse(str[1]);
            }

            Console.WriteLine("Все точки:");
            foreach (var point in points)
            {
                Console.WriteLine($"({point.X},{point.Y})");
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    vectors[0].X = points[j].X - points[i].X;
                    vectors[0].Y = points[j].Y - points[i].Y;
                    for (int k = j + 1; k < n; k++)
                    {
                        vectors[1].X = points[k].X - points[i].X;
                        vectors[1].Y = points[k].Y - points[i].Y;
                        double area = Math.Abs(vectors[0].X * vectors[1].Y - vectors[0].Y * vectors[1].X);
                        if (area > double.Epsilon &&
                            (minArea > area ||
                             minArea < double.Epsilon)) // В первый раз берем любой min_area не на одной прямой
                        {
                            minArea = area;
                            minIndexes[0] = i;
                            minIndexes[1] = j;
                            minIndexes[2] = k;
                        }
                    }
                }
            }

            if (minIndexes[0] == -1)
            {
                Console.WriteLine("Все точки лежат на одной прямой");
            }
            else
            {
                Console.WriteLine($"Минимальная площадь: {minArea / 2}");
                Console.Write("Точки треугольника: ");
                foreach (var index in minIndexes)
                {
                    Console.WriteLine($"({points[index].X},{points[index].Y})");
                }
            }
        }
    }
}