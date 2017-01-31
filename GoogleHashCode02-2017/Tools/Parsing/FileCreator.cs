using System;
using System.IO;

namespace GoogleHashCode02_2017.Tools.Parsing
{
    public class FileCreator : IDisposable
    {
        private StreamWriter FileWriter;

        public FileCreator(string filePath)
        {
            FileWriter = new StreamWriter(filePath, false);
        }

        public void WriteLine(string line)
        {
            FileWriter.WriteLine(line);
        }

        public void Dispose()
        {
            FileWriter?.Flush();
            FileWriter?.Close();
            FileWriter?.Dispose();
        }
    }
}