using System;
using System.Collections.Generic;
using dotnet_code_challenge.Commands;
using dotnet_code_challenge.Exceptions;
using dotnet_code_challenge.Processors;
using dotnet_code_challenge.Queries;
using dotnet_code_challenge.Repositories;
using dotnet_code_challenge.Requests;
using dotnet_code_challenge.Responses;
using dotnet_code_challenge.Services;
using dotnet_code_challenge.Utils;

namespace dotnet_code_challenge
{
    class Program
    {
        //TODO: Move into IoC
        private static readonly IEnumerable<IFeedProcessor> _feedProcessors = new List<IFeedProcessor> { new JsonFeedProcessor() };
        private static readonly IFeedRepository _repository = new FeedRepository();
        private static readonly ICommand<PersistFeedRequest> _command = new PersistFeedCommand(_repository);
        private static readonly IPathResolver _pathResolver = new VirtualPathResolver();
        private static readonly IFileReader _fileReader = new FileReader();
        private static readonly IFeedIngester _ingester = new RacesFeedIngester(_feedProcessors, _command, _pathResolver, _fileReader);
        private static readonly IQuery<GetHorsesWithPriceRequest, GetHorsesWithPriceResponse> _query = new GetHorsesWithPriceQuery(_repository);

        static void Main(string[] args)
        {
            //TODO: Abstract to a Facade to allow for testability.
            while (true)
            {
                DisplayInstructions();

                //TODO: Abstract away user input handling
                var userResponse = Console.ReadLine().ToLowerInvariant();

                if (userResponse == "q")
                {
                    break;
                }

                string file = string.Empty;

                if (userResponse == "1")
                {
                    file = "FeedData/Caulfield_Race1.xml";
                }
                else if (userResponse == "2")
                {
                    file = "FeedData/Wolferhampton_Race1.json";
                }
                else
                {
                    Console.WriteLine("Invalid option. Please try again");
                    continue;
                }

                string feedId = null;

                try
                {
                    // 1. Ingest feed. 
                    /* This would otherwise be done out of process
                       but for purposes of this exercise, I ingest 
                       the feed first within this application. */
                    feedId = _ingester.Ingest(file);
                }
                catch (FeedTypeNotSupportedException e)
                {
                    Console.WriteLine($"An exception occured while trying to process the input feed {userResponse}. Error details: {e.Message}.");
                }

                Console.WriteLine($"Feed ingested successfully with id: {feedId}");

                // 2. Transform the feed data into a view model
                //TODO: Use builder pattern here
                var request = new GetHorsesWithPriceRequest
                {
                    FeedId = feedId
                };
                var response = _query.Query(request);

                // 3. Display the results
            }
        }

        private static void DisplayInstructions()
        {
            Console.WriteLine("Please select from one of the following options, or press 'q' to exit:");
            Console.WriteLine();
            Console.WriteLine("Press '1' for Caulfield_Race1.xml");
            Console.WriteLine("Press '2' for Wolferhampton_Race1.json");
        }
    }
}
