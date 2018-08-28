using System.Linq;
using dotnet_code_challenge.Repositories;
using dotnet_code_challenge.Requests;

namespace dotnet_code_challenge.Commands
{
    public class PersistFeedCommand : ICommand<PersistFeedRequest>
    {
        private readonly IFeedRepository _repository;

        public PersistFeedCommand(IFeedRepository repository)
        {
            _repository = repository;
        }

        public void Execute(PersistFeedRequest request)
        {
            if (_repository.Read().Any(x => x.FeedId == request.Feed.FeedId))
            {
                return;
            }

            _repository.Persist(request.Feed);
        }
    }
}
