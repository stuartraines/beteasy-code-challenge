using System;
namespace dotnet_code_challenge.Renderers
{
    public interface IRenderer<T>
    {
        void Render(T data);
    }
}
