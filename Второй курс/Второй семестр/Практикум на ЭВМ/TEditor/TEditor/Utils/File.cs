using System;

namespace TEditor.Utils
{
    class File : IEquatable<File>
    {
        public string FileName { get; private set; }

        public string Content
        {
            get => FileUtils.FileReader(FileName);
            set => FileUtils.FileWriter(FileName, value);
        }

        public bool Equals(File other) => this.FileName == other.FileName;

        public File(string FilePath)
        {
            this.FileName = FilePath;
        }

        public File(string FilePath, string Content)
        {
            this.FileName = FilePath;
            this.Content = Content;
        }
    }
}
