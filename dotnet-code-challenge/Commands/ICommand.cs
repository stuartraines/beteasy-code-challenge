using System;
namespace dotnet_code_challenge.Commands
{
    public interface ICommand<TRequest>
    {
        void Execute(TRequest request);
    }
}
