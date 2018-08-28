using System;
using System.Linq;
using dotnet_code_challenge.Repositories;
using dotnet_code_challenge.Requests;
using dotnet_code_challenge.Responses;

namespace dotnet_code_challenge.Queries
{
    public class GetHorsesWithPriceQuery : IQuery<GetHorsesWithPriceRequest, GetHorsesWithPriceResponse>
    {
        private readonly IFeedRepository _feedRepository;

        public GetHorsesWithPriceQuery(IFeedRepository feedRepository)
        {
            _feedRepository = feedRepository;
        }

        public GetHorsesWithPriceResponse Query(GetHorsesWithPriceRequest request)
        {
            var feeds = _feedRepository.Read();

            var feed = feeds.Single(x => x.FeedId == request.FeedId);

            var race = feed.Races.Single(x => x.RaceNumber == request.RaceNumber);

            var horses = race.Horses.OrderBy(x => x.Price);

            return new GetHorsesWithPriceResponse
            {
                Horses = horses
            };
        }
    }
}
