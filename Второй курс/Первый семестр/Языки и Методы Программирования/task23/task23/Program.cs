using System;
using System.IO;

namespace task23
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Random rnd = new Random();
            using (var fileA = File.CreateText("file_A"))
            {
                Console.Write("Введите кол-во чисел: ");
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

                for (int i = 0; i < n; i++)
                {
                    fileA.WriteLine(rnd.Next(100));
                }
            }

            using (var fileAInput = File.OpenText("file_A"))
            {
                int count = 0;
                while (fileAInput.EndOfStream != true)
                {
                    var t = int.Parse(fileAInput.ReadLine());
                    var isSqr = (int) Math.Pow((int) Math.Sqrt(t), 2) == t;
                    if (t % 8 == 1 && isSqr)
                        count++;
                }

                Console.WriteLine(count);
            }
        }
    }
}