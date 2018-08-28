using System;
using System.Collections.Generic;

namespace dotnet_code_challenge.Models
{
    public class Feed
    {
        public string FeedId { get; set; }

        public IEnumerable<Race> Races { get; set; }
    }
}
