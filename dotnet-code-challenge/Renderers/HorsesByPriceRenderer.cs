using System;
using System.Linq;
using dotnet_code_challenge.Responses;
using dotnet_code_challenge.Utils;

namespace dotnet_code_challenge.Renderers
{
    public class HorsesByPriceRenderer : IRenderer<GetHorsesWithPriceResponse>
    {
        private readonly IOutputWriter _writer;

        public HorsesByPriceRenderer(IOutputWriter writer)
        {
            _writer = writer;
        }

        public void Render(GetHorsesWithPriceResponse data)
        {
            _writer.WriteLine();
            _writer.WriteLine();
            _writer.WriteLine("****** Race Summary ********");
            _writer.WriteLine();

            var horseList = data.Horses.ToList();

            for (int i = 0; i < horseList.Count; i++)
            {
                var horse = horseList[i];
                _writer.WriteLine($"{i + 1,2}. {horse.Name,-30}${horse.Price:f2}");
            }

            _writer.WriteLine();
            _writer.WriteLine("***************** End ******************");
            _writer.WriteLine();
            _writer.WriteLine();
        }
    }
}
