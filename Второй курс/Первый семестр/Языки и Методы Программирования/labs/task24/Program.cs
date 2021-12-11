namespace task24
{
    static class MainClass
    {
        public static void Main(string[] args)
        {
            var userInput = File.ReadAllText(args[0]);

            var counter = userInput
                .Distinct()
                .Where(item => userInput.Count(c => item == c) == 1);

            Console.WriteLine("Буквы, которые встречаются в файле только один раз по порядку появления:");
            foreach (var c in counter)
            {
                Console.WriteLine(c);
            }
        }
    }
}