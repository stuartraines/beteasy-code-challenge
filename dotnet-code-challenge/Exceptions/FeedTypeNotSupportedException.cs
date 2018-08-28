using System;
namespace dotnet_code_challenge.Exceptions
{
    public class FeedTypeNotSupportedException : Exception
    {
        public FeedTypeNotSupportedException(string message) : base(message)
        {
        }
    }
}
