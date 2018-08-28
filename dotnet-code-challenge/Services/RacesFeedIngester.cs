using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using dotnet_code_challenge.Commands;
using dotnet_code_challenge.Exceptions;
using dotnet_code_challenge.Processors;
using dotnet_code_challenge.Requests;
using dotnet_code_challenge.Utils;

namespace dotnet_code_challenge.Services
{
    public class RacesFeedIngester : IFeedIngester
    {
        private readonly IEnumerable<IFeedProcessor> _feedProcessors;
        private readonly ICommand<PersistFeedRequest> _command;
        private readonly IPathResolver _pathResolver;
        private readonly IFileReader _fileReader;

        public RacesFeedIngester(IEnumerable<IFeedProcessor> feedProcessors, ICommand<PersistFeedRequest> command, IPathResolver pathResolver, IFileReader fileReader)
        {
            _feedProcessors = feedProcessors;
            _command = command;
            _pathResolver = pathResolver;
            _fileReader = fileReader;
        }

        public string Ingest(string source)
        {
            //Strategy pattern to determine which processor to use (i.e. if input is XML or JSON)
            var matchingProcessor = _feedProcessors.FirstOrDefault(x => x.CanProcess(source));

            if (matchingProcessor == null)
            {
                throw new FeedTypeNotSupportedException($"Feed with name {source} not supported");
            }

            var filePath = _pathResolver.Resolve(source);

            var fileContents = _fileReader.Read(filePath);

            var feed = matchingProcessor.Process(fileContents);

            var request = new PersistFeedRequest
            {
                Feed = feed
            };

            _command.Execute(request);

            return feed.FeedId;
        }
    }
}
