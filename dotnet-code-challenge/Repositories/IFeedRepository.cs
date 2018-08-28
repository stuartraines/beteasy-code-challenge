using System;
using System.Collections.Generic;
using dotnet_code_challenge.Models;

namespace dotnet_code_challenge.Repositories
{
    public interface IFeedRepository
    {
        void Persist(Feed feed);
        IEnumerable<Feed> Read();
    }
}
