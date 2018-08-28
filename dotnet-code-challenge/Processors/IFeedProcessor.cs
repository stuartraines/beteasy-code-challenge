using System;
using dotnet_code_challenge.Models;

namespace dotnet_code_challenge.Processors
{
    public interface IFeedProcessor
    {
        bool CanProcess(string fileName);

        Feed Process(string input);
    }
}
