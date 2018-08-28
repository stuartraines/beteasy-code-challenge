using System;
using System.IO;

namespace dotnet_code_challenge.Utils
{
    public class FileReader : IFileReader
    {
        public string Read(string path)
        {
            return File.ReadAllText(path);
        }
    }
}
