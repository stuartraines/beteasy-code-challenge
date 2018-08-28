using System;
namespace dotnet_code_challenge.Queries
{
    public interface IQuery<TRequest, TResponse>
    {
        TResponse Query(TRequest request);
    }
}
