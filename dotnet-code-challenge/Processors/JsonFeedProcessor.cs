using System;
using System.Collections.Generic;
using System.Linq;
using dotnet_code_challenge.Models;
using Newtonsoft.Json;

namespace dotnet_code_challenge.Processors
{
    public class JsonFeedProcessor : IFeedProcessor
    {
        public bool CanProcess(string fileName)
        {
            //TODO: Improved checks for JSON file input
            return fileName.EndsWith(".json", StringComparison.OrdinalIgnoreCase);
        }

        public Feed Process(string input)
        {
            dynamic data = JsonConvert.DeserializeObject(input);

            dynamic fixture = data.RawData;

            IEnumerable<dynamic> markets = fixture.Markets;

            return new Feed
            {
                FeedId = fixture.Id,
                Races = markets.Select((market, index) =>
                {
                    IEnumerable<dynamic> selections = market.Selections;

                    return new Race
                    {
                        Name = fixture.FixtureName,
                        RaceNumber = index + 1,
                        Horses = selections.Select(selection =>
                        {
                            return new Horse
                            {
                                Name = selection.Tags.name,
                                Price = decimal.Parse((string)selection.Price)
                            };
                        })
                    };
                })
            };
        }
    }
}
