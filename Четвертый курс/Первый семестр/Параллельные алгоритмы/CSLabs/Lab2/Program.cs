using System;
using System.IO;
using System.Linq;

namespace Lab2
{
    internal static class Program
    {
        private static int[] GetPrefix(string s) => Enumerable.Range(1, s.Length - 1)
            .AsParallel()
            .AsOrdered()
            .Select(i =>
            {
                int index = 0;
                while (index >= 0 && s[index] != s[i])
                {
                    index--;
                }

                index++;

                return index;
            })
            .ToArray();

        public static int? FindSubstring(string pattern, string text)
        {
            int[] pf = GetPrefix(pattern);
            int index = 0;

            for (int i = 0; i < text.Length; i++)
            {
                while (index > 0 && pattern[index] != text[i])
                {
                    index = pf[index - 1];
                }

                if (pattern[index] == text[i])
                {
                    index++;
                }

                if (index == pattern.Length)
                {
                    return i - index + 1;
                }
            }

            return null;
        }

        private static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                throw new ApplicationException("Usage ./program <filepath> <words>");
            }


            var text = File.ReadAllText(args[0]);

            var subStrings = args[1..];

            foreach (var (word, startIndex) in subStrings.AsParallel()
                .Select(word => (word, FindSubstring(word, text))))
            {
                Console.WriteLine(startIndex != null
                    ? $"Found {word} at {startIndex}..{startIndex + word.Length - 1}"
                    : $"Didn't find {word}");
            }
        }
    }
}