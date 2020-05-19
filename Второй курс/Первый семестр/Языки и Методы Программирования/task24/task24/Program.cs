using System;
using System.Collections.Generic;
using System.IO;
namespace task24
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            const string alpha = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            var UserInput = File.OpenText("userinput.txt");
            var CharList = new List<string> { };
            Dictionary<string, int> dict = new Dictionary<string, int> {{ "а", 0 }, { "б", 0 }, { "в", 0 },
                  { "г", 0 }, { "д", 0 }, { "е", 0 }, { "ё", 0 }, { "ж", 0 },
                  { "з", 0 }, { "и", 0 }, { "й", 0 }, { "к", 0 }, { "л", 0 },
                  { "м", 0 }, { "н", 0 }, { "о", 0 }, { "п", 0 }, { "р", 0 },
                  { "с", 0 }, { "т", 0 }, { "у", 0 }, { "ф", 0 }, { "х", 0 },
                  { "ц", 0 }, { "ч", 0 }, { "ш", 0 }, { "щ", 0 }, { "ъ", 0 },
                  { "ы", 0 }, { "ь", 0 }, { "э", 0 }, { "ю", 0 }, { "я", 0 } };

            while (UserInput.EndOfStream != true)
            {
                string item = ((char)UserInput.Read()).ToString().ToLower();
                if (alpha.Contains(item))
                {
                    dict[item]++;
                    if (!CharList.Contains(item))
                    {
                        CharList.Add(item);
                    }
                }
            }
            Console.WriteLine("Буквы, которые встречаются в файле только один раз по порядку появляения");
            foreach (var item in CharList)
            {
                if (dict[item] == 1) Console.WriteLine(item);
            }
            UserInput.Close();
        }
    }
}
