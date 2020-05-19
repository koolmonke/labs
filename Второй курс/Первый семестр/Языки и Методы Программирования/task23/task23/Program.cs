using System;
using System.IO;
namespace task23
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Random rnd = new Random();
            var file_A = File.CreateText("file_A");
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
                file_A.WriteLine(rnd.Next(100));
            }
            file_A.Close();
            var file_A_input = File.OpenText("file_A");
            int count = 0;
            while (file_A_input.EndOfStream != true)
            {
                var t = int.Parse(file_A_input.ReadLine());
                var is_sqr = (int)Math.Pow((int)Math.Sqrt(t), 2) == t;
                if (t % 8 == 1 && is_sqr == true)
                    count++;
            }
            Console.WriteLine(count);
        }
    }
}
