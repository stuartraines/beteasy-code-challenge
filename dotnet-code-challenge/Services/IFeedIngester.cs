using System;
namespace dotnet_code_challenge.Services
{
    public interface IFeedIngester
    {
        string Ingest(string source);
    }
}
