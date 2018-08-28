using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using dotnet_code_challenge.Models;

namespace dotnet_code_challenge.Processors
{
    public class XmlFeedProcessor : IFeedProcessor
    {
        public bool CanProcess(string fileName)
        {
            //TODO: Improved checks for XML file input
            return fileName.EndsWith(".xml", StringComparison.OrdinalIgnoreCase);
        }

        public Feed Process(string input)
        {
            var doc = XDocument.Parse(input);

            return new Feed
            {
                FeedId = doc.Descendants("Meetingid").Single().Value,
                Races = doc.Descendants("race").Select(GetRace)
            };
        }

        private Race GetRace(XElement race)
        {

            var prices = race.Elements("prices").Single().Descendants("horse");

            return new Race
            {
                Name = race.Attribute("name").Value,
                RaceNumber = int.Parse(race.Attribute("number").Value),
                Horses = race.Elements("horses").Single().Elements("horse").Select(horse => GetHorse(horse, prices))
            };
        }

        private Horse GetHorse(XElement horse, IEnumerable<XElement> prices)
        {
            return new Horse
            {
                Name = horse.Attribute("name").Value,
                Price = decimal.Parse(prices.First(p => p.Attribute("number").Value == horse.Elements("number").Single().Value).Attribute("Price").Value)
            };
        }
    }
}
