using System;
using System.IO;

namespace dotnet_code_challenge.Utils
{
    public class VirtualPathResolver : IPathResolver
    {
        public string Resolve(string virtualPath)
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, virtualPath);
        }
    }
}
