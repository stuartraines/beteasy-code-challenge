using System;
namespace dotnet_code_challenge.Utils
{
    public interface IPathResolver
    {
        string Resolve(string virtualPath);
    }
}
