using System;

namespace task25
{
    struct Point
    {
        public double x, y;
    }
    class MainClass
    {
        public static void Main(string[] args)
        {
            Point[] vectors = new Point[2];
            var min_indexes = new int[] { -1, -1, -1 };
            double min_area = 0;
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
                Console.Write(String.Format("Введите координаты {0} точки через пробел: ", i + 1));
                var str = Console.ReadLine().Split();
                points[i].x = double.Parse(str[0]);
                points[i].y = double.Parse(str[1]);
            }
            Console.WriteLine("Все точки:");
            foreach (var point in points)
            {
                Console.WriteLine(String.Format("({0},{1})", point.x, point.y));
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    vectors[0].x = points[j].x - points[i].x;
                    vectors[0].y = points[j].y - points[i].y;
                    for (int k = j + 1; k < n; k++)
                    {
                        vectors[1].x = points[k].x - points[i].x;
                        vectors[1].y = points[k].y - points[i].y;
                        double area = Math.Abs(vectors[0].x * vectors[1].y - vectors[0].y * vectors[1].x);
                        if (area > double.Epsilon && (min_area > area || min_area < double.Epsilon)) // В первый раз берем любой min_area не на одной прямой
                        {
                            min_area = area;
                            min_indexes[0] = i;
                            min_indexes[1] = j;
                            min_indexes[2] = k;
                        }
                    }
                }
            }
            if (min_indexes[0] == -1)
            {
                Console.WriteLine("Все точки лежат на одной прямой");
            }
            else
            {
                Console.WriteLine(String.Format("Минимальная площадь: {0}", min_area / 2));
                Console.Write("Точки треугольника: ");
                foreach (var index in min_indexes)
                {
                    Console.WriteLine(String.Format("({0},{1})", points[index].x, points[index].y));
                }
            }
        }
    }
}