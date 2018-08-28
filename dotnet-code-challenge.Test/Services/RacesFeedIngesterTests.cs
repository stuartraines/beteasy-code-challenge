using System;
using dotnet_code_challenge.Commands;
using dotnet_code_challenge.Exceptions;
using dotnet_code_challenge.Processors;
using dotnet_code_challenge.Requests;
using dotnet_code_challenge.Services;
using dotnet_code_challenge.Utils;
using FakeItEasy;
using NUnit.Framework;

namespace dotnet_code_challenge.Test.Services
{
    public class RacesFeedIngesterTests
    {
        private IFeedProcessor _feedProcessor;
        private ICommand<PersistFeedRequest> _command;
        private IPathResolver _pathResolver;
        private IFileReader _fileReader;

        private RacesFeedIngester _subject;

        [SetUp]
        public void Setup()
        {
            _feedProcessor = A.Fake<IFeedProcessor>();
            _command = A.Fake<ICommand<PersistFeedRequest>>();
            _pathResolver = A.Fake<IPathResolver>();
            _fileReader = A.Fake<IFileReader>();

            _subject = new RacesFeedIngester(new[] { _feedProcessor }, _command, _pathResolver, _fileReader);
        }

        [Test]
        public void ShouldThrowExceptionWhenCannotBeProcessed()
        {
            // Arrange
            A.CallTo(() => _feedProcessor.CanProcess(A<string>.Ignored)).Returns(false);

            // Act/Assert
            Assert.Throws<FeedTypeNotSupportedException>(() => _subject.Ingest("SOURCE"));
        }

        [Test]
        public void GivenSuccessfullyProcessedFeedThenShouldPersistFeed()
        {
            // Arrange
            var feed = new Models.Feed();
            A.CallTo(() => _feedProcessor.CanProcess(A<string>.Ignored)).Returns(true);
            A.CallTo(() => _feedProcessor.Process(A<string>.Ignored)).Returns(feed);

            // Act
            var actual = _subject.Ingest("SOURCE");

            // Assert
            A.CallTo(() => _command.Execute(A<PersistFeedRequest>.That.Matches(r => r.Feed == feed))).MustHaveHappenedOnceExactly();
        }
    }
}
