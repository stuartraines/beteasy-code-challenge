using System;
using System.Collections.Generic;
using dotnet_code_challenge.Models;

namespace dotnet_code_challenge.Repositories
{
    public class FeedRepository : IFeedRepository
    {
        private static readonly List<Feed> _data = new List<Feed>();

        public void Persist(Feed feed)
        {
            _data.Add(feed);
        }

        public IEnumerable<Feed> Read()
        {
            return _data;
        }
    }
}
