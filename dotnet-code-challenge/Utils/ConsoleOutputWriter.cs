using System;
namespace dotnet_code_challenge.Utils
{
    public class ConsoleOutputWriter : IOutputWriter
    {
        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }

        public void WriteLine()
        {
            Console.WriteLine();
        }
    }
}
