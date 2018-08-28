using System;
using System.Collections.Generic;
using dotnet_code_challenge.Commands;
using dotnet_code_challenge.Processors;
using dotnet_code_challenge.Requests;
using dotnet_code_challenge.Services;
using dotnet_code_challenge.Utils;

namespace dotnet_code_challenge
{
    class Program
    {
        //TODO: Move into IoC
        private static readonly IEnumerable<IFeedProcessor> _feedProcessors = new List<IFeedProcessor>();
        private static readonly ICommand<PersistFeedRequest> _command = null;
        private static readonly IPathResolver _pathResolver = null;
        private static readonly IFileReader _fileReader = null;
        private static readonly IFeedIngester _ingester = new RacesFeedIngester(_feedProcessors, _command, _pathResolver, _fileReader);

        static void Main(string[] args)
        {
            // 1. Ingest feed. 
            /* This would otherwise be done out of process
               but for purposes of this exercise, I ingest 
               the feed first within this application. */
            var input = Console.ReadLine();
            var result = _ingester.Ingest(input);


            // 2. Transform the feed data into a view model



            // 3. Display the results
        }
    }
}
