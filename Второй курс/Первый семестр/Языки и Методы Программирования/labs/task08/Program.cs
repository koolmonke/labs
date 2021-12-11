namespace task08
{
    static class MainClass
    {
        public static void Main(string[] args)
        {
            string userInput = Console.ReadLine() ?? "";
            var count = 0;
            Console.WriteLine("Слова в строке, содержащие букву K");
            foreach (var item in userInput.Split())
            {
                if (item.Contains('k') || item.Contains('K'))
                {
                    Console.WriteLine(item);
                    count++;
                }
            }

            Console.WriteLine($"Всего их {count}");
        }
    }
}