using System;
namespace dotnet_code_challenge.Utils
{
    public interface IOutputWriter
    {
        void WriteLine();
        void WriteLine(string text);
    }
}
