using System;

namespace task8
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string userinput = Console.ReadLine();
            var count = 0;
            Console.WriteLine("Слова в строке, содержащие букву K");
            foreach (var item in userinput.Split()) 
            {
                if (item.Contains("k") || item.Contains("K"))
                {
                    Console.WriteLine(item);
                    count++;
                }
            }
            Console.WriteLine(String.Format("Всего их {0} ", count));
        }
    }
}
