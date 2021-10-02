using System;
using System.Linq;
using System.IO;


namespace KNPAlgo
{
    class Program
    {
        static int[] GetPrefix(string s) => Enumerable.Range(1, s.Length - 1)
            .AsParallel()
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

        static int FindSubstring(string pattern, string text)
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

            return -1;
        }

        static void Main(string[] args)
        {
            var text = File.ReadAllText(@"F:\knigga.txt")).ToLower();

            var substr = new[] { "mon", "и", "мир" };

            foreach(var item in substr.AsParallel().AsOrdered().Select(word=>FindSubstring(word, text)))
            {
                Console.WriteLine(item);
            }
        }
    }
}
