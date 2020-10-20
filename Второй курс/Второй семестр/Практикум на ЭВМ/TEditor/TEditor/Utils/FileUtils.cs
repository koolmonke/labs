using System.IO;

namespace TEditor.Utils
{
    internal static class FileUtils
    {
        public static void FileWriter(string path, string toWrite)
        {
            using (var writer = new StreamWriter(path))
            {
                writer.Write(toWrite);
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
