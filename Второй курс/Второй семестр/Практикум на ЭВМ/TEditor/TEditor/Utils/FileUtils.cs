using System.IO;

namespace TEditor.Utils
{
    internal static class FileUtils
    {
        public static void FileWriter(string Path, string ToWrite)
        {
            using (var writer = new StreamWriter(Path))
            {
                writer.Write(ToWrite);
            }
        }

        public static string FileReader(string Path)
        {
            using (var reader = new StreamReader(Path))
            {
                return reader.ReadToEnd();
            }
        }

    }
}
