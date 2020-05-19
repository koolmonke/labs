﻿using System;

namespace task7
{
    class MainClass
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
                    Console.WriteLine(String.Format("Введите {0}, {1} элемент", i+1, j+1));
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
                    Console.Write(a[i][j] + "\t");
                }
                Console.WriteLine();
            }
            int i_max = 0, j_max = 0;
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a[i].Length; j++)
                {
                    if (Math.Abs(a[i][j]) > Math.Abs(a[i_max][j_max]))
                    {
                        i_max = i;
                        j_max = j;
                    }
                }
            }
            Console.WriteLine(String.Format("Максимальное значение a[{0}][{1}] = {2}", 
                                            i_max + 1, j_max + 1, a[i_max][j_max]));

            Console.WriteLine("Enter k");
            int k = int.Parse(Console.ReadLine()) - 1;
            for (int i = 0; i < a.Length; i++)
            {
                int t = a[i][k];
                a[i][k] = a[i][j_max];
                a[i][j_max] = t;
            }
            //for (int j = 0; j < m; j++)
            //{
            //    t = a[k][j];
            //    a[k][j] = a[i_max][j];
            //    a[i_max][j] = t;
            //}
            {
                int[] t_arr = a[k];
                a[k] = a[i_max];
                a[i_max] = t_arr;
            }

            Console.WriteLine("Новая матрица:");
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a[i].Length; j++)
                {
                    Console.Write(a[i][j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
